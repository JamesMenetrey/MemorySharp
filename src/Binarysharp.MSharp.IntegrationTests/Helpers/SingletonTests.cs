/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/

using Binarysharp.MSharp.Helpers;

namespace Binarysharp.MSharp.IntegrationTests.Helpers
{
    [TestClass]
    public class SingletonTests
    {
        /// <summary>
        /// Tests the singleton pattern implementation.
        /// </summary>
        [TestMethod]
        public void ReallySingleton()
        {
            Assert.AreSame(Singleton<Object>.Instance, Singleton<Object>.Instance);
        }
    }
}
