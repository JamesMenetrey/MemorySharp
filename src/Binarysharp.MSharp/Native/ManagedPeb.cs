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
using Binarysharp.MSharp.Memory.Windows;

namespace Binarysharp.MSharp.Native
{
    /// <summary>
    /// Class representing the Process Environment Block of a remote process.
    /// </summary>
    public class ManagedPeb : RemotePointer
    {
        #region Fields
        /// <summary>
        /// The offsets of the process environment block for a given architecture.
        /// </summary>
        private readonly IPebOffsets _offsets;
        #endregion Fields

        #region Properties
        public byte InheritedAddressSpace
        {
            get => Read<byte>(_offsets.InheritedAddressSpace);
            set => Write(_offsets.InheritedAddressSpace, value);
        }

        public byte ReadImageFileExecOptions
        {
            get => Read<byte>(_offsets.ReadImageFileExecOptions);
            set => Write(_offsets.ReadImageFileExecOptions, value);
        }

        public byte BeingDebugged
        {
            get => Read<byte>(_offsets.BeingDebugged);
            set => Write(_offsets.BeingDebugged, value);
        }

        public IntPtr Mutant
        {
            get => Read<IntPtr>(_offsets.Mutant);
            set => Write(_offsets.Mutant, value);
        }

        public IntPtr ImageBaseAddress
        {
            get => Read<IntPtr>(_offsets.ImageBaseAddress);
            set => Write(_offsets.ImageBaseAddress, value);
        }

        public IntPtr Ldr
        {
            get => Read<IntPtr>(_offsets.Ldr);
            set => Write(_offsets.Ldr, value);
        }

        public IntPtr ProcessParameters
        {
            get => Read<IntPtr>(_offsets.ProcessParameters);
            set => Write(_offsets.ProcessParameters, value);
        }

        public IntPtr SubSystemData
        {
            get => Read<IntPtr>(_offsets.SubSystemData);
            set => Write(_offsets.SubSystemData, value);
        }

        public IntPtr ProcessHeap
        {
            get => Read<IntPtr>(_offsets.ProcessHeap);
            set => Write(_offsets.ProcessHeap, value);
        }

        public IntPtr FastPebLock
        {
            get => Read<IntPtr>(_offsets.FastPebLock);
            set => Write(_offsets.FastPebLock, value);
        }

        public uint TlsExpansionCounter
        {
            get => Read<uint>(_offsets.TlsExpansionCounter);
            set => Write(_offsets.TlsExpansionCounter, value);
        }

        public IntPtr TlsBitmap
        {
            get => Read<IntPtr>(_offsets.TlsBitmap);
            set => Write(_offsets.TlsBitmap, value);
        }

        public long TlsBitmapBits
        {
            get => Read<long>(_offsets.TlsBitmapBits);
            set => Write(_offsets.TlsBitmapBits, value);
        }

        public IntPtr ReadOnlySharedMemoryBase
        {
            get => Read<IntPtr>(_offsets.ReadOnlySharedMemoryBase);
            set => Write(_offsets.ReadOnlySharedMemoryBase, value);
        }

        public IntPtr ReadOnlyStaticServerData
        {
            get => Read<IntPtr>(_offsets.ReadOnlyStaticServerData);
            set => Write(_offsets.ReadOnlyStaticServerData, value);
        }

        public IntPtr AnsiCodePageData
        {
            get => Read<IntPtr>(_offsets.AnsiCodePageData);
            set => Write(_offsets.AnsiCodePageData, value);
        }

        public IntPtr OemCodePageData
        {
            get => Read<IntPtr>(_offsets.OemCodePageData);
            set => Write(_offsets.OemCodePageData, value);
        }

        public IntPtr UnicodeCaseTableData
        {
            get => Read<IntPtr>(_offsets.UnicodeCaseTableData);
            set => Write(_offsets.UnicodeCaseTableData, value);
        }

        public uint NumberOfProcessors
        {
            get => Read<uint>(_offsets.NumberOfProcessors);
            set => Write(_offsets.NumberOfProcessors, value);
        }

        public uint NtGlobalFlag
        {
            get => Read<uint>(_offsets.NtGlobalFlag);
            set => Write(_offsets.NtGlobalFlag, value);
        }

        public long CriticalSectionTimeout
        {
            get => Read<long>(_offsets.CriticalSectionTimeout);
            set => Write(_offsets.CriticalSectionTimeout, value);
        }

        public IntPtr HeapSegmentReserve
        {
            get => Read<IntPtr>(_offsets.HeapSegmentReserve);
            set => Write(_offsets.HeapSegmentReserve, value);
        }

        public IntPtr HeapSegmentCommit
        {
            get => Read<IntPtr>(_offsets.HeapSegmentCommit);
            set => Write(_offsets.HeapSegmentCommit, value);
        }

        public IntPtr HeapDeCommitTotalFreeThreshold
        {
            get => Read<IntPtr>(_offsets.HeapDeCommitTotalFreeThreshold);
            set => Write(_offsets.HeapDeCommitTotalFreeThreshold, value);
        }

        public IntPtr HeapDeCommitFreeBlockThreshold
        {
            get => Read<IntPtr>(_offsets.HeapDeCommitFreeBlockThreshold);
            set => Write(_offsets.HeapDeCommitFreeBlockThreshold, value);
        }

        public uint NumberOfHeaps
        {
            get => Read<uint>(_offsets.NumberOfHeaps);
            set => Write(_offsets.NumberOfHeaps, value);
        }

        public uint MaximumNumberOfHeaps
        {
            get => Read<uint>(_offsets.MaximumNumberOfHeaps);
            set => Write(_offsets.MaximumNumberOfHeaps, value);
        }

