using System;
using Binarysharp.MemoryManagement.Helpers;
using Binarysharp.MemoryManagement.Native;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySharpTests.Helpers
{
    [TestClass]
    public class ArchitectureDetectorTests
    {
        /// <summary>
        /// Determines whether the target process is 64-bit.
        /// </summary>
        [TestMethod]
        public void Is64Process_ShouldMatchArchitectureOfTestProject()
        {
            // Arrange
            var handle = Resources.ProcessTest.Handle;

            // Act
            var is64TestProcess = ArchitectureDetector.Is64Process(new SafeMemoryHandle(handle));
            var is64SelfProcess = IntPtr.Size == 8;

            // Assert
            Assert.AreEqual(is64SelfProcess, is64TestProcess);
        }
    }
}