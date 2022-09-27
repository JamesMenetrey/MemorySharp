using System;
using Binarysharp.MemoryManagement.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySharpTests.Helpers
{
    [TestClass]
    public class IntPtrExtensionsTests
    {
        private const int ValueLeft = 3;
        private const int ValueRight = 5;
        private readonly IntPtr _intPtrLeft = new IntPtr(ValueLeft);
        private readonly IntPtr _intPtrRight = new IntPtr(ValueRight);
        private readonly unsafe void* _ptrLeft = (void*)ValueLeft;
        private readonly unsafe void* _ptrRight = (void*)ValueRight;

        [TestMethod]
        public void AddAndCheckSum()
        {
            // Act
            var result = _intPtrLeft.Add(_intPtrRight);
            
            // Assert
            Assert.AreEqual(new IntPtr(ValueLeft + ValueRight), result);
        }
    }
}
