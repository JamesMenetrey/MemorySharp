namespace MemorySharpTests.Patterns
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class PatternScannerTest
    {
        /* Example to add testing... need a file with a pattern that wont change 
         private static void Main(string[] args)
        {
            var process = System.Diagnostics.Process.GetProcessesByName("Wow-64").FirstOrDefault();

            var memorySharp = new Binarysharp.MemoryManagement.MemorySharp(process);

            var patternScanner = memorySharp.Modules.MainModule.GetPatternScanner();



            var scanResult =
                patternScanner.Find(
                    new Binarysharp.MemoryManagement.Patterns.DwordPattern(
                      "48 89 74 24 ?? 57 48 83 EC 20 48 8B 05 ?? ?? ?? ?? 48 8B F1 48 8B FA 48 8B 88 ?? ?? ?? ?? F6 C1 01 75 05 48 85 C9 75 02"));

            if (scanResult.ScanWasSuccessful)
            {
                Console.WriteLine("Could not find pattern.");
            }

            Console.WriteLine(scanResult.Offset.ToString("X"));
            Console.WriteLine(scanResult.BaseAddress.ToString("X"));
            Console.WriteLine(scanResult.RebasedAddress.ToString("X"));
 
            Console.ReadLine();
        }*/
    }
}
