using System;
using System.ComponentModel;
using Binarysharp.MemoryManagement.Native;

namespace Binarysharp.MemoryManagement.Helpers
{
    /// <summary>
    /// An helper class that determines the architecture of a process.
    /// </summary>
    public static class ArchitectureDetector
    {
        /// <summary>
        /// Determines whether a target is 64-bit process.
        /// </summary>
        /// <param name="handle">The handle of the process.</param>
        /// <returns><c>true</c> if the target is a 64-bit process, <c>false</c> otherwise.</returns>
        /// <exception cref="Win32Exception">The architecture of the process cannot be determined.</exception>
        public static bool Is64Process(SafeMemoryHandle handle)
        {
            // If the operating system is not 64-bit, it's unlikely that a 64-bit process is running!
            if (!Environment.Is64BitOperatingSystem) return false;

            // Determine whether the target process is using the emulator WoW64 (i.e. is a 32-bit process on a 64-bit operating system)
            if (NativeMethods.IsWow64Process(handle, out var isWow64) != 0) return isWow64 == 0;

            throw new Win32Exception("The architecture of the process cannot be determined.");
        }
    }
}