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
    /// Define the stdcall Calling Convention.
    /// </summary>
    /// <remarks>
    /// The stdcall calling convention is a variation on the Pascal calling convention.
    /// The parameter are pushed on the stack in the right-to-left order. The callee cleans the arguments from the stack.
    /// The return value is stored in the register EAX.
    /// </remarks>
    public class StdcallCallingConvention : ICallingConvention
    {
        /// <summary>
        /// Formats a call to a function pointer.
        /// </summary>
        /// <param name="function">The function pointer.</param>
        /// <param name="parameters">The pointer of the parameters.</param>
        /// <param name="instructions">The list that receives the assembly instructions.</param>
        public void FormatCall(IntPtr function, IntPtr[] parameters, List<string> instructions)
        {
            // The parameters are pushed onto the stack in right-to-left order
            foreach (var parameter in parameters.Reverse())
            {
                instructions.Add("push " + parameter);
            }

            instructions.Add("call " + function);
        }
    }
}
