namespace Binarysharp.MemoryManagement.Memory.Windows
{
    /// <summary>
    /// The offsets of the process environment block for 32-bit processes.
    /// </summary>
    /// <remarks>
    /// The definition of the PREB has been found on the terminus project:
    /// http://terminus.rewolf.pl/terminus/structures/ntdll/_PEB_combined.html.
    /// </remarks>
    internal class Peb32Offsets : IPebOffsets
    {
        public int InheritedAddressSpace => 0;
        public int ReadImageFileExecOptions => 0x1;
        public int BeingDebugged => 0x2;
        public int Mutant => 0x4;
        public int ImageBaseAddress => 0x8;
        public int Ldr => 0xc;
        public int ProcessParameters => 0x10;
        public int SubSystemData => 0x14;
        public int ProcessHeap => 0x18;
        public int FastPebLock => 0x1c;
        public int TlsExpansionCounter => 0x3c;
        public int TlsBitmap => 0x40;
        public int TlsBitmapBits => 0x44;
        public int ReadOnlySharedMemoryBase => 0x4c;
        public int ReadOnlyStaticServerData => 0x54;
        public int AnsiCodePageData => 0x58;
        public int OemCodePageData => 0x5c;
        public int UnicodeCaseTableData => 0x60;
        public int NumberOfProcessors => 0x64;
        public int NtGlobalFlag => 0x68;
        public int CriticalSectionTimeout => 0x70;
        public int HeapSegmentReserve => 0x78;
        public int HeapSegmentCommit => 0x7c;
        public int HeapDeCommitTotalFreeThreshold => 0x80;
        public int HeapDeCommitFreeBlockThreshold => 0x84;
        public int NumberOfHeaps => 0x88;
        public int MaximumNumberOfHeaps => 0x8c;
        public int ProcessHeaps => 0x90;
        public int GdiSharedHandleTable => 0x94;
        public int ProcessStarterHelper => 0x98;
        public int GdiDcAttributeList => 0x9c;
        public int OsMajorVersion => 0xa4;
        public int OsMinorVersion => 0xa8;
        public int OsBuildNumber => 0xac;
        public int OsCsdVersion => 0xae;
        public int OsPlatformId => 0xb0;
        public int ImageSubsystem => 0xb4;
        public int ImageSubsystemMajorVersion => 0xb8;
        public int ImageSubsystemMinorVersion => 0xbc;
        public int GdiHandleBuffer => 0xc4;
        public int PostProcessInitRoutine => 0x14c;
        public int TlsExpansionBitmap => 0x150;
        public int TlsExpansionBitmapBits => 0x154;
        public int SessionId => 0x1d4;
        public int AppCompatFlags => 0x1d8;
        public int AppCompatFlagsUser => 0x1e0;
        public int ShimData => 0x1e8;
        public int AppCompatInfo => 0x1ec;
        public int CsdVersionLength => 0x1f0;
        public int CsdVersionMaxLength => 0x1f2;
        public int CsdVersionBuffer => 0x1f4;
        public int MinimumStackCommit => 0x208;

        // Sizes
        public int GdiHandleBufferSize => 34;

        public int TlsExpansionBitmapBitsSize => 32;
    }
}