/*
 * This file is part of MemorySharp.
 * Copyright (C) 2012-2013 Jämes Ménétrey (a.k.a. ZenLulz).
 * <http://www.binarysharp.com/> <zenlulz@binarysharp.com>
 * 
 * This library is licensed under the GNU GPLv3 License.
 * See the file LICENSE for more information.
*/

namespace Binarysharp.MemoryManagement.Threading
{
    #region SegmentRegisters
    /// <summary>
    /// List of segment registers.
    /// </summary>
    public enum SegmentRegisters
    {
        /// <summary>
        /// The code segment.
        /// </summary>
        Cs,
        /// <summary>
        /// The Data segment.
        /// </summary>
        Ds,
        /// <summary>
        /// The extra data segment.
        /// </summary>
        Es,
        /// <summary>
        /// The points to Thread Information Block (TIB).
        /// </summary>
        Fs,
        /// <summary>
        /// The extra data segment.
        /// </summary>
        Gs,
        /// <summary>
        /// The stack segment.
        /// </summary>
        Ss
    }
    #endregion
}
