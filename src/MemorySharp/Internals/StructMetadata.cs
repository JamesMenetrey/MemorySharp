using Binarysharp.MemoryManagement.Native;

namespace Binarysharp.MemoryManagement.Internals
{
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
}