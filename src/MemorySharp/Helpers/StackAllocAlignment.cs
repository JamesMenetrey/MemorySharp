using System;

namespace Binarysharp.MemoryManagement.Helpers
{
    /// <summary>
    /// Provides an allocator that is able to control the alignment of a structure in memory, such as DECLSPEC_ALIGN in C/C++.
    /// This guarantees that the address of the structure in memory is congruent to zero modulo the alignment.
    /// A couple of native functions require that input structures must be aligned with a power of two.
    /// </summary>
    /// <remarks>
    /// Internally, a chunk of memory is allocated on the stack with the size of the alignment plus the size og the structure.
    /// The alignment is then computed using a modulus and a pointer on the aligned address is reinterpreted as the structure.
    /// </remarks>
    public static class StackAllocAlignment
    {
        /// <summary>
        /// A delegate that behaves similarly to <see cref="Action{T}" /> and requires that the type parameter is an unmanaged type.
        /// The parameter is passed by reference.
        /// </summary>
        /// <typeparam name="T">The type of an unmanaged structure.</typeparam>
        /// <param name="unmanagedStruct">An unmanaged structure.</param>
        public delegate void RefAction<T>(ref T unmanagedStruct) where T : unmanaged;

        /// <summary>
        /// Allocates a structure of a given unmanaged type on the stack, with a specified alignment.
        /// </summary>
        /// <typeparam name="T">The type parameter of the structure to allocate and aligned on the stack.</typeparam>
        /// <param name="alignment">The alignment of the structure.</param>
        /// <param name="action">The callback where the aligned structure is passed.</param>
        /// <remarks>The structure can only be used in the callback. Any usage of it outside of that scope manipulate a freed memory.</remarks>
        public static unsafe void Allocate<T>(int alignment, RefAction<T> action)
            where T : unmanaged
        {
            // The worst case is that the alignment is only possible after the alignment value itself
            var memoryToAllocate = alignment + sizeof(T) - 1;

            // Allocate the memory on the stack
            var memory = stackalloc byte[memoryToAllocate];

            // Determine the offset between the allocated address and the aligned address
            var offset = (long)memory & alignment - 1;

            // If there is an offset, relocate the pointer to the aligned address
            if (offset != 0) memory += alignment - offset;

            // Perform some black magic pointer manipulations..
            // No just kidding, reinterpret the aligned memory address as the structure,
            // the ref keywords are here to prevent the structure ot be copied, as a structure
            // assignment is equal to a copy in C#.
            ref var s = ref *(T*)memory;

            // Call the callback with the aligned structure
            action(ref s);
        }
    }
}