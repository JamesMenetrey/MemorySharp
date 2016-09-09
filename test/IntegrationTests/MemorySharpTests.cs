/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/
using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySharpTests
{
    [TestClass]
    public class MemorySharpTests
    {
        /// <summary>
        /// Gets an absolute address.
        /// </summary>
        [TestMethod]
        public void GetAbsolute()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            var address = sharp.Modules.MainModule.BaseAddress;
            var offset = new IntPtr(0x400);

            // Act
            var absolute = sharp.MakeAbsolute(offset);

            //Assert
            Assert.AreEqual(address.ToInt64() + offset.ToInt64(), absolute.ToInt64(), "Couldn't rebase the address correctly.");
        }

        /// <summary>
        /// This test checks if the main module is properly cached in the library.
        /// Speed issue reported here: http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/433056-memorysharp-c-based-memory-editing-library-targeting-windows-applications-2.html#post2867864
        /// </summary>
        [TestMethod]
        public void AssessSpeedMakeAbsolute100K()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            var offset = new IntPtr(0x400);
            var watch = new Stopwatch();

            // Act
            watch.Start();
            for (var i = 0; i < 100000; i++)
            {
                sharp.MakeAbsolute(offset);
            }
            watch.Stop();

            // Assess
            Assert.IsTrue(watch.Elapsed.TotalSeconds < 1, $"The method to make an absolute address is too slow ({watch.Elapsed.TotalSeconds}s).");
        }

        /// <summary>
        /// Gets the relative address.
        /// </summary>
        [TestMethod]
        public void GetRelative()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            var offset = new IntPtr(0x400);
            var address = new IntPtr(sharp.Modules.MainModule.BaseAddress.ToInt64() + offset.ToInt64());

            // Act
            var relative = sharp.MakeRelative(address);

            // Assert
            Assert.AreEqual(offset, relative, "Couldn't get the relative address.");
        }

        /// <summary>
        /// Writes and reads a byte array.
        /// </summary>
        [TestMethod]
        public void WriteReadBytes()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            var value = new byte[] {0x90,0x90,0x90};

            // Act
            sharp.Write(IntPtr.Zero, value);
            var ret = sharp.Read<byte>(IntPtr.Zero, value.Length);

            // Assert
            CollectionAssert.AreEqual(value, ret, "Both collections are not equal.");
            Resources.Restart();
        }

        /// <summary>
        /// Writes and reads an integer array.
        /// </summary>
        [TestMethod]
        public void WriteReadIntegers()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            var value = new[] { 0x90, 0x90, 0x90 };

            // Act
            sharp.Write(IntPtr.Zero, value);
            var ret = sharp.Read<int>(IntPtr.Zero, value.Length);

            // Assert
            CollectionAssert.AreEqual(value, ret, "Both collections are not equal.");
            Resources.Restart();
        }

        /// <summary>
        /// Writes and reads a string.
        /// </summary>
        [TestMethod]
        public void WriteReadString()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            const string value = "I love cookies";

            // Act
            sharp.WriteString(IntPtr.Zero, value);
            var ret = sharp.ReadString(IntPtr.Zero);

            // Assert
            Assert.AreEqual(value, ret, "Both strings are not equal.");
            Resources.Restart();
        }

        /// <summary>
        /// Ensure a string without a \0 delimiter can be read.
        /// Issue reported here: https://github.com/ZenLulz/MemorySharp/issues/1 (4)
        /// </summary>
        [TestMethod]
        public void WriteReadStringWithoutEndCharacter()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            const string value = "I love cookies";

            // Act
            sharp.WriteString(IntPtr.Zero, value);
            var ret = sharp.ReadString(IntPtr.Zero, true, value.Length);

            // Assert
            Assert.AreEqual(value, ret, "Both strings are not equal.");
            Resources.Restart();
        }

        /// <summary>
        /// Tests the property IsRunning.
        /// </summary>
        [TestMethod]
        public void IsRunning()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act - Assert
            Assert.IsTrue(sharp.IsRunning, "The process must be running.");
            sharp.Native.Kill();
            Thread.Sleep(2000);
            Assert.IsFalse(sharp.IsRunning, "The process must be closed.");

            Resources.Restart();
        }

        /// <summary>
        /// Checks if no debugger is attached (DO NOT USE OLLYDBG HERE).
        /// </summary>
        [TestMethod]
        public void CheckIfNoDebuggerIsAttached()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
            var ret = sharp.IsDebugged;

            // Assert
            Assert.IsFalse(ret);
        }
    }
}
