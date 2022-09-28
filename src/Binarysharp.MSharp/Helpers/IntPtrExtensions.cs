using System.Runtime.CompilerServices;

namespace Binarysharp.MSharp.Helpers
{
    /// <summary>
    /// Extensions methods for <see cref="IntPtr"/>, in order to prevent to cast pointer to an architecture dependent size.
    /// </summary>
    public static class IntPtrExtensions
    {
        /// <summary>
        /// Adds a given offset to a pointer.
        /// </summary>
        /// <param name="pointer">The pointer where the offset is added.</param>
        /// <param name="offset">The offset to add.</param>
        /// <returns>The return value is a new instance of the class <see cref="IntPtr"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe IntPtr Add(this IntPtr pointer, IntPtr offset)
        {
            return new IntPtr((void*)(pointer.ToInt64() + offset.ToInt64()));
        }

        /// <summary>
        /// Determines whether two given pointers are equal.
        /// </summary>
        /// <param name="pointer">The left pointer.</param>
        /// <param name="value">The right pointer.</param>
        /// <returns>The return value is <c>true</c> if the two pointers are equal; otherwise <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsEqual(this IntPtr pointer, int value)
        {
            return (void*)pointer == (void*)value;
        }

        /// <summary>
        /// Indicates whether the value of the pointer is greater or equal to another one.
        /// </summary>
        /// <param name="pointer">The first pointer to compare.</param>
        /// <param name="other">The second pointer to compare.</param>
        /// <returns>If the first pointer is greater or equal to the second one, the return value is <c>true</c>, 
        /// otherwise the return value is <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsGreaterOrEqualThan(this IntPtr pointer, IntPtr other)
        {
            return (void*)pointer >= (void*)other;
        }

        /// <summary>
        /// Indicates whether the value of the pointer is greater to another one.
        /// </summary>
        /// <param name="pointer">The first pointer to compare.</param>
        /// <param name="other">The second pointer to compare.</param>
        /// <returns>If the first pointer is greater to the second one, the return value is <c>true</c>, 
        /// otherwise the return value is <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsGreaterThan(this IntPtr pointer, IntPtr other)
        {
            return (void*)pointer > (void*)other;
        }

        /// <summary>
        /// Indicates whether the value of the pointer is smaller to another one.
        /// </summary>
        /// <param name="pointer">The first pointer to compare.</param>
        /// <param name="other">The second pointer to compare.</param>
        /// <returns>If the first pointer is smaller to the second one, the return value is <c>true</c>, 
        /// otherwise the return value is <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsSmallerThan(this IntPtr pointer, IntPtr other)
        {
            return (void*)pointer < (void*)other;
        }
    }
}