/*
 * This file is part of MemorySharp.
 * Copyright (C) 2012-2013 Jämes Ménétrey (a.k.a. ZenLulz).
 * <http://www.binarysharp.com/> <zenlulz@binarysharp.com>
 * 
 * This library is licensed under the GNU GPLv3 License.
 * See the file LICENSE for more information.
*/

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySharpTests.Windows
{
    [TestClass]
    public class WindowsFactoryTests
    {
        /// <summary>
        /// Gets the child windows of the test process.
        /// </summary>
        [TestMethod]
        public void ChildWindows()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
            var windows = sharp.Windows.ChildWindows;

            // Assert
            Assert.IsTrue(windows.Any(w => w.ClassName == "Scintilla"), "Cannot find Scintilla (or it's not Notepad++).");
        }

        /// <summary>
        /// Gets the windows of the test process.
        /// </summary>
        [TestMethod]
        public void Windows()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
            var windows = sharp.Windows.RemoteWindows;

            // Assert
            Assert.IsTrue(windows.Any(w => w.ClassName == "Scintilla"), "Cannot find Scintilla (or it's not Notepad++).");
        }

        /// <summary>
        /// Gets windows by their class name.
        /// </summary>
        [TestMethod]
        public void GetWindowByClassName()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
            var windows = sharp.Windows.GetWindowsByClassName("Scintilla");

            // Assert
            Assert.IsTrue(windows.Any(), "Cannot find Scintilla (or it's not Notepad++).");
        }

        /// <summary>
        /// Gets windows by a part of their title.
        /// </summary>
        [TestMethod]
        public void GetWindowByTitleContains()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
            var windows = sharp.Windows.GetWindowsByTitleContains("Notepad++");

            // Assert
            Assert.IsTrue(windows.Any(), "Cannot find Notepad++ window.");
        }
    }
}
