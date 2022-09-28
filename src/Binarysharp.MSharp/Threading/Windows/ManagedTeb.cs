/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/

using Binarysharp.MSharp.Helpers;
using Binarysharp.MSharp.Memory;
using Binarysharp.MSharp.Native;

namespace Binarysharp.MSharp.Threading.Windows
{
    /// <summary>
    /// Class representing the Thread Environment Block of a remote thread.
    /// </summary>
    public class ManagedTeb : RemotePointer
    {
        #region Fields
        /// <summary>
        /// The offsets of the thread environment block for a given architecture.
        /// </summary>
        private readonly ITebOffsets _offsets;
        #endregion Fields

        #region Properties
        /// <summary>
        /// Gets the Structured Exception Handling (SEH) frame.
        /// </summary>
        public IntPtr ExceptionList
        {
            get => Read<IntPtr>(_offsets.ExceptionList);
            set => Write(_offsets.ExceptionList, value);
        }

        /// <summary>
        /// Gets the top of stack.
        /// </summary>
        public IntPtr StackBase
        {
            get => Read<IntPtr>(_offsets.StackBase);
            set => Write(_offsets.StackBase, value);
        }

        /// <summary>
        /// Gets the bottom of stack.
        /// </summary>
        public IntPtr StackLimit
        {
            get => Read<IntPtr>(_offsets.StackLimit);
            set => Write(_offsets.StackLimit, value);
        }

        /// <summary>
        /// Gets the thread environment block (TEB) subsystem.
        /// </summary>
        public IntPtr SubSystemTeb
        {
            get => Read<IntPtr>(_offsets.SubSystemTeb);
            set => Write(_offsets.SubSystemTeb, value);
        }

        /// <summary>
        /// Gets the fiber data.
        /// </summary>
        public IntPtr FiberData
        {
            get => Read<IntPtr>(_offsets.FiberData);
            set => Write(_offsets.FiberData, value);
        }

        public IntPtr Version
        {
            get => Read<IntPtr>(_offsets.Version);
            set => Write(_offsets.Version, value);
        }

        /// <summary>
        /// Gets the arbitrary data slot.
        /// </summary>
        public IntPtr ArbitraryUserPointer
        {
            get => Read<IntPtr>(_offsets.ArbitraryUserPointer);
            set => Write(_offsets.ArbitraryUserPointer, value);
        }

        /// <summary>
        /// Gets the linear address of the thread environment block (TEB).
        /// </summary>
        public IntPtr TebAddress
        {
            get => Read<IntPtr>(_offsets.TebAddress);
            set => Write(_offsets.TebAddress, value);
        }

        /// <summary>
        /// Gets the environment pointer.
        /// </summary>
        public IntPtr EnvironmentPointer
        {
            get => Read<IntPtr>(_offsets.EnvironmentPointer);
            set => Write(_offsets.EnvironmentPointer, value);
        }

        /// <summary>
        /// Gets the process identifier, also called UniqueProcess.
        /// </summary>
        public IntPtr ProcessId
        {
            get => Read<IntPtr>(_offsets.ProcessId);
            set => Write(_offsets.ProcessId, value);
        }

        /// <summary>
        /// Gets the thread identifier, also called UniqueThread.
        /// </summary>
        public IntPtr ThreadId
        {
            get => Read<IntPtr>(_offsets.ThreadId);
            set => Write(_offsets.ThreadId, value);
        }

        /// <summary>
        /// Gets the active RPC handle.
        /// </summary>
        public IntPtr RpcHandle
        {
            get => Read<IntPtr>(_offsets.ActiveRcpHandle);
            set => Write(_offsets.ActiveRcpHandle, value);
        }

        /// <summary>
        /// Gets the linear address of the thread-local storage (TLS) array.
        /// </summary>
        public IntPtr ThreadLocalStoragePointer
        {
            get => Read<IntPtr>(_offsets.ThreadLocalStoragePointer);
            set => Write(_offsets.ThreadLocalStoragePointer, value);
        }

        /// <summary>
        /// Gets the linear address of the process environment block (PEB).
        /// </summary>
        public IntPtr PebPointer
        {
            get => Read<IntPtr>(_offsets.PebPointer);
            set => Write(_offsets.PebPointer, value);
        }

        /// <summary>
        /// Gets the last error value.
        /// </summary>
        public uint LastErrorValue
        {
            get => Read<uint>(_offsets.LastErrorValue);
            set => Write(_offsets.LastErrorValue, value);
        }

        /// <summary>
        /// Gets the count of owned critical sections.
        /// </summary>
        public uint CountOfOwnedCriticalSections
        {
            get => Read<uint>(_offsets.CountOfOwnedCriticalSections);
            set => Write(_offsets.CountOfOwnedCriticalSections, value);
        }

