namespace Binarysharp.MSharp.Memory.Windows
{
    internal interface IPebOffsets
    {
        int InheritedAddressSpace { get; }
        int ReadImageFileExecOptions { get; }
        int BeingDebugged { get; }
        int Mutant { get; }
        int ImageBaseAddress { get; }
        int Ldr { get; }
        int ProcessParameters { get; }
        int SubSystemData { get; }
        int ProcessHeap { get; }
        int FastPebLock { get; }
        int TlsExpansionCounter { get; }
        int TlsBitmap { get; }
        int TlsBitmapBits { get; }
        int ReadOnlySharedMemoryBase { get; }
        int ReadOnlyStaticServerData { get; }
        int AnsiCodePageData { get; }
        int OemCodePageData { get; }
        int UnicodeCaseTableData { get; }
        int NumberOfProcessors { get; }
        int NtGlobalFlag { get; }
        int CriticalSectionTimeout { get; }
        int HeapSegmentReserve { get; }
        int HeapSegmentCommit { get; }
        int HeapDeCommitTotalFreeThreshold { get; }
        int HeapDeCommitFreeBlockThreshold { get; }
        int NumberOfHeaps { get; }
        int MaximumNumberOfHeaps { get; }
        int ProcessHeaps { get; }
        int GdiSharedHandleTable { get; }
        int ProcessStarterHelper { get; }
        int GdiDcAttributeList { get; }
        int OsMajorVersion { get; }
        int OsMinorVersion { get; }
        int OsBuildNumber { get; }
        int OsCsdVersion { get; }
        int OsPlatformId { get; }
        int ImageSubsystem { get; }
        int ImageSubsystemMajorVersion { get; }
        int ImageSubsystemMinorVersion { get; }
        int GdiHandleBuffer { get; }
        int PostProcessInitRoutine { get; }
        int TlsExpansionBitmap { get; }
        int TlsExpansionBitmapBits { get; }
        int SessionId { get; }
        int AppCompatFlags { get; }
        int AppCompatFlagsUser { get; }
        int ShimData { get; }
        int AppCompatInfo { get; }
        int CsdVersionLength { get; }
        int CsdVersionMaxLength { get; }
        int CsdVersionBuffer { get; }
        int MinimumStackCommit { get; }

        #region Sizes
        int GdiHandleBufferSize { get; }
        int TlsExpansionBitmapBitsSize { get; }
        #endregion Sizes
    }
}