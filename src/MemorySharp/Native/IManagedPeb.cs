using System;

namespace Binarysharp.MemoryManagement.Native
{
    public interface IManagedPeb
    {
        IntPtr ActivationContextData { get; set; }
        IntPtr AnsiCodePageData { get; set; }
        long AppCompatFlags { get; set; }
        long AppCompatFlagsUser { get; set; }
        IntPtr AppCompatInfo { get; set; }
        int AtlThunkSListPtr32 { get; set; }
        bool BeingDebugged { get; set; }
        long CriticalSectionTimeout { get; set; }
        long CsdVersion { get; set; }
        IntPtr EnvironmentUpdateCount { get; set; }
        IntPtr FastPebLock { get; set; }
        IntPtr FastPebLockRoutine { get; set; }
        IntPtr FastPebUnlockRoutine { get; set; }
        IntPtr FreeList { get; set; }
        IntPtr GdiDcAttributeList { get; set; }
        IntPtr[] GdiHandleBuffer { get; set; }
        IntPtr GdiSharedHandleTable { get; set; }
        IntPtr HeapDeCommitFreeBlockThreshold { get; set; }
        IntPtr HeapDeCommitTotalFreeThreshold { get; set; }
        IntPtr HeapSegmentCommit { get; set; }
        IntPtr HeapSegmentReserve { get; set; }
        IntPtr ImageProcessAffinityMask { get; set; }
        int ImageSubsystem { get; set; }
        int ImageSubsystemMajorVersion { get; set; }
        IntPtr ImageSubsystemMinorVersion { get; set; }
        byte InheritedAddressSpace { get; set; }
        IntPtr KernelCallbackTable { get; set; }
        IntPtr Ldr { get; set; }
        IntPtr LoaderLock { get; set; }
        int MaximumNumberOfHeaps { get; set; }
        IntPtr MinimumStackCommit { get; set; }
        IntPtr Mutant { get; set; }
        long NtGlobalFlag { get; set; }
        int NumberOfHeaps { get; set; }
        int NumberOfProcessors { get; set; }
        IntPtr OemCodePageData { get; set; }
        ushort OsBuildNumber { get; set; }
        ushort OsCsdVersion { get; set; }
        int OsMajorVersion { get; set; }
        int OsMinorVersion { get; set; }
        int OsPlatformId { get; set; }
        IntPtr PostProcessInitRoutine { get; set; }
        IntPtr ProcessAssemblyStorageMap { get; set; }
        IntPtr ProcessHeap { get; set; }
        IntPtr ProcessHeaps { get; set; }
        IntPtr ProcessParameters { get; set; }
        IntPtr ProcessStarterHelper { get; set; }
        byte ReadImageFileExecOptions { get; set; }
        IntPtr ReadOnlySharedMemoryBase { get; set; }
        IntPtr ReadOnlySharedMemoryHeap { get; set; }
        IntPtr ReadOnlyStaticServerData { get; set; }
        IntPtr SessionId { get; set; }
        IntPtr ShimData { get; set; }
        byte SpareBool { get; set; }
        IntPtr SubSystemData { get; set; }
        IntPtr SystemAssemblyStorageMap { get; set; }
        IntPtr SystemDefaultActivationContextData { get; set; }
        int SystemReserved { get; set; }
        IntPtr TlsBitmap { get; set; }
        long TlsBitmapBits { get; set; }
        IntPtr TlsExpansionBitmap { get; set; }
        IntPtr[] TlsExpansionBitmapBits { get; set; }
        IntPtr TlsExpansionCounter { get; set; }
        IntPtr UnicodeCaseTableData { get; set; }
    }
}