        /// <summary>
        /// Gets the address of CSR client thread.
        /// </summary>
        public IntPtr CsrClientThread
        {
            get => Read<IntPtr>(_offsets.CsrClientThread);
            set => Write(_offsets.CsrClientThread, value);
        }

        /// <summary>
        /// Gets the Win32 thread information.
        /// </summary>
        public IntPtr Win32ThreadInfo
        {
            get => Read<IntPtr>(_offsets.Win32ThreadInfo);
            set => Write(_offsets.Win32ThreadInfo, value);
        }

        /// <summary>
        /// Gets the current locale.
        /// </summary>
        public uint CurrentLocale
        {
            get => Read<uint>(_offsets.CurrentLocale);
            set => Write(_offsets.CurrentLocale, value);
        }

        /// <summary>
        /// Gets the FP software status register.
        /// </summary>
        public uint FpSoftwareStatusRegister
        {
            get => Read<uint>(_offsets.FpSoftwareStatusRegister);
            set => Write(_offsets.FpSoftwareStatusRegister, value);
        }

        /// <summary>
        /// Gets the exception code.
        /// </summary>
        public uint ExceptionCode
        {
            get => Read<uint>(_offsets.ExceptionCode);
            set => Write(_offsets.ExceptionCode, value);
        }

        /// <summary>
        /// Gets the real process identifier, also called RealUniqueProcess.
        /// </summary>
        public IntPtr RealProcessId
        {
            get => Read<IntPtr>(_offsets.RealProcessId);
            set => Write(_offsets.RealProcessId, value);
        }

        /// <summary>
        /// Gets the real thread identifier, also called RealUniqueThread.
        /// </summary>
        public IntPtr RealThreadId
        {
            get => Read<IntPtr>(_offsets.RealThreadId);
            set => Write(_offsets.RealThreadId, value);
        }

        /// <summary>
        /// Gets the GDI cached process handle.
        /// </summary>
        public IntPtr GdiCachedProcessHandle
        {
            get => Read<IntPtr>(_offsets.GdiCachedProcessHandle);
            set => Write(_offsets.GdiCachedProcessHandle, value);
        }

        /// <summary>
        /// Gets the GDI client process identifier (PID).
        /// </summary>
        public uint GdiClientProcessId
        {
            get => Read<uint>(_offsets.GdiClientProcessId);
            set => Write(_offsets.GdiClientProcessId, value);
        }

        /// <summary>
        /// Gets the GDI client thread identifier (TID).
        /// </summary>
        public uint GdiClientThreadId
        {
            get => Read<uint>(_offsets.GdiClientThreadId);
            set => Write(_offsets.GdiClientThreadId, value);
        }

        /// <summary>
        /// Gets the GDI thread locale information.
        /// </summary>
        public IntPtr GdiThreadLocalInfo
        {
            get => Read<IntPtr>(_offsets.GdiThreadLocalInfo);
            set => Write(_offsets.GdiThreadLocalInfo, value);
        }

        /// <summary>
        /// Gets the GL section information.
        /// </summary>
        public IntPtr GlSectionInfo
        {
            get => Read<IntPtr>(_offsets.GlSectionInfo);
            set => Write(_offsets.GlSectionInfo, value);
        }

        /// <summary>
        /// Gets the GL section.
        /// </summary>
        public IntPtr GlSection
        {
            get => Read<IntPtr>(_offsets.GlSection);
            set => Write(_offsets.GlSection, value);
        }

        /// <summary>
        /// Gets the GL table.
        /// </summary>
        public IntPtr GlTable
        {
            get => Read<IntPtr>(_offsets.GlTable);
            set => Write(_offsets.GlTable, value);
        }

        public IntPtr GlCurrentRc
        {
            get => Read<IntPtr>(_offsets.GlCurrentRc);
            set => Write(_offsets.GlCurrentRc, value);
        }

        /// <summary>
        /// Gets the GL context.
        /// </summary>
        public IntPtr GlContext
        {
            get => Read<IntPtr>(_offsets.GlContext);
            set => Write(_offsets.GlContext, value);
        }

        /// <summary>
        /// Gets the last status value.
        /// </summary>
        public uint LastStatusValue
        {
            get => Read<uint>(_offsets.LastStatusValue);
            set => Write(_offsets.LastStatusValue, value);
        }

        /// <summary>
        /// Gets the address of the deallocation stack.
        /// </summary>
        public IntPtr DeallocationStack
        {
            get => Read<IntPtr>(_offsets.DeallocationStack);
            set => Write(_offsets.DeallocationStack, value);
        }

