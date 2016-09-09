using System.Collections.Generic;

namespace Binarysharp.MemoryManagement.Patterns
{
    /// <summary>
    /// Interface that defines a basic memory pattern.
    /// </summary>
    public interface IMemoryPattern
    {
        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        int Offset { get; }
        /// <summary>
        /// Gets the type of the pattern.
        /// </summary>
        /// <value>
        /// The type of the pattern.
        /// </value>
        MemoryPatternType PatternType { get; }
        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <returns></returns>
        IList<byte> GetBytes();
        /// <summary>
        /// Gets the mask.
        /// </summary>
        /// <returns></returns>
        string GetMask();
    }
}