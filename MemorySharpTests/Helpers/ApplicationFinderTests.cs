/*
 * This file is part of MemorySharp.
 * Copyright (C) 2012-2013 Jämes Ménétrey (a.k.a. ZenLulz).
 * <http://www.binarysharp.com/> <zenlulz@binarysharp.com>
 * 
 * This library is licensed under the GNU GPLv3 License.
 * See the file LICENSE for more information.
*/

using System.Linq;
using Binarysharp.MemoryManagement.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySharpTests.Helpers
{
    [TestClass]
    public class ApplicationFinderTests
    {
        /// <summary>
        /// Enumerates all top-level windows and search the test process.
        /// </summary>
        [TestMethod]
        public void TopLevelWindows()
        {
            // Arrange
            var process = Resources.ProcessTest;

            // Act
            var ret = ApplicationFinder.TopLevelWindows.FirstOrDefault(windowHandle => windowHandle == process.MainWindowHandle);

            // Assert
            Assert.AreNotEqual(null, ret, "Couldn't find the main window of the test process.");
        }

        /// <summary>
        /// Enumerates all windows and search the test process.
        /// </summary>
        [TestMethod]
        public void Windows()
        {
            // Arrange
            var process = Resources.ProcessTest;

            // Act
            var ret = ApplicationFinder.Windows.FirstOrDefault(windowHandle => windowHandle == process.MainWindowHandle);

            // Assert
            Assert.AreNotEqual(null, ret, "Couldn't find the main window of the test process.");
        }

        /// <summary>
        /// Finds the application by process id.
        /// </summary>
        [TestMethod]
        public void FromProcessId()
        {
            // Arrange
            var process = Resources.ProcessTest;

            // Act
            var ret = ApplicationFinder.FromProcessId(process.Id);

            // Assert
            Assert.AreEqual(process.Id, ret.Id, "Both processes are not equal.");
        }

        /// <summary>
        /// Finds the application by process name.
        /// </summary>
        [TestMethod]
        public void FromProcessName()
        {
            // Arrange
            var process = Resources.ProcessTest;

            // Act
            var ret = ApplicationFinder.FromProcessName(process.ProcessName).First();

            // Assert
            Assert.AreEqual(process.Id, ret.Id, "Both processes are not equal.");
        }

        /// <summary>
        /// Finds the application by class name.
        /// </summary>
        [TestMethod]
        public void FromWindowClassName()
        {
            // Arrange
            var process = Resources.ProcessTest;

            // Act
            var ret = ApplicationFinder.FromWindowClassName("Notepad++").First();

            // Assert
            Assert.AreEqual(process.Id, ret.Id, "Both processes are not equal.");
        }

        /// <summary>
        /// Finds the application from the window handle.
        /// </summary>
        [TestMethod]
        public void FromWindowHandle()
        {
            // Arrange
            var process = Resources.ProcessTest;

            // Act
            var ret = ApplicationFinder.FromWindowHandle(process.MainWindowHandle);

            // Assert
            Assert.AreEqual(process.Id, ret.Id, "Both processes are not equal.");
        }

        /// <summary>
        /// Finds the application from the title.
        /// </summary>
        [TestMethod]
        public void FromWindowTitle()
        {
            // Arrange
            Resources.Restart();
            var process = Resources.ProcessTest;

            // Act
            var ret = ApplicationFinder.FromWindowTitle("new  1 - Notepad++").First();

            // Assert
            Assert.AreEqual(process.Id, ret.Id, "Both processes are not equal.");
        }

        /// <summary>
        /// Finds the application from a part of the title.
        /// </summary>
        [TestMethod]
        public void FromWindowTitleContains()
        {
            // Arrange
            var process = Resources.ProcessTest;

            // Act
            var ret = ApplicationFinder.FromWindowTitleContains("Notepad++").First();

            // Assert
            Assert.AreEqual(process.Id, ret.Id, "Both processes are not equal.");
        }
    }
}
