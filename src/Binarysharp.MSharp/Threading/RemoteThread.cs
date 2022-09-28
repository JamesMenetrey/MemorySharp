﻿/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/

using System.ComponentModel;
using System.Diagnostics;
using Binarysharp.MSharp.Internals;
using Binarysharp.MSharp.Native;
using Binarysharp.MSharp.Threading.Windows;
using ThreadState = System.Diagnostics.ThreadState;

namespace Binarysharp.MSharp.Threading
{
    /// <summary>
    /// Class representing a thread in the remote process.
    /// </summary>
    public class RemoteThread : IDisposable, IEquatable<RemoteThread>
    {
        #region Fields
        /// <summary>
        /// The reference of the <see cref="MSharp.MemorySharp"/> object.
        /// </summary>
        protected readonly MemorySharp MemorySharp;
        /// <summary>
        /// The parameter passed to the thread when it was created.
        /// </summary>
        private readonly IMarshalledValue _parameter;
        /// <summary>
        /// The task involved in cleaning the parameter memory when the <see cref="RemoteThread"/> object is collected.
        /// </summary>
        private readonly Task _parameterCleaner;
        /// <summary>
        /// The internal field that stores the lazy evaluation for the managed thread environment block.
        /// </summary>
        private readonly Lazy<ManagedTeb> _teb;
        #endregion

        #region Properties
        #region Handle
        /// <summary>
        /// The remote thread handle opened with all rights.
        /// </summary>
        public SafeMemoryHandle Handle { get; private set; }
        #endregion
        #region Id
        /// <summary>
        /// Gets the unique identifier of the thread.
        /// </summary>
        public int Id { get; private set; }
        #endregion
        #region IsAlive
        /// <summary>
        /// Gets if the thread is alive.
        /// </summary>
        public bool IsAlive
        {
            get { return !IsTerminated; }
        }
        #endregion
        #region IsMainThread
        /// <summary>
        /// Gets if the thread is the main one in the remote process.
        /// </summary>
        public bool IsMainThread
        {
            get { return this == MemorySharp.Threads.MainThread; }
        }
        #endregion
        #region IsSuspended
        /// <summary>
        /// Gets if the thread is suspended.
        /// </summary>
        public bool IsSuspended
        {
            get
            {
                // Refresh the thread info
                Refresh();
                // Return if the thread is suspended
                return Native != null && Native.ThreadState == ThreadState.Wait && Native.WaitReason == ThreadWaitReason.Suspended;
            }
        }
        #endregion
        #region IsTerminated
        /// <summary>
        /// Gets if the thread is terminated.
        /// </summary>
        public bool IsTerminated
        {
            get
            {
                // Refresh the thread info
                Refresh();
                // Check if the thread is terminated
                return Native == null;
            }
        }
        #endregion
        #region Native
        /// <summary>
        /// The native <see cref="ProcessThread"/> object corresponding to this thread.
        /// </summary>
        public ProcessThread Native { get; private set; }
        #endregion
        #region Teb        
        /// <summary>
        /// Gets the thread environment block.
        /// </summary>
        public ManagedTeb Teb => _teb.Value;
        #endregion
        #endregion

