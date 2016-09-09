using System;

namespace Binarysharp.MemoryManagement.Patterns
{
    /// <summary>
    /// Class representing a pattern scan result.
    /// </summary>
    public class PatternScanResult
    {
        /// <summary>
        /// Gets or sets the read address.
        /// </summary>
        /// <value>
        /// The read address.
        /// </value>
        public IntPtr RebasedAddress { get; set; }

        /// <summary>
        /// Gets or sets the base address.
        /// </summary>
        /// <value>
        /// The base address.
        /// </value>
        public IntPtr BaseAddress { get; set; }

        /// <summary>
        /// Gets or sets the offset the pattern was found at.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PatternScanResult"/> was a success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool ScanWasSuccessful { get; set; }

        /// <summary>
        /// Gets the invalid.
        /// </summary>
        /// <value>
        /// The invalid.
        /// </value>
        public static PatternScanResult Invalid => new PatternScanResult
        {
            BaseAddress = IntPtr.Zero,
            Offset = 0,
            RebasedAddress = IntPtr.Zero,
            ScanWasSuccessful = false
        };
    }
}