namespace Binarysharp.MSharp.Assembly.CallingConvention
{
    /// <summary>
    /// Define the Microsoft x64 Calling Convention.
    /// </summary>
    /// <remarks>
    /// This calling convention is used for calling x86-64 functions on Microsoft operating systems.
    /// The four first parameters are stored (left-to-right) in the registers RCX, RDX, R8 and R9.
    /// The remaining parameter are pushed on the stack in the right-to-left order. The caller cleans the arguments from the stack.
    /// A shadow space of a size of 32-bit is added after the parameters on the stack.
    /// The return value is stored in the register RAX.
    /// </remarks>
    public class MicrosoftX64CallingConvention : ICallingConvention
    {
        private const int ShadowSpaceSize = 32;

        /// <summary>
        /// Formats a call to a function pointer.
        /// </summary>
        /// <param name="function">The function pointer.</param>
        /// <param name="parameters">The pointer of the parameters.</param>
        /// <param name="instructions">The list that receives the assembly instructions.</param>
        public void FormatCall(IntPtr function, IntPtr[] parameters, List<string> instructions)
        {
            // Set up the parameters
            // The first 4 are stored in registers
            switch (parameters.Length)
            {
                default:
                    instructions.Add("mov r9, " + parameters[3]);
                    goto case 3;
                case 3:
                    instructions.Add("mov r8, " + parameters[2]);
                    goto case 2;
                case 2:
                    instructions.Add("mov rdx, " + parameters[1]);
                    goto case 1;
                case 1:
                    instructions.Add("mov rcx, " + parameters[0]);
                    break;
                case 0:
                    break;
            }

            // The remaining parameters are pushed onto the stack in right-to-left order
            foreach (var parameter in parameters.Skip(4).Reverse())
            {
                instructions.Add("push " + parameter);
            }

            // Add the shadow space
            instructions.Add("sub rsp, " + ShadowSpaceSize);

            // Call the function
            instructions.Add("mov rax, " + function);
            instructions.Add("call rax");

            // Free the stack (shadow space and the parameters)
            var numberOfParamOnStack = Math.Max(parameters.Length - 4, 0);
            instructions.Add("add rsp, " + (ShadowSpaceSize + numberOfParamOnStack * 8));
        }
    }
}
