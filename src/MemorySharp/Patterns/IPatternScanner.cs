namespace Binarysharp.MemoryManagement.Patterns
{
    /// <summary>
    /// Interface that defines a basic pattern scanner.
    /// </summary>
    public interface IPatternScanner
    {
        /// <summary>
        /// Finds the specified pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        PatternScanResult Find(IMemoryPattern pattern);
    }
}