        #region Constructor/Destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteThread"/> class.
        /// </summary>
        /// <param name="memorySharp">The reference of the <see cref="MSharp.MemorySharp"/> object.</param>
        /// <param name="thread">The native <see cref="ProcessThread"/> object.</param>
        internal RemoteThread(MemorySharp memorySharp, ProcessThread thread)
        {
            // Save the parameters
            MemorySharp = memorySharp;
            Native = thread;
            // Save the thread id
            Id = thread.Id;
            // Open the thread
            Handle = ThreadCore.OpenThread(ThreadAccessFlags.AllAccess, Id);
            // Initialize the TEB lazy loader
            _teb = new Lazy<ManagedTeb>(() => new ManagedTeb(memorySharp, this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteThread"/> class.
        /// </summary>
        /// <param name="memorySharp">The reference of the <see cref="MSharp.MemorySharp"/> object.</param>
        /// <param name="thread">The native <see cref="ProcessThread"/> object.</param>
        /// <param name="parameter">The parameter passed to the thread when it was created.</param>
        internal RemoteThread(MemorySharp memorySharp, ProcessThread thread, IMarshalledValue parameter = null) : this(memorySharp, thread)
        {
            // Save the parameter
            _parameter = parameter;
            // Create the task
            _parameterCleaner = new Task(() =>
                                             {
                                                 Join();
                                                 _parameter.Dispose();
                                             });
        }
        /// <summary>
        /// Frees resources and perform other cleanup operations before it is reclaimed by garbage collection. 
        /// </summary>
        ~RemoteThread()
        {
            Dispose();
        }
        #endregion

        #region Methods
        #region Dispose (implementation of IDisposable)
        /// <summary>
        /// Releases all resources used by the <see cref="RemoteThread"/> object.
        /// </summary>
        public virtual void Dispose()
        {
            // Close the thread handle
            Handle.Close();
            // Avoid the finalizer
            GC.SuppressFinalize(this);
        }
        #endregion
        #region Equals (override)
        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((RemoteThread) obj);
        }
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        public bool Equals(RemoteThread other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || (Id == other.Id && MemorySharp.Equals(other.MemorySharp));
        }
        #endregion
        #region GetContext        
        /// <summary>
        /// Gets the context of the thread into the given structure.
        /// If the thread is not already suspended, performs a <see cref="Suspend" /> and <see cref="Resume" /> call on the thread.
        /// </summary>
        /// <typeparam name="TContext">The type of the context to dump.
        /// The type must be unmanaged, so it can be fixed while the native call is done.
        /// The performance is increased if the structure is blittable, which is the case for the structures
        /// provided with the library.</typeparam>
        /// <param name="context">An instance of the structure where the context is loaded into.</param>
        /// <exception cref="ThreadStateException">The context cannot be retrieved because the thread #{Id} is terminated.</exception>
        /// <exception cref="Win32Exception">The context cannot be retrieved from the thread.</exception>
        public void GetContext<TContext>(ref TContext context)
            where TContext : unmanaged
        {
            // Check if the thread is alive
            if (!IsAlive) throw new ThreadStateException($"The context cannot be retrieved because the thread #{Id} is terminated.");

            // Check if the thread is already suspended
            var isSuspended = IsSuspended;
            try
            {
                // Suspend the thread if it wasn't
                if (!isSuspended) Suspend();

                // Get the context
                ThreadCore.GetThreadContext(Handle, ref context);

            }
            finally
            {
                // Resume the thread if it wasn't suspended
                if (!isSuspended) Resume();
            }
        }

        #endregion
        #region GetExitCode
        /// <summary>
        /// Gets the termination status of the thread.
        /// </summary>
        public T GetExitCode<T>()
        {
            // Get the exit code of the thread (can be nullable)
            var ret = ThreadCore.GetExitCodeThread(Handle);
            // Return the exit code or the default value of T if there's no exit code
            return ret.HasValue ? MarshalType<T>.PtrToObject(MemorySharp, ret.Value) : default(T);
        }
        #endregion
        #region GetHashCode (override)
        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ MemorySharp.GetHashCode();
        }
        #endregion
        #region GetRealSegmentAddress
        /// <summary>
        /// Gets the linear address of a specified segment.
        /// </summary>
        /// <param name="segment">The segment to get.</param>
        /// <param name="context">The context.</param>
        /// <returns>A <see cref="IntPtr" /> pointer corresponding to the linear address of the segment.</returns>
        /// <exception cref="InvalidEnumArgumentException">segment</exception>
        public IntPtr GetRealSegmentAddress(SegmentRegisters segment, ref ThreadContext32 context)
        {
            // Get a selector entry for the segment
            LdtEntry entry;
            switch (segment)
            {
                case SegmentRegisters.Cs:
                    entry = ThreadCore.GetThreadSelectorEntry(Handle, context.SegCs);
                    break;

                case SegmentRegisters.Ds:
                    entry = ThreadCore.GetThreadSelectorEntry(Handle, context.SegDs);
                    break;

                case SegmentRegisters.Es:
                    entry = ThreadCore.GetThreadSelectorEntry(Handle, context.SegEs);
                    break;

                case SegmentRegisters.Fs:
                    entry = ThreadCore.GetThreadSelectorEntry(Handle, context.SegFs);
                    break;

                case SegmentRegisters.Gs:
                    entry = ThreadCore.GetThreadSelectorEntry(Handle, context.SegGs);
                    break;

                case SegmentRegisters.Ss:
                    entry = ThreadCore.GetThreadSelectorEntry(Handle, context.SegSs);
                    break;

                default:
                    throw new InvalidEnumArgumentException(nameof(segment), (int)segment, typeof(SegmentRegisters));
            }

            // Compute the linear address
            return new IntPtr(entry.BaseLow | (entry.BaseMid << 16) | (entry.BaseHi << 24));
        }
        #endregion GetRealSegmentAddress
        #region Operator (override)
        public static bool operator ==(RemoteThread left, RemoteThread right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RemoteThread left, RemoteThread right)
        {
            return !Equals(left, right);
        }
        #endregion
        #region Refresh
        /// <summary>
        /// Discards any information about this thread that has been cached inside the process component.
        /// </summary>
        public void Refresh()
        {
            if (Native == null)
                return;
            // Refresh the process info
            MemorySharp.Native.Refresh();
            // Get new info about the thread
            Native = MemorySharp.Threads.NativeThreads.FirstOrDefault(t => t.Id == Native.Id);
        }
        #endregion
        #region Join
        /// <summary>
        /// Blocks the calling thread until the thread terminates.
        /// </summary>
        public void Join()
        {
            ThreadCore.WaitForSingleObject(Handle);
        }
        /// <summary>
        /// Blocks the calling thread until a thread terminates or the specified time elapses.
        /// </summary>
        /// <param name="time">The timeout.</param>
        /// <returns>The return value is a flag that indicates if the thread terminated or if the time elapsed.</returns>
        public WaitValues Join(TimeSpan time)
        {
            return ThreadCore.WaitForSingleObject(Handle, time);
        }
        #endregion
        #region Resume
        /// <summary>
        /// Resumes a thread that has been suspended.
        /// </summary>
        public void Resume()
        {
            // Check if the thread is still alive
            if (!IsAlive) return;

            // Start the thread
            ThreadCore.ResumeThread(Handle);

            // Start a task to clean the memory used by the parameter if we created the thread
            if(_parameter != null && !_parameterCleaner.IsCompleted)
                _parameterCleaner.Start();
        }
        #endregion
        #region SetContext        
        /// <summary>
        /// Sets the context of the thread.
        /// If the thread is not already suspended, performs a <see cref="Suspend" /> and <see cref="Resume" /> call on the thread.
        /// </summary>
        /// <typeparam name="TContext">The type of the context to set.
        /// The type must be unmanaged, so it can be fixed while the native call is done.
        /// The performance is increased if the structure is blittable, which is the case for the structures
        /// provided with the library.</typeparam>
        /// <param name="context">An instance of the structure where the context is set to.</param>
        /// <exception cref="ThreadStateException">The context cannot be set because the thread #{Id} is terminated.</exception>
        /// <exception cref="Win32Exception">The context cannot be set to the thread.</exception>
        public void SetContext<TContext>(ref TContext context)
            where TContext : unmanaged
        {
            // Check if the thread is alive
            if (!IsAlive) throw new ThreadStateException($"The context cannot be set because the thread #{Id} is terminated.");

            // Check if the thread is already suspended
            var isSuspended = IsSuspended;
            try
            {
                // Suspend the thread if it wasn't
                if (!isSuspended) Suspend();

                // Set the context
                ThreadCore.SetThreadContext(Handle, ref context);
            }
            finally
            {
                // Resume the thread if it wasn't suspended
                if (!isSuspended) Resume();
            }
        }
        #endregion
        #region Suspend
        /// <summary>
        /// Either suspends the thread, or if the thread is already suspended, has no effect.
        /// </summary>
        /// <returns>A new instance of the <see cref="FrozenThread"/> class. If this object is disposed, the thread is resumed.</returns>
        public FrozenThread Suspend()
        {
            if (IsAlive)
            {
                ThreadCore.SuspendThread(Handle);
                return new FrozenThread(this);
            }
            return null;
        }
        #endregion
        #region Terminate
        /// <summary>
        /// Terminates the thread.
        /// </summary>
        /// <param name="exitCode">The exit code of the thread to close.</param>
        public void Terminate(int exitCode = 0)
        {
            if(IsAlive)
                ThreadCore.TerminateThread(Handle, exitCode);
        }
        #endregion
        #region ToString (override)
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Id = {0} IsAlive = {1} IsMainThread = {2}", Id, IsAlive, IsMainThread);
        }
        #endregion
        #endregion
    }
}
