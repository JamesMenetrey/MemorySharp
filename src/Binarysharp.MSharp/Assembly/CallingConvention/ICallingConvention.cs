/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/

namespace Binarysharp.MSharp.Assembly.CallingConvention
{
    /// <summary>
    /// Interface defining a calling convention.
    /// </summary>
    public interface ICallingConvention
    {
        /// <summary>
        /// Formats a call to a function pointer.
        /// </summary>
        /// <param name="function">The function pointer.</param>
        /// <param name="parameters">The pointer of the parameters.</param>
        /// <param name="instructions">The list that receives the assembly instructions.</param>
        void FormatCall(IntPtr function, IntPtr[] parameters, List<string> instructions);
    }
}
