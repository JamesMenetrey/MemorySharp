using System;

namespace Binarysharp.MemoryManagement.Threading.Windows
{
    public interface Teb
    {
        /// <summary>
        /// The Structured Exception Handling (SEH) frame.
        /// </summary>
        IntPtr ExceptionList { get; set; }

        /// <summary>
        /// The top of the stack.
        /// </summary>
        IntPtr StackBase { get; set; }

        /// <summary>
        /// The bottom of the stack.
        /// </summary>
        IntPtr StackLimit { get; set; }

        /// <summary>
        /// The thread environment block (TEB) subsystem.
        /// </summary>
        IntPtr SubSystemTeb { get; set; }

        /// <summary>
        /// The fiber data.
        /// </summary>
        IntPtr FiberData { get; set; }

        IntPtr Version { get; set; }

        /// <summary>
        /// The arbitrary data slot.
        /// </summary>
        IntPtr ArbitraryUserPointer { get; set; }

        /// <summary>
        /// The linear address of the thread environment block (TEB).
        /// </summary>
        IntPtr TebAddress { get; set; }

        /// <summary>
        /// The environment pointer.
        /// </summary>
        IntPtr EnvironmentPointer { get; set; }

        /// <summary>
        /// The process identifier, also called UniqueProcess.
        /// </summary>
        IntPtr ProcessId { get; set; }

        /// <summary>
        /// The thread identifier, also called UniqueThread.
        /// </summary>
        IntPtr ThreadId { get; set; }

        /// <summary>
        /// The active RPC handle.
        /// </summary>
        IntPtr ActiveRcpHandle { get; set; }

        /// <summary>
        /// The linear address of the thread-local storage (TLS) array.
        /// </summary>
        IntPtr ThreadLocalStoragePointer { get; set; }

        /// <summary>
        /// The linear address of the process environment block (PEB).
        /// </summary>
        IntPtr Peb { get; set; }

        /// <summary>
        /// The last error value.
        /// </summary>
        uint LastErrorValue { get; set; }

        /// <summary>
        /// The count of owned critical sections.
        /// </summary>
        uint CountOfOwnedCriticalSections { get; set; }
        /// <summary>
        /// The address of CSR client thread.
        /// </summary>
        IntPtr CsrClientThread { get; set; }
        /// <summary>
        /// The Win32 thread information.
        /// </summary>
        IntPtr Win32ThreadInfo { get; set; }
        /// <summary>
        /// The current locale.
        /// </summary>
        uint CurrentLocale { get; set; }
        /// <summary>
        /// The FP software status register.
        /// </summary>
        uint FpSoftwareStatusRegister { get; set; }

        /// <summary>
        /// The exception code.
        /// </summary>
        uint ExceptionCode { get; set; }

        /// <summary>
        /// The real process identifier, also called RealUniqueProcess.
        /// </summary>
        IntPtr RealProcessId { get; set; }

        /// <summary>
        /// The real thread identifier, also called RealUniqueThread.
        /// </summary>
        IntPtr RealThreadId { get; set; }
        /// <summary>
        /// The GDI cached process handle.
        /// </summary>
        IntPtr GdiCachedProcessHandle { get; set; }
        /// <summary>
        /// The GDI client process identifier (PID).
        /// </summary>
        uint GdiClientProcessId { get; set; }
        /// <summary>
        /// The GDI client thread identifier (TID).
        /// </summary>
        uint GdiClientThreadId { get; set; }
        /// <summary>
        /// The GDI thread locale information.
        /// </summary>
        IntPtr GdiThreadLocalInfo { get; set; }
        /// <summary>
        /// The GL section information.
        /// </summary>
        IntPtr GlSectionInfo { get; set; }
        /// <summary>
        /// The GL section.
        /// </summary>
        IntPtr GlSection { get; set; }
        /// <summary>
        /// The GL table.
        /// </summary>
        IntPtr GlTable { get; set; }
        IntPtr GlCurrentRc { get; set; }
        /// <summary>
        /// The GL context.
        /// </summary>
        IntPtr GlContext { get; set; }
        /// <summary>
        /// The last status value.
        /// </summary>
        uint LastStatusValue { get; set; }
        /// <summary>
        /// The address of the deallocation stack.
        /// </summary>
        IntPtr DeallocationStack { get; set; }
        /// <summary>
        /// The thread-local storage (TLS) slots.
        /// </summary>
        IntPtr[] TlsSlots { get; set; }
        /// <summary>
        /// The thread-local storage (TLS) link (first pointer of the structure LIST_ENTRY).
        /// </summary>
        IntPtr TlsFLink { get; set; }
        /// <summary>
        /// The thread-local storage (TLS) link (second pointer of the structure LIST_ENTRY).
        /// </summary>
        IntPtr TlsBLink { get; set; }
        /// <summary>
        /// The virtual DOS machine.
        /// </summary>
        IntPtr Vdm { get; set; }
        /// <summary>
        /// The Winsock data.
        /// </summary>
        IntPtr WinSockData { get; set; }
        /// <summary>
        /// The GDI batch count.
        /// </summary>
        uint GdiBatchCount { get; set; }
        /// <summary>
        /// The preferred processor for the thread, used when the system schedules threads, 
        /// to determine which processor to run the thread on.
        /// </summary>
        byte IdealProcessor { get; set; }
        uint WaitingOnLoaderLock { get; set; }
        /// <summary>
        /// The double pointer (void**) thread-local storage (TLS) expansion slots.
        /// </summary>
        IntPtr TlsExpansionSlots { get; set; }
        /// <summary>
        /// The NLS cache.
        /// </summary>
        IntPtr NlsCache { get; set; }
        /// <summary>
        /// The shim data.
        /// </summary>
        IntPtr ShimData { get; set; }
        /// <summary>
        /// The current transaction handle.
        /// </summary>
        IntPtr CurrentTransactionHandle { get; set; }
        /// <summary>
        /// The pointer of the active frame.
        /// </summary>
        IntPtr ActiveFrame { get; set; }
    }
}
