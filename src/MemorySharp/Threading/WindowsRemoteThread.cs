using System;
using System.ComponentModel;
using System.Diagnostics;
using Binarysharp.MemoryManagement.Internals;
using Binarysharp.MemoryManagement.Native;

namespace Binarysharp.MemoryManagement.Threading
{
    /// <summary>
    /// Class representing a thread in the remote process specifically for Windows operating system.
    /// </summary>
    public class WindowsRemoteThread : RemoteThread
    {
        #region Constructor/Destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteThread" /> class.
        /// </summary>
        /// <param name="memorySharp">The reference of the <see cref="MemoryManagement.MemorySharp" /> object.</param>
        /// <param name="thread">The native <see cref="ProcessThread" /> object.</param>
        internal WindowsRemoteThread(MemorySharp memorySharp, ProcessThread thread) : base(memorySharp, thread)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteThread" /> class.
        /// </summary>
        /// <param name="memorySharp">The reference of the <see cref="MemoryManagement.MemorySharp" /> object.</param>
        /// <param name="thread">The native <see cref="ProcessThread" /> object.</param>
        /// <param name="parameter">The parameter passed to the thread when it was created.</param>
        internal WindowsRemoteThread(MemorySharp memorySharp, ProcessThread thread, IMarshalledValue parameter = null) :
            base(memorySharp, thread, parameter)
        {
        }
        #endregion Constructor/Destructor

        #region Methods
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
                    throw new InvalidEnumArgumentException(nameof(segment), (int) segment, typeof(SegmentRegisters));
            }

            // Compute the linear address
            return new IntPtr(entry.BaseLow | (entry.BaseMid << 16) | (entry.BaseHi << 24));
        }
        #endregion GetRealSegmentAddress
        #endregion Methods
    }
}