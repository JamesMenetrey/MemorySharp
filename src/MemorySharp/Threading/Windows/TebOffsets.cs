namespace Binarysharp.MemoryManagement.Threading.Windows
{
    internal interface TebOffsets
    {
        int ExceptionList { get; }
        int StackBase { get; }
        int StackLimit { get; }
        int SubSystemTeb { get; }
        int FiberData { get; }

        int Version { get; }
        int ArbitraryUserPointer { get; }
        int TebAddress { get; }
        int EnvironmentPointer { get; }
        int ProcessId { get; }
        int ThreadId { get; }
        int ActiveRcpHandle { get; }
        int ThreadLocalStoragePointer { get; }
        int PebPointer { get; }
        int LastErrorValue { get; }
        int CountOfOwnedCriticalSections { get; }
        int CsrClientThread { get; }
        int Win32ThreadInfo { get; }
        int CurrentLocale { get; }
        int FpSoftwareStatusRegister { get; }
        int ExceptionCode { get; }
        int RealProcessId { get; }
        int RealThreadId { get; }
        int GdiCachedProcessHandle { get; }
        int GdiClientProcessId { get; }
        int GdiClientThreadId { get; }
        int GdiThreadLocalInfo { get; }
        int GlSectionInfo { get; }
        int GlSection { get; }
        int GlTable { get; }
        int GlCurrentRc { get; }
        int GlContext { get; }
        int LastStatusValue { get; }
        int DeallocationStack { get; }
        int TlsSlots { get; }
        int TlsFLink { get; }
        int TlsBLink { get; }
        int Vdm { get; }
        int WinSockData { get; }
        int GdiBatchCount { get; }
        int IdealProcessor { get; }
        int WaitingOnLoaderLock { get; }
        int TlsExpansionSlots { get; }
        int IsImpersonating { get; }
        int NlsCache { get; }
        int ShimData { get; }
        int CurrentTransactionHandle { get; }
        int ActiveFramePointer { get; }
    }
}
