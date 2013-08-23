/*
 * This file is part of MemorySharp.
 * Copyright (C) 2012-2013 Jämes Ménétrey (a.k.a. ZenLulz).
 * <http://www.binarysharp.com/> <zenlulz@binarysharp.com>
 * 
 * This library is licensed under the GNU GPLv3 License.
 * See the file LICENSE for more information.
*/

using System;
using Binarysharp.MemoryManagement.Memory;

namespace Binarysharp.MemoryManagement.Modules
{
    /// <summary>
    /// Class representing a function in the remote process.
    /// </summary>
    public class RemoteFunction : RemotePointer
    {
        #region Properties
        /// <summary>
        /// The name of the function.
        /// </summary>
        public string Name { get; private set; }
        #endregion

        #region Constructor
        public RemoteFunction(MemorySharp memorySharp, IntPtr address, string functionName) : base(memorySharp, address)
        {
            // Save the parameter
            Name = functionName;
        }
        #endregion

        #region Methods
        #region ToString (override)
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return string.Format("BaseAddress = 0x{0:X} Name = {1}", BaseAddress.ToInt64(), Name);
        }
        #endregion
        #endregion
    }
}
