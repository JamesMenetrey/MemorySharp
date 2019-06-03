using System;
using System.Collections.Generic;
using Binarysharp.MemoryManagement.Memory;
using Keystone;

namespace Binarysharp.MemoryManagement.Assembly.Assembler
{
    /// <summary>
    /// Rely on Keystone assembler.
    /// More info: https://github.com/keystone-engine/keystone
    /// </summary>
    public class KeystoneAssembler : IAssembler
    {
        #region Fields

        private static readonly Dictionary<InstructionSet, Mode> ModeMappings = new Dictionary<InstructionSet, Mode>
        {
            { InstructionSet.X64, Mode.X64 },
            { InstructionSet.X86, Mode.X32 }
        };

        /// <summary>
        /// The instance of Keystone engine.
        /// </summary>
        private readonly Engine _assembler;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the assembler.
        /// The instruction set matches the architecture of the target process.
        /// </summary>
        public KeystoneAssembler(InstructionSet instructionSet)
        {
            _assembler = new Engine(Architecture.X86, MapToKeystoneMode(instructionSet)) {ThrowOnError = true};
        }

        #endregion

        #region Implementation of IAssembler

        /// <summary>
        /// Assemble the specified assembly code.
        /// </summary>
        /// <param name="instructions">The instructions represented in assembly code.</param>
        /// <returns>An array of bytes containing the assembly code.</returns>
        public byte[] Assemble(IEnumerable<string> instructions) => Assemble(instructions, IntPtr.Zero);

        /// <summary>
        /// Assemble the specified assembly code at a base address.
        /// </summary>
        /// <param name="instructions">The instructions represented in assembly code.</param>
        /// <param name="baseAddress">The address where the code is rebased.</param>
        /// <returns>An array of bytes containing the assembly code.</returns>
        public byte[] Assemble(IEnumerable<string> instructions, IntPtr baseAddress)
        {
            return _assembler.Assemble(string.Join(";", instructions), (ulong) baseAddress.ToInt64()).Buffer;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts an instruction set enumeration from MemorySharp to a mode from Keystone.
        /// </summary>
        /// <param name="instructionSet"></param>
        /// <returns></returns>
        private Mode MapToKeystoneMode(InstructionSet instructionSet)
        {
            if (ModeMappings.TryGetValue(instructionSet, out Mode mode))
            {
                return mode;
            }

            throw new ArgumentException("The instruction set is not supported", nameof(instructionSet));
        }

        #endregion
    }
}