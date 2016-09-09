using System;
using System.Linq;

namespace Binarysharp.MemoryManagement.Patterns
{
    /// <summary>
    /// A basic pattern scanner.
    /// </summary>
    /// <seealso cref="Binarysharp.MemoryManagement.Patterns.IPatternScanner" />
    public class PatternScanner : IPatternScanner
    {
        /// <summary>
        /// The module
        /// </summary>
        private readonly Modules.RemoteModule _module;
        /// <summary>
        /// The data
        /// </summary>
        private byte[] _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatternScanner"/> class.
        /// </summary>
        /// <param name="module">The module.</param>
        public PatternScanner(Modules.RemoteModule module)
        {
            _module = module;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public byte[] Data => _data ?? (_data = Memory.MemoryCore.ReadBytes(_module.MemorySharp.Handle, _module.BaseAddress, _module.Size));

        /// <summary>
        /// Finds the specified pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public PatternScanResult Find(IMemoryPattern pattern)
        {
            return pattern.PatternType == MemoryPatternType.Function
                ? FindFunctionPattern(pattern)
                : FindDataPattern(pattern);
        }

        /// <summary>
        /// Finds the function pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        private PatternScanResult FindFunctionPattern(IMemoryPattern pattern)
        {
            var data = Data;
            var bytes = pattern.GetBytes();
            var mask = pattern.GetMask();
            var length = Data.Length;

            for (var offset = 0; offset < length; offset++)
            {
                if (mask.Where((m, b) => m == 'x' && bytes[b] != data[b + offset]).Any())
                {
                    continue;
                }
                // If this area is reached, the pattern has been found.
                return new PatternScanResult
                {
                    BaseAddress = (IntPtr)offset,
                    RebasedAddress = _module.BaseAddress + offset,
                    Offset = offset,
                    ScanWasSuccessful = true
                };
            }
            return PatternScanResult.Invalid;
        }

        /// <summary>
        /// Finds the data pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        private PatternScanResult FindDataPattern(IMemoryPattern pattern)
        {
            var data = Data;
            var bytes = pattern.GetBytes();
            var mask = pattern.GetMask();
            var length = Data.Length;

            for (var offset = 0; offset < length; offset++)
            {
                if (mask.Where((m, b) => m == 'x' && bytes[b] != data[b + offset]).Any())
                {
                    continue;
                }
                // If this area is reached, the pattern has been found.
                var found = _module.Read<IntPtr>(offset + pattern.Offset);
                return  new PatternScanResult
                {
                    ScanWasSuccessful = true,
                    RebasedAddress = found,
                    BaseAddress = new IntPtr(found.ToInt64() - _module.BaseAddress.ToInt64()),
                    Offset = offset
                };
            }

            return PatternScanResult.Invalid;
        }
    }
}