        /// <summary>
        /// Gets the thread-local storage (TLS) slots.
        /// They are an array of pointers (void*[]) for the TLS values.
        /// </summary>
        public IntPtr[] TlsSlots
        {
            get => Read<IntPtr[]>(_offsets.TlsSlots);
            set => Write(_offsets.TlsSlots, value);
        }

        /// <summary>
        /// Gets the thread-local storage (TLS) link (first pointer of the structure LIST_ENTRY).
        /// </summary>
        public IntPtr TlsFLink
        {
            get => Read<IntPtr>(_offsets.TlsFLink);
            set => Write(_offsets.TlsFLink, value);
        }

        /// <summary>
        /// Gets the thread-local storage (TLS) link (second pointer of the structure LIST_ENTRY).
        /// </summary>
        public IntPtr TlsBLink
        {
            get => Read<IntPtr>(_offsets.TlsBLink);
            set => Write(_offsets.TlsBLink, value);
        }

        /// <summary>
        /// Gets the virtual DOS machine.
        /// </summary>
        public IntPtr Vdm
        {
            get => Read<IntPtr>(_offsets.TlsFLink);
            set => Write(_offsets.TlsFLink, value);
        }

        /// <summary>
        /// Gets the Winsock data.
        /// </summary>
        public IntPtr WinSockData
        {
            get => Read<IntPtr>(_offsets.TlsFLink);
            set => Write(_offsets.TlsFLink, value);
        }

        /// <summary>
        /// Gets the GDI batch count.
        /// </summary>
        public uint GdiBatchCount
        {
            get => Read<uint>(_offsets.TlsFLink);
            set => Write(_offsets.TlsFLink, value);
        }

        /// <summary>
        /// Gets the preferred processor for the thread, used when the system schedules threads,
        /// to determine which processor to run the thread on.
        /// </summary>
        public byte IdealProcessor
        {
            get => Read<byte>(_offsets.IdealProcessor);
            set => Write(_offsets.IdealProcessor, value);
        }

        public uint WaitingOnLoaderLock
        {
            get => Read<uint>(_offsets.WaitingOnLoaderLock);
            set => Write(_offsets.WaitingOnLoaderLock, value);
        }

        /// <summary>
        /// Gets the double pointer (void**) thread-local storage (TLS) expansion slots.
        /// </summary>
        public IntPtr TlsExpansionSlots
        {
            get => Read<IntPtr>(_offsets.TlsExpansionSlots);
            set => Write(_offsets.TlsExpansionSlots, value);
        }

        /// <summary>
        /// Indicates whether the thread is impersonating.
        /// </summary>
        public IntPtr IsIsmpersonating
        {
            get => Read<IntPtr>(_offsets.IsImpersonating);
            set => Write(_offsets.IsImpersonating, value);
        }

        /// <summary>
        /// Gets the NLS cache.
        /// </summary>
        public IntPtr NlsCache
        {
            get => Read<IntPtr>(_offsets.NlsCache);
            set => Write(_offsets.NlsCache, value);
        }

        /// <summary>
        /// Gets the shim data.
        /// </summary>
        public IntPtr ShimData
        {
            get => Read<IntPtr>(_offsets.ShimData);
            set => Write(_offsets.ShimData, value);
        }

        /// <summary>
        /// Gets the current transaction handle.
        /// </summary>
        public IntPtr CurrentTransactionHandle
        {
            get => Read<IntPtr>(_offsets.CurrentTransactionHandle);
            set => Write(_offsets.CurrentTransactionHandle, value);
        }

        /// <summary>
        /// Gets the pointer of the active frame.
        /// </summary>
        public IntPtr ActiveFramePointer
        {
            get => Read<IntPtr>(_offsets.ActiveFramePointer);
            set => Write(_offsets.ActiveFramePointer, value);
        }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedTeb" /> class.
        /// </summary>
        /// <param name="memorySharp">The reference of the <see cref="MemorySharp" /> object.</param>
        /// <param name="thread">The thread that owns the thread environment block.</param>
        internal ManagedTeb(MemorySharp memorySharp, RemoteThread thread)
            : base(memorySharp, FindTeb(thread.Handle))
        {
            _offsets = memorySharp.Is64Process
                ? (ITebOffsets) Singleton<Teb64Offsets>.Instance
                : Singleton<Teb32Offsets>.Instance;
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// Finds the Thread Environment Block address of a specified thread.
        /// </summary>
        /// <param name="threadHandle">A handle of the thread.</param>
        /// <returns>A <see cref="IntPtr" /> pointer of the TEB.</returns>
        private static IntPtr FindTeb(SafeMemoryHandle threadHandle)
        {
            return ThreadCore.NtQueryInformationThread(threadHandle).TebBaseAddress;
        }
        #endregion Methods
    }
}