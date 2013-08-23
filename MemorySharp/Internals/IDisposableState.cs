/*
 * This file is part of MemorySharp.
 * Copyright (C) 2012-2013 Jämes Ménétrey (a.k.a. ZenLulz).
 * <http://www.binarysharp.com/> <zenlulz@binarysharp.com>
 * 
 * This library is licensed under the GNU GPLv3 License.
 * See the file LICENSE for more information.
*/

using System;

namespace Binarysharp.MemoryManagement.Internals
{
    /// <summary>
    /// Defines an IDisposable interface with a known state.
    /// </summary>
    public interface IDisposableState : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether the element is disposed.
        /// </summary>
        bool IsDisposed { get; }
        /// <summary>
        /// Gets a value indicating whether the element must be disposed when the Garbage Collector collects the object.
        /// </summary>
        bool MustBeDisposed { get; }
    }
}
