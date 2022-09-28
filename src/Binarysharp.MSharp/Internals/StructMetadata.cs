using Binarysharp.MSharp.Native;

namespace Binarysharp.MSharp.Internals
{
    /// <summary>
    /// Stores the offsets of the structure of the <see cref="M128AMetaData"/>.
    /// </summary>
    internal static class M128AMetaData
    {
        public const int TotalSize = sizeof(ulong) + sizeof(long);

        internal static class Offsets
        {
            public const int Low = 0;
            public const int High = Low + sizeof(ulong);
        }
    }

    /// <summary>
    /// Stores the offsets of the structure of the <see cref="ThreadContext32"/> (for 32-bit processes on Windows).
    /// </summary>
    internal static class ThreadContext32Metadata
    {
        /// <summary>
        /// The size of <see cref="ThreadContext32"/>.
        /// </summary>
        public const int TotalSize = Offsets.ExtendedRegisters + Sizes.ExtendedRegistersSize;

        internal static class Offsets
        {
            public const int ContextFlags = 0;
            public const int Dr0 = ContextFlags + sizeof(ThreadContextFlags);
            public const int Dr1 = Dr0 + sizeof(uint);
            public const int Dr2 = Dr1 + sizeof(uint);
            public const int Dr3 = Dr2 + sizeof(uint);
            public const int Dr6 = Dr3 + sizeof(uint);
            public const int Dr7 = Dr6 + sizeof(uint);
            public const int ControlWord = Dr7 + sizeof(uint);
            public const int StatusWord = ControlWord + sizeof(uint);
            public const int TagWord = StatusWord + sizeof(uint);
            public const int ErrorOffset = TagWord + sizeof(uint);
            public const int ErrorSelector = ErrorOffset + sizeof(uint);
            public const int DataOffset = ErrorSelector + sizeof(uint);
            public const int DataSelector = DataOffset + sizeof(uint);
            public const int RegisterArea = DataSelector + sizeof(uint);
            public const int Cr0NpxState = RegisterArea + Sizes.RegisterAreaSize;
            public const int SegGs = Cr0NpxState + sizeof(uint);
            public const int SegFs = SegGs + sizeof(uint);
            public const int SegEs = SegFs + sizeof(uint);
            public const int SegDs = SegEs + sizeof(uint);
            public const int Edi = SegDs + sizeof(uint);
            public const int Esi = Edi + sizeof(uint);
            public const int Ebx = Esi + sizeof(uint);
            public const int Edx = Ebx + sizeof(uint);
            public const int Ecx = Edx + sizeof(uint);
            public const int Eax = Ecx + sizeof(uint);
            public const int Ebp = Eax + sizeof(uint);
            public const int Eip = Ebp + sizeof(uint);
            public const int SegCs = Eip + sizeof(uint);
            public const int EFlags = SegCs + sizeof(uint);
            public const int Esp = EFlags + sizeof(uint);
            public const int SegSs = Esp + sizeof(uint);
            public const int ExtendedRegisters = SegSs + sizeof(uint);
        }

        internal static class Sizes
        {
            public const int RegisterAreaSize = 80;
            public const int ExtendedRegistersSize = 512;
        }
    }

    /// <summary>
    /// Stores the offsets of the structure of the <see cref="ThreadContext64"/> (for 64-bit processes on Windows).
    /// </summary>
    internal static class ThreadContext64Metadata
    {
        public const int TotalSize = Offsets.LastExceptionFromRip + sizeof(ulong);