        public IntPtr ProcessHeaps
        {
            get => Read<IntPtr>(_offsets.ProcessHeaps);
            set => Write(_offsets.ProcessHeaps, value);
        }

        public IntPtr GdiSharedHandleTable
        {
            get => Read<IntPtr>(_offsets.GdiSharedHandleTable);
            set => Write(_offsets.GdiSharedHandleTable, value);
        }

        public IntPtr ProcessStarterHelper
        {
            get => Read<IntPtr>(_offsets.ProcessStarterHelper);
            set => Write(_offsets.ProcessStarterHelper, value);
        }

        public uint GdiDcAttributeList
        {
            get => Read<uint>(_offsets.GdiDcAttributeList);
            set => Write(_offsets.GdiDcAttributeList, value);
        }

        public uint OsMajorVersion
        {
            get => Read<uint>(_offsets.OsMajorVersion);
            set => Write(_offsets.OsMajorVersion, value);
        }

        public uint OsMinorVersion
        {
            get => Read<uint>(_offsets.OsMinorVersion);
            set => Write(_offsets.OsMinorVersion, value);
        }

        public ushort OsBuildNumber
        {
            get => Read<ushort>(_offsets.OsBuildNumber);
            set => Write(_offsets.OsBuildNumber, value);
        }

        public ushort OsCsdVersion
        {
            get => Read<ushort>(_offsets.OsCsdVersion);
            set => Write(_offsets.OsCsdVersion, value);
        }

        public uint OsPlatformId
        {
            get => Read<uint>(_offsets.OsPlatformId);
            set => Write(_offsets.OsPlatformId, value);
        }

        public uint ImageSubsystem
        {
            get => Read<uint>(_offsets.ImageSubsystem);
            set => Write(_offsets.ImageSubsystem, value);
        }

        public uint ImageSubsystemMajorVersion
        {
            get => Read<uint>(_offsets.ImageSubsystemMajorVersion);
            set => Write(_offsets.ImageSubsystemMajorVersion, value);
        }

        public uint ImageSubsystemMinorVersion
        {
            get => Read<uint>(_offsets.ImageSubsystemMinorVersion);
            set => Write(_offsets.ImageSubsystemMinorVersion, value);
        }

        public uint[] GdiHandleBuffer
        {
            get => Read<uint>(_offsets.GdiHandleBuffer, _offsets.GdiHandleBufferSize);
            set => Write(_offsets.GdiHandleBuffer, value);
        }

        public IntPtr PostProcessInitRoutine
        {
            get => Read<IntPtr>(_offsets.PostProcessInitRoutine);
            set => Write(_offsets.PostProcessInitRoutine, value);
        }

        public IntPtr TlsExpansionBitmap
        {
            get => Read<IntPtr>(_offsets.TlsExpansionBitmap);
            set => Write(_offsets.TlsExpansionBitmap, value);
        }

        public uint[] TlsExpansionBitmapBits
        {
            get => Read<uint>(_offsets.TlsExpansionBitmapBits, _offsets.TlsExpansionBitmapBitsSize);
            set => Write(_offsets.TlsExpansionBitmapBits, value);
        }

        public uint SessionId
        {
            get => Read<uint>(_offsets.SessionId);
            set => Write(_offsets.SessionId, value);
        }

        public long AppCompatFlags
        {
            get => Read<long>(_offsets.AppCompatFlags);
            set => Write(_offsets.AppCompatFlags, value);
        }

        public long AppCompatFlagsUser
        {
            get => Read<long>(_offsets.AppCompatFlagsUser);
            set => Write(_offsets.AppCompatFlagsUser, value);
        }

        public IntPtr ShimData
        {
            get => Read<IntPtr>(_offsets.ShimData);
            set => Write(_offsets.ShimData, value);
        }

        public IntPtr AppCompatInfo
        {
            get => Read<IntPtr>(_offsets.AppCompatInfo);
            set => Write(_offsets.AppCompatInfo, value);
        }

        public ushort CsdVersionLength
        {
            get => Read<ushort>(_offsets.CsdVersionLength);
            set => Write(_offsets.CsdVersionLength, value);
        }

        public ushort CsdVersionMaxLength
        {
            get => Read<ushort>(_offsets.CsdVersionMaxLength);
            set => Write(_offsets.CsdVersionMaxLength, value);
        }

        public IntPtr CsdVersionBuffer
        {
            get => Read<IntPtr>(_offsets.CsdVersionBuffer);
            set => Write(_offsets.CsdVersionBuffer, value);
        }

        public IntPtr MinimumStackCommit
        {
            get => Read<IntPtr>(_offsets.MinimumStackCommit);
            set => Write(_offsets.MinimumStackCommit, value);
        }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedPeb" /> class.
        /// </summary>
        /// <param name="memorySharp">The reference of the <see cref="MemorySharp" /> object.</param>
        internal ManagedPeb(MemorySharp memorySharp) : base(memorySharp, FindPeb(memorySharp.Handle))
        {
            _offsets = memorySharp.Is64Process
                ? (IPebOffsets) Singleton<Peb64Offsets>.Instance
                : Singleton<Peb32Offsets>.Instance;
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// Finds the Process Environment Block address of a specified process.
        /// </summary>
        /// <param name="processHandle">A handle of the process.</param>
        /// <returns>A <see cref="IntPtr" /> pointer of the PEB.</returns>
        public static IntPtr FindPeb(SafeMemoryHandle processHandle)
        {
            return MemoryCore.NtQueryInformationProcess(processHandle).PebBaseAddress;
        }
        #endregion Methods
    }
}