namespace Binarysharp.MemoryManagement.Threading.Windows
{
    /// <summary>
    /// The offsets of the thread environment block for 32-bit processes.
    /// </summary>
    /// <remarks>
    /// The definition of the TEB has been found on the terminus project:
    /// http://terminus.rewolf.pl/terminus/structures/ntdll/_TEB_combined.html.
    /// </remarks>
    /// <seealso cref="ITebOffsets" />
    internal class Teb32Offsets : ITebOffsets
    {
        public int ExceptionList => 0;
        public int StackBase => 0x4;
        public int StackLimit => 0x8;
        public int SubSystemTeb => 0xC;
        public int FiberData => 0x10;
        public int Version => 0x10;
        public int ArbitraryUserPointer => 0x14;
        public int TebAddress => 0x18;
        public int EnvironmentPointer => 0x1c;
        public int ProcessId => 0x20;
        public int ThreadId => 0x24;
        public int ActiveRcpHandle => 0x28;
        public int ThreadLocalStoragePointer => 0x2c;
        public int PebPointer => 0x30;
        public int LastErrorValue => 0x34;
        public int CountOfOwnedCriticalSections => 0x38;
        public int CsrClientThread => 0x3c;
        public int Win32ThreadInfo => 0x40;
        public int CurrentLocale => 0xc4;
        public int FpSoftwareStatusRegister => 0xc8;
        public int ExceptionCode => 0x1a4;
        public int RealProcessId => 0x6b4;
        public int RealThreadId => 0x6b8;
        public int GdiCachedProcessHandle => 0x6bc;
        public int GdiClientProcessId => 0x6c0;
        public int GdiClientThreadId => 0x6c4;
        public int GdiThreadLocalInfo => 0x6c8;
        public int GlSectionInfo => 0xbe0;
        public int GlSection => 0xbe4;
        public int GlTable => 0xbe8;
        public int GlCurrentRc => 0xbec;
        public int GlContext => 0xbf0;
        public int LastStatusValue => 0xbf4;
        public int DeallocationStack => 0xe0c;
        public int TlsSlots => 0xe10;
        public int TlsFLink => 0xf10;
        public int TlsBLink => 0xf14;
        public int Vdm => 0xf18;
        public int WinSockData => 0xf6c;
        public int GdiBatchCount => 0xf70;
        public int IdealProcessor => 0xf77;
        public int WaitingOnLoaderLock => 0xf84;
        public int TlsExpansionSlots => 0xf94;
        public int IsImpersonating => 0xf9c;
        public int NlsCache => 0xfa0;
        public int ShimData => 0xfa4;
        public int CurrentTransactionHandle => 0xfac;
        public int ActiveFramePointer => 0xfb0;
    }
}
