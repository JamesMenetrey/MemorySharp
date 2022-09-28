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
    /// Define the Fast Calling Convention.
    /// </summary>
    /// <remarks>
    /// This is Microsoft or GCC __fastcall convention (aka __msfastcall).
    /// The two first parameters are stored in the registers ECX and EDX.
    /// The remaining parameter are pushed on the stack in the right-to-left order. The callee cleans the arguments from the stack.
    /// The return value is stored in the register EAX.
    /// </remarks>
    public class FastcallCallingConvention : ICallingConvention
    {
        /// <summary>
        /// Formats a call to a function pointer.
        /// </summary>
        /// <param name="function">The function pointer.</param>
        /// <param name="parameters">The pointer of the parameters.</param>
        /// <param name="instructions">The list that receives the assembly instructions.</param>
        /// <remarks>
        /// The two first parameters (left-to-right) are stored in the registers ECX and EDX.
        /// The remaining parameter are pushed on the stack in the right-to-left order. The callee cleans the arguments from the stack.
        /// The return value is stored in the register EAX.
        /// </remarks>
        public void FormatCall(IntPtr function, IntPtr[] parameters, List<string> instructions)
        {
            // Set up the parameters
            // The first 2 are stored in registers
            switch (parameters.Length)
            {
                default:
                    instructions.Add("mov edx, " + parameters[1]);
                    goto case 1;
                case 1:
                    instructions.Add("mov ecx, " + parameters[0]);
                    break;
                case 0:
                    break;
            }

            // The remaining parameters are pushed onto the stack in right-to-left order
            foreach (var parameter in parameters.Skip(2).Reverse())
            {
                instructions.Add("push " + parameter);
            }

            // Call the function
            instructions.Add("call " + function);
        }
    }
}
