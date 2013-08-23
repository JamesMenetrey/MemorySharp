/*
 * This file is part of MemorySharp.
 * Copyright (C) 2012-2013 Jämes Ménétrey (a.k.a. ZenLulz).
 * <http://www.binarysharp.com/> <zenlulz@binarysharp.com>
 * 
 * This library is licensed under the GNU GPLv3 License.
 * See the file LICENSE for more information.
*/

using System;
using Binarysharp.MemoryManagement.Internals;
using Binarysharp.MemoryManagement.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySharpTests.Memory
{
    [TestClass]
    public class LocalUnmanagedMemoryTests
    {
        /// <summary>
        /// Writes and reads a double value from unmanaged memory.
        /// </summary>
        [TestMethod]
        public void WriteAndReadDouble()
        {
            // Arrange
            const double originalValue = 3.141592;
            LocalUnmanagedMemory local;
            double ret;

            // Act
            using (local = new LocalUnmanagedMemory(MarshalType<double>.Size))
            {
                local.Write(originalValue);
                ret = local.Read<double>();
            }

            // Assert
            Assert.AreEqual(originalValue, ret, "Both values aren't equal.");
            Assert.AreEqual(IntPtr.Zero, local.Address);
        }

        /// <summary>
        /// Writes and reads a CustomStruct structure from unmanaged memory.
        /// </summary>
        [TestMethod]
        public void WriteAndReadCustomStruct()
        {
            // Arrange
            var customStruct = Resources.CustomStruct;
            LocalUnmanagedMemory local;
            Point ret;

            // Act
            using (local = new LocalUnmanagedMemory(MarshalType<Point>.Size))
            {
                local.Write(customStruct);
                ret = local.Read<Point>();
            }

            // Assert
            Assert.AreEqual(customStruct, ret, "Both structures aren't equal.");
            Assert.AreEqual(IntPtr.Zero, local.Address);
        }
    }
}
