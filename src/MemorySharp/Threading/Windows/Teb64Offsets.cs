namespace Binarysharp.MemoryManagement.Threading.Windows
{
    /// <summary>
    /// The offsets of the thread environment block for 64-bit processes.
    /// </summary>
    /// <remarks>
    /// The definition of the TEB has been found on the terminus project:
    /// http://terminus.rewolf.pl/terminus/structures/ntdll/_TEB_combined.html.
    /// </remarks>
    /// <seealso cref="ITebOffsets" />
    public class Teb64Offsets : ITebOffsets
    {
        public int ExceptionList => 0;
        public int StackBase => 0x8;
        public int StackLimit => 0x10;
        public int SubSystemTeb => 0x18;
        public int FiberData => 0x20;
        public int Version => 0x20;
        public int ArbitraryUserPointer => 0x28;
        public int TebAddress => 0x30;
        public int EnvironmentPointer => 0x38;
        public int ProcessId => 0x40;
        public int ThreadId => 0x48;
        public int ActiveRcpHandle => 0x50;
        public int ThreadLocalStoragePointer => 0x58;
        public int PebPointer => 0x60;
        public int LastErrorValue => 0x68;
        public int CountOfOwnedCriticalSections => 0x6c;
        public int CsrClientThread => 0x70;
        public int Win32ThreadInfo => 0x78;
        public int CurrentLocale => 0x108;
        public int FpSoftwareStatusRegister => 0x10c;
        public int ExceptionCode => 0x2c0;
        public int RealProcessId => 0x7d8;
        public int RealThreadId => 0x7e0;
        public int GdiCachedProcessHandle => 0x7e8;
        public int GdiClientProcessId => 0x7f0;
        public int GdiClientThreadId => 0x7f4;
        public int GdiThreadLocalInfo => 0x7f8;
        public int GlSectionInfo => 0x1228;
        public int GlSection => 0x1230;
        public int GlTable => 0x1238;
        public int GlCurrentRc => 0x1240;
        public int GlContext => 0x1248;
        public int LastStatusValue => 0x1250;
        public int DeallocationStack => 0x1478;
        public int TlsSlots => 0x1480;
        public int TlsFLink => 0x1680;
        public int TlsBLink => 0x1688;
        public int Vdm => 0x1690;
        public int WinSockData => 0x1738;
        public int GdiBatchCount => 0x1740;
        public int IdealProcessor => 0x1747;
        public int WaitingOnLoaderLock => 0x1760;
        public int TlsExpansionSlots => 0x1780;
        public int IsImpersonating => 0x179c;
        public int NlsCache => 0x17a0;
        public int ShimData => 0x17a8;
        public int CurrentTransactionHandle => 0x17b8;
        public int ActiveFramePointer => 0x17c0;
    }
}
