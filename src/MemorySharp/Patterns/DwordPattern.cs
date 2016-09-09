using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Binarysharp.MemoryManagement.Patterns
{
    /// <summary>
    /// Class that represents a DWORD based pattern to search for.
    /// </summary>
    /// <seealso cref="Binarysharp.MemoryManagement.Patterns.IMemoryPattern" />
    public class DwordPattern : IMemoryPattern
    {
        private byte[] _bytes;
        private string _mask;


        /// <summary>
        /// Gets the pattern text that should be parsed. Example: 5D ?? ?? ?? ?? 5E 5S
        /// </summary>
        /// <value>
        /// The pattern text.
        /// </value>
        public string PatternText { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DwordPattern"/> class.
        /// </summary>
        /// <param name="dwordPattern">The dword pattern text.</param>
        public DwordPattern(string dwordPattern)
        {
            PatternText = dwordPattern;
            PatternType = MemoryPatternType.Function;
            Offset = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DwordPattern"/> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="offset">The offset to add to the pattern scan result (eg result + offset + offset from found offset).</param>
        public DwordPattern(string pattern, int offset)
        {
            PatternText = pattern;
            PatternType = MemoryPatternType.Data;
            Offset = offset;
        }

        /// <summary>
        /// Gets the patterns bytes. IList is used in order to allow an index to be used.
        /// </summary>
        /// <returns></returns>
        public virtual IList<byte> GetBytes()
        {
            return _bytes ?? (_bytes = GetBytesFromDwordPattern(PatternText));
        }

        /// <summary>
        /// Gets the mask to patch the pattern against.
        /// </summary>
        /// <returns></returns>
        public virtual string GetMask()
        {
            return _mask ?? (_mask = GetMaskFromDwordPattern(PatternText));
        }

        /// <summary>
        /// Gets the offset. [Often zero in the case of function pointer patterns for example]
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        public int Offset { get; }

        /// <summary>
        /// Gets the type of the pattern, e.g function or data pointer patterns.
        /// </summary>
        /// <value>
        /// The type of the pattern.
        /// </value>
        public MemoryPatternType PatternType { get; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return PatternText;
        }

        private static string GetMaskFromDwordPattern(string pattern)
        {
            var mask = pattern.Split(' ').Select(s => s.Contains('?') ? "?" : "x");

            return string.Concat(mask);
        }


        private static byte[] GetBytesFromDwordPattern(string pattern)
        {
            return
                pattern.Split(' ')
                    .Select(s => s.Contains('?') ? (byte)0 : byte.Parse(s, NumberStyles.HexNumber))
                    .ToArray();
        }
    }
}