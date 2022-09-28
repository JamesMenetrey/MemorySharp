﻿/*
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
    /// A list of calling conventions.
    /// </summary>
    public enum CallingConventions
    {
        /// <summary>
        /// Name       : C Declaration Calling Convention
        /// Clean-up   : Caller
        /// Parameters : Passed on the stack in reverse order
        /// Ret. value : Returned in the EAX register
        /// Notes      : Widely used by the compiler GCC
        /// </summary>
        Cdecl,
        /// <summary>
        /// Name       : Standard Calling Convention
        /// Clean-up   : Callee
        /// Parameters : Passed on the stack in reverse order
        /// Ret. value : Returned in the EAX register
        /// Notes      : Convention created by Microsoft, used in the Win32 API
        /// </summary>
        Stdcall,
        /// <summary>
        /// Name       : Fast Calling Convention (aka __msfastcall)
        /// Clean-up   : Callee
        /// Parameters : The first two parameters are placed in the ECX and EDX registers respectively.
        ///              Any remaining parameters are placed on the stack in reverse order.
        /// Ret. Value : Returned in the EAX register
        /// Notes      : A variation of the stdcall convention
        /// </summary>
        Fastcall,
        /// <summary>
        /// Name       : This Calling Convention
        /// Clean-up   : Caller
        /// Parameters : The first parameter must be a pointer of the instance of the class.
        ///              Parameters are placed on the stack in reverse order.
        /// Ret. Value : Returned in the EAX register
        /// Notes      : Used for object-oriented programming by GCC
        /// </summary>
        GccThiscall,
        /// <summary>
        /// Name       : This Calling Convention
        /// Clean-up   : Callee
        /// Parameters : The 'this' pointer is placed in the ECX register.
        ///              Parameters are placed on the stack in reverse order.
        /// Ret. Value : Returned in the EAX register
        /// Notes      : Used for object-oriented programming by Microsoft Visual C++
        /// </summary>
        MicrosoftThiscall,
        /// <summary>
        /// Name       : Microsoft x64 Calling Convention
        /// Clean-up   : Caller
        /// Parameters : The four first parameters are stored (left-to-right) in the registers RCX, RDX, R8 and R9.
        ///              The remaining parameter are pushed on the stack in the right-to-left order.
        /// Ret. Value : Returned in the RAX register
        /// Notes      : Convention used by all x64 programs on Windows
        /// </summary>
        MicrosoftX64
    }

    /// <summary>
    /// A list of type of clean-up available in calling conventions.
    /// </summary>
    public enum CleanupTypes
    {
        /// <summary>
        /// The clean-up task is performed by the called function.
        /// </summary>
        Callee,
        /// <summary>
        /// The clean-up task is performed by the caller function. 
        /// </summary>
        Caller
    }
}
