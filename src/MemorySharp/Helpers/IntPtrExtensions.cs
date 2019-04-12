using System;

namespace Binarysharp.MemoryManagement.Helpers
{
    /// <summary>
    /// Extensions methods for <see cref="IntPtr"/>. This avoids to cast the pointer type to a size
    /// that is dependent to the architecture of the operating system architecture.
    /// </summary>
    public static class IntPtrExtensions
    {
        /// <summary>
        /// Adds a given offset to a pointer.
        /// </summary>
        /// <param name="pointer">The pointer where the offset is added.</param>
        /// <param name="offset">The offset to add.</param>
        /// <returns>The return value is a new instance of the class <see cref="IntPtr"/>.</returns>
        public static IntPtr Add(this IntPtr pointer, IntPtr offset)
        {
            return new IntPtr(pointer.ToValue() + offset.ToValue());
        }

        /// <summary>
        /// Indicates whether the value of the pointer is greater or equal to another one.
        /// </summary>
        /// <param name="pointer">The first pointer to compare.</param>
        /// <param name="other">The second pointer to compare.</param>
        /// <returns>If the first pointer is greater or equal to the second one, the return value is <c>true</c>, 
        /// otherwise the return value is <c>false</c>.</returns>
        public static bool IsGreaterOrEqualThan(this IntPtr pointer, IntPtr other)
        {
            return pointer.ToValue() >= other.ToValue();
        }

        /// <summary>
        /// Indicates whether the value of the pointer is greater to another one.
        /// </summary>
        /// <param name="pointer">The first pointer to compare.</param>
        /// <param name="other">The second pointer to compare.</param>
        /// <returns>If the first pointer is greater to the second one, the return value is <c>true</c>, 
        /// otherwise the return value is <c>false</c>.</returns>
        public static bool IsGreaterThan(this IntPtr pointer, IntPtr other)
        {
            return pointer.ToValue() > other.ToValue();
        }

        /// <summary>
        /// Indicates whether the value of the pointer is smaller to another one.
        /// </summary>
        /// <param name="pointer">The first pointer to compare.</param>
        /// <param name="other">The second pointer to compare.</param>
        /// <returns>If the first pointer is smaller to the second one, the return value is <c>true</c>, 
        /// otherwise the return value is <c>false</c>.</returns>
        public static bool IsSmallerThan(this IntPtr pointer, IntPtr other)
        {
            return !IsGreaterOrEqualThan(pointer, other);
        }

        /// <summary>
        /// Converts a given pointer to a value that can be stored in a register of the architecture of the running process.
        /// </summary>
        /// <param name="pointer">The pointer to convert.</param>
        /// <returns>The return value is a numeric value that can be stored in a processor register.</returns>
        /// <remarks>
        /// This method has been made private, so the user of the extensions methods don't have to consider to use the right
        /// underlying type of the pointer.
        /// </remarks>
        private static long ToValue(this IntPtr pointer)
        {
            return pointer.ToInt64();
        }
    }
}