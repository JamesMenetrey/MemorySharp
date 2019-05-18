using Binarysharp.MemoryManagement.Native;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;

namespace MemorySharpTests.Native
{
    /// <summary>
    /// The unit tests in this class ensure that some structures are blittable for performance purposes.
    /// </summary>
    /// <remarks>
    /// The types are tested with the suggestion in the best practices of Microsoft:
    /// https://docs.microsoft.com/en-us/dotnet/standard/native-interop/best-practices#blittable-types
    /// </remarks>
    [TestClass]
    public class BlittableTypesTests
    {
        private bool IsBlittableRelated(ArgumentException e) =>
            e.Message.IndexOf("blittable", StringComparison.OrdinalIgnoreCase) > -1;

        [TestMethod]
        public void EnsureThreadContext32IsBlittable()
        {
            try
            {
                GCHandle.Alloc(new ThreadContext32(), GCHandleType.Pinned);
            }
            catch (ArgumentException e) when (IsBlittableRelated(e))
            {
                Assert.Fail("The structure is no longer blittable, which causes performance penalties when marshaled.");
            }
        }
    }
}