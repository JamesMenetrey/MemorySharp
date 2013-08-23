/*
 * This file is part of MemorySharp.
 * Copyright (C) 2012-2013 Jämes Ménétrey (a.k.a. ZenLulz).
 * <http://www.binarysharp.com/> <zenlulz@binarysharp.com>
 * 
 * This library is licensed under the GNU GPLv3 License.
 * See the file LICENSE for more information.
*/

using System.Threading;
using Binarysharp.MemoryManagement.Native;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySharpTests.Memory
{
    [TestClass]
    public class RemoteRegionTests
    {
        /// <summary>
        /// Changes the protection of the main module and restores it.
        /// </summary>
        [TestMethod]
        public void ChangeProtection()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act - Assert
            Resources.EndTests(sharp);
            Assert.AreEqual(MemoryProtectionFlags.ReadOnly, sharp.Modules.MainModule.Information.Protect, "The main module is not in readonly.");
            using (sharp.Modules.MainModule.ChangeProtection(MemoryProtectionFlags.ExecuteRead))
            {
                Assert.AreEqual(MemoryProtectionFlags.ExecuteRead, sharp.Modules.MainModule.Information.Protect, "The main module protection couldn't be changed.");
            }
            Assert.AreEqual(MemoryProtectionFlags.ReadOnly, sharp.Modules.MainModule.Information.Protect, "The main module is not in readonly (2).");
        }
    }
}
