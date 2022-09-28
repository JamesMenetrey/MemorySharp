/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/

namespace Binarysharp.MSharp.Assembly.Assembler
{
    /// <summary>
    /// Interface defining an assembler.
    /// </summary>
    public interface IAssembler
    {
        /// <summary>
        /// Assemble the specified assembly code.
        /// </summary>
        /// <param name="instructions">The instructions represented in assembly code.</param>
        /// <returns>An array of bytes containing the assembly code.</returns>
        byte[] Assemble(IEnumerable<string> instructions);

        /// <summary>
        /// Assemble the specified assembly code at a base address.
        /// </summary>
        /// <param name="instructions">The instructions represented in assembly code.</param>
        /// <param name="baseAddress">The address where the code is rebased.</param>
        /// <returns>An array of bytes containing the assembly code.</returns>
        byte[] Assemble(IEnumerable<string> instructions, IntPtr baseAddress);
    }
}