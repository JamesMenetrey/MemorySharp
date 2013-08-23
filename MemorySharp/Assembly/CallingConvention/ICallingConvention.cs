/*
 * This file is part of MemorySharp.
 * Copyright (C) 2012-2013 Jämes Ménétrey (a.k.a. ZenLulz).
 * <http://www.binarysharp.com/> <zenlulz@binarysharp.com>
 * 
 * This library is licensed under the GNU GPLv3 License.
 * See the file LICENSE for more information.
*/

using System;

namespace Binarysharp.MemoryManagement.Assembly.CallingConvention
{
    /// <summary>
    /// Interface defining a calling convention.
    /// </summary>
    public interface ICallingConvention
    {
        /// <summary>
        /// The name of the calling convention.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Defines which function performs the clean-up task.
        /// </summary>
        CleanupTypes Cleanup { get; }
        /// <summary>
        /// Formats the given parameters to call a function.
        /// </summary>
        /// <param name="parameters">An array of parameters.</param>
        /// <returns>The mnemonics to pass the parameters.</returns>
        string FormatParameters(IntPtr[] parameters);
        /// <summary>
        /// Formats the call of a given function.
        /// </summary>
        /// <param name="function">The function to call.</param>
        /// <returns>The mnemonics to call the function.</returns>
        string FormatCalling(IntPtr function);
        /// <summary>
        /// Formats the cleaning of a given number of parameters.
        /// </summary>
        /// <param name="nbParameters">The number of parameters to clean.</param>
        /// <returns>The mnemonics to clean a given number of parameters.</returns>
        string FormatCleaning(int nbParameters);
    }
}
