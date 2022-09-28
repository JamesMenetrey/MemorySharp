/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/

using Binarysharp.MSharp.Native;

namespace Binarysharp.MSharp.IntegrationTests.Windows
{
    [TestClass]
    public class KeyboardTests
    {
        /// <summary>
        /// Presses and releases the right arrow key during 2 seconds in the main window.
        /// </summary>
        /// <remarks>Manual assert.</remarks>
        [TestMethod]
        public void ArrowRight2Sec()
        {
            // Arrange
            var mainWindow = Resources.MemorySharp.Windows.MainWindow;

            // Act
            mainWindow.Keyboard.Press(Keys.Right, TimeSpan.FromMilliseconds(20));
            Thread.Sleep(2000);
            mainWindow.Keyboard.Release(Keys.Right);

            // Assert
            Assert.Inconclusive("Manual assert");
        }

        /// <summary>
        /// Presses and releases the key F1.
        /// </summary>
        /// <remarks>Manual assert.</remarks>
        [TestMethod]
        public void PostKey_MainWindow()
        {
            // Arrange
            var window = Resources.MemorySharp.Windows.MainWindow;

            // Act
            window.Keyboard.PressRelease(Keys.F1);

            // Assert
            Assert.Inconclusive("Manual assert");
        }

        /// <summary>
        /// Writes a text in the main window.
        /// </summary>
        /// <remarks>Manual assert.</remarks>
        [TestMethod]
        public void WriteText()
        {
            // Arrange
            var mainWindow = Resources.MemorySharp.Windows.MainWindow;

            // Act
            mainWindow.Keyboard.Write("<B1n@rYsH-arP^^$$#>");

            // Assert
            Assert.Inconclusive("Manual assert");
        }
    }
}