        internal static class Offsets
        {
            public const int P1Home = 0;
            public const int P2Home = P1Home + sizeof(ulong);
            public const int P3Home = P2Home + sizeof(ulong);
            public const int P4Home = P3Home + sizeof(ulong);
            public const int P5Home = P4Home + sizeof(ulong);
            public const int P6Home = P5Home + sizeof(ulong);
            public const int ContextFlags = P6Home + sizeof(ulong);
            public const int MxCsr = ContextFlags + sizeof(uint);
            public const int SegCs = MxCsr + sizeof(uint);
            public const int SegDs = SegCs + sizeof(ushort);
            public const int SegEs = SegDs + sizeof(ushort);
            public const int SegFs = SegEs + sizeof(ushort);
            public const int SegGs = SegFs + sizeof(ushort);
            public const int SegSs = SegGs + sizeof(ushort);
            public const int EFlags = SegSs + sizeof(ushort);
            public const int Dr0 = EFlags + sizeof(uint);
            public const int Dr1 = Dr0 + sizeof(ulong);
            public const int Dr2 = Dr1 + sizeof(ulong);
            public const int Dr3 = Dr2 + sizeof(ulong);
            public const int Dr6 = Dr3 + sizeof(ulong);
            public const int Dr7 = Dr6 + sizeof(ulong);
            public const int Rax = Dr7 + sizeof(ulong);
            public const int Rcx = Rax + sizeof(ulong);
            public const int Rdx = Rcx + sizeof(ulong);
            public const int Rbx = Rdx + sizeof(ulong);
            public const int Rsp = Rbx + sizeof(ulong);
            public const int Rbp = Rsp + sizeof(ulong);
            public const int Rsi = Rbp + sizeof(ulong);
            public const int Rdi = Rsi + sizeof(ulong);
            public const int R8 = Rdi + sizeof(ulong);
            public const int R9 = R8 + sizeof(ulong);
            public const int R10 = R9 + sizeof(ulong);
            public const int R11 = R10 + sizeof(ulong);
            public const int R12 = R11 + sizeof(ulong);
            public const int R13 = R12 + sizeof(ulong);
            public const int R14 = R13 + sizeof(ulong);
            public const int R15 = R14 + sizeof(ulong);
            public const int Rip = R15 + sizeof(ulong);
            public const int Header = Rip + sizeof(ulong);
            public const int Legacy = Header + Sizes.Header;
            public const int Xmm0 = Legacy + Sizes.Legacy;
            public const int Xmm1 = Xmm0 + M128AMetaData.TotalSize;
            public const int Xmm2 = Xmm1 + M128AMetaData.TotalSize;
            public const int Xmm3 = Xmm2 + M128AMetaData.TotalSize;
            public const int Xmm4 = Xmm3 + M128AMetaData.TotalSize;
            public const int Xmm5 = Xmm4 + M128AMetaData.TotalSize;
            public const int Xmm6 = Xmm5 + M128AMetaData.TotalSize;
            public const int Xmm7 = Xmm6 + M128AMetaData.TotalSize;
            public const int Xmm8 = Xmm7 + M128AMetaData.TotalSize;
            public const int Xmm9 = Xmm8 + M128AMetaData.TotalSize;
            public const int Xmm10 = Xmm9 + M128AMetaData.TotalSize;
            public const int Xmm11 = Xmm10 + M128AMetaData.TotalSize;
            public const int Xmm12 = Xmm11 + M128AMetaData.TotalSize;
            public const int Xmm13 = Xmm12 + M128AMetaData.TotalSize;
            public const int Xmm14 = Xmm13 + M128AMetaData.TotalSize;
            public const int Xmm15 = Xmm14 + M128AMetaData.TotalSize;
            public const int VectorRegister = Xmm15 + M128AMetaData.TotalSize + Sizes.Reserved4;
            public const int VectorControl = VectorRegister + Sizes.VectorRegister;
            public const int DebugControl = VectorControl + sizeof(ulong);
            public const int LastBranchToRip = DebugControl + sizeof(ulong);
            public const int LastBranchFromRip = LastBranchToRip + sizeof(ulong);
            public const int LastExceptionToRip = LastBranchFromRip + sizeof(ulong);
            public const int LastExceptionFromRip = LastExceptionToRip + sizeof(ulong);
        }

        internal static class Sizes
        {
            /// <summary>
            /// M128A[2].
            /// </summary>
            public const int Header = 2 * M128AMetaData.TotalSize;

            /// <summary>
            /// M128A[8].
            /// </summary>
            public const int Legacy = 8 * M128AMetaData.TotalSize;

            /// <summary>
            /// A reserved buffer identified as Reserved4 in WinNT.h.
            /// </summary>
            public const int Reserved4 = 96;

            /// <summary>
            /// M128A[26].
            /// </summary>
            public const int VectorRegister = 26 * M128AMetaData.TotalSize;
        }
    }
}