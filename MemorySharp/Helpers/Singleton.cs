/*
 * This file is part of MemorySharp.
 * Copyright (C) 2012-2013 Jämes Ménétrey (a.k.a. ZenLulz).
 * <http://www.binarysharp.com/> <zenlulz@binarysharp.com>
 * 
 * This library is licensed under the GNU GPLv3 License.
 * See the file LICENSE for more information.
*/

namespace Binarysharp.MemoryManagement.Helpers
{
    /// <summary>
    /// Static helper used to create or get a singleton from another class.
    /// </summary>
    /// <typeparam name="T">The type to create or get a singleton.</typeparam>
    public static class Singleton<T> where T : new()
    {
        /// <summary>
        /// Gets the singleton of the given type.
        /// </summary>
        public static readonly T Instance = new T();
    }
}
