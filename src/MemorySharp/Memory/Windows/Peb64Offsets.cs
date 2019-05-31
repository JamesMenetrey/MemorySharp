namespace Binarysharp.MemoryManagement.Memory.Windows
{
    /// <summary>
    /// The offsets of the process environment block for 64-bit processes.
    /// </summary>
    /// <remarks>
    /// The definition of the PREB has been found on the terminus project:
    /// http://terminus.rewolf.pl/terminus/structures/ntdll/_PEB_combined.html.
    /// </remarks>
    internal class Peb64Offsets : PebOffsets
    {
        public int InheritedAddressSpace => 0x0;
        public int ReadImageFileExecOptions => 0x1;
        public int BeingDebugged => 0x2;
        public int Mutant => 0x8;
        public int ImageBaseAddress => 0x10;
        public int Ldr => 0x18;
        public int ProcessParameters => 0x20;
        public int SubSystemData => 0x28;
        public int ProcessHeap => 0x30;
        public int FastPebLock => 0x38;
        public int TlsExpansionCounter => 0x70;
        public int TlsBitmap => 0x78;
        public int TlsBitmapBits => 0x80;
        public int ReadOnlySharedMemoryBase => 0x88;
        public int ReadOnlyStaticServerData => 0x98;
        public int AnsiCodePageData => 0xa0;
        public int OemCodePageData => 0xa8;
        public int UnicodeCaseTableData => 0xb0;
        public int NumberOfProcessors => 0xb8;
        public int NtGlobalFlag => 0xbc;
        public int CriticalSectionTimeout => 0xc0;
        public int HeapSegmentReserve => 0xc8;
        public int HeapSegmentCommit => 0xd0;
        public int HeapDeCommitTotalFreeThreshold => 0xd8;
        public int HeapDeCommitFreeBlockThreshold => 0xe0;
        public int NumberOfHeaps => 0xe8;
        public int MaximumNumberOfHeaps => 0xec;
        public int ProcessHeaps => 0xf0;
        public int GdiSharedHandleTable => 0xf8;
        public int ProcessStarterHelper => 0x100;
        public int GdiDcAttributeList => 0x108;
        public int OsMajorVersion => 0x118;
        public int OsMinorVersion => 0x11c;
        public int OsBuildNumber => 0x120;
        public int OsCsdVersion => 0x122;
        public int OsPlatformId => 0x124;
        public int ImageSubsystem => 0x128;
        public int ImageSubsystemMajorVersion => 0x12c;
        public int ImageSubsystemMinorVersion => 0x130;
        public int GdiHandleBuffer => 0x140;
        public int PostProcessInitRoutine => 0x230;
        public int TlsExpansionBitmap => 0x238;
        public int TlsExpansionBitmapBits => 0x240;
        public int SessionId => 0x2c0;
        public int AppCompatFlags => 0x2c8;
        public int AppCompatFlagsUser => 0x2d0;
        public int ShimData => 0x2d8;
        public int AppCompatInfo => 0x2e0;
        public int CsdVersionLength => 0x2e8;
        public int CsdVersionMaxLength => 0x2ea;
        public int CsdVersionBuffer => 0x2f0;
        public int MinimumStackCommit => 0x318;

        // Sizes
        public int GdiHandleBufferSize => 60;

        public int TlsExpansionBitmapBitsSize => 32;
    }
}