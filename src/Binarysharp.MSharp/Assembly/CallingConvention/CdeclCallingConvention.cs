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
    /// Define the C Declaration Calling Convention.
    /// </summary>
    /// <remarks>
    /// The cdecl is a calling convention that originates from the C programming language.
    /// The parameter are pushed on the stack in the right-to-left order. The caller cleans the arguments from the stack.
    /// The return value is stored in the register EAX.
    /// </remarks>
    public class CdeclCallingConvention : ICallingConvention
    {
        /// <summary>
        /// Formats a call to a function pointer.
        /// </summary>
        /// <param name="function">The function pointer.</param>
        /// <param name="parameters">The pointer of the parameters.</param>
        /// <param name="instructions">The list that receives the assembly instructions.</param>
        public void FormatCall(IntPtr function, IntPtr[] parameters, List<string> instructions)
        {
            foreach (var parameter in parameters.Reverse())
            {
                instructions.Add("push " + parameter);
            }

            instructions.Add("call " + function);
            instructions.Add("add esp, " + parameters.Length * 4);
        }
    }
}
