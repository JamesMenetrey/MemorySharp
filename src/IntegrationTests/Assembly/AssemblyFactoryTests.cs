﻿/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/
using Binarysharp.MemoryManagement.Assembly;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySharpTests.Assembly
{
    [TestClass]
    public class AssemblyFactoryTests
    {
        /// <summary>
        /// Injects some mnemonics.
        /// </summary>
        [TestMethod]
        public void Inject()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
            using (var memory = sharp.Memory.Allocate(1))
            {
                sharp.Assembly.Inject(
                    new[]
                        {
                            "push 0",
                            "add esp, 4",
                            "ret"
                        },
                    memory.BaseAddress);

                // Assert
                CollectionAssert.AreEqual(new byte[] { 0x6A, 00, 0x83, 0xC4, 04, 0xC3 }, sharp.Read<byte>(memory.BaseAddress, 6, false));
            }
            
            Resources.EndTests(sharp);
        }

        /// <summary>
        /// Injects some mnemonics using a transaction.
        /// </summary>
        [TestMethod]
        public void TransactionInject()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
            using (var memory = sharp.Memory.Allocate(1))
            {
                using (var t = sharp.Assembly.BeginTransaction(memory.BaseAddress, false))
                {
                    t.Instructions.Add("push 0");
                    t.Instructions.Add("add esp, 4");
                    t.Instructions.Add("ret");
                }
                // Assert
                CollectionAssert.AreEqual(new byte[] { 0x6A, 00, 0x83, 0xC4, 04, 0xC3 }, sharp.Read<byte>(memory.BaseAddress, 6, false));

            }

            Resources.EndTests(sharp);
        }

        /// <summary>
        /// Injects and executes some mnemonics.
        /// </summary>
        [TestMethod]
        public void InjectAndExecute()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            var asm = new[]
                {
                    "mov eax, 66",
                    "ret"
                };

            // Act
            var ret = sharp.Assembly.InjectAndExecute<int>(asm);

            // Assert
            Assert.AreEqual(66, ret, "The return value is incorrect.");
            Resources.EndTests(sharp);
        }

        /// <summary>
        /// Injects and executes some mnemonics with a transaction.
        /// </summary>
        [TestMethod]
        public void InjectAndExecuteWithTransaction()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            AssemblyTransaction t;

            // Act
            using (t = sharp.Assembly.BeginTransaction())
            {
                t.Instructions.Add("mov eax, 66");
                t.Instructions.Add("ret");
            }

            // Assert
            Assert.AreEqual(66, t.GetExitCode<int>(), "The return value is incorrect.");
            Resources.EndTests(sharp);
        }

        /// <summary>
        /// Writes some mnemonics and execute them.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldExecuteX86()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
            using (var memory = sharp.Memory.Allocate(1))
            {
                using (var t = sharp.Assembly.BeginTransaction(memory.BaseAddress))
                {
                    t.Instructions.Add("mov eax, 66");
                    t.Instructions.Add("ret");
                }

                var ret = memory.Execute<int>();

                // Assert
                Assert.AreEqual(66, ret, "The return value is incorrect.");
            }

            Resources.EndTests(sharp);
        }

#if x64
        /// <summary>
        /// Writes some mnemonics and execute them.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldExecuteX64()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            long value = 0x66;

            // Act
            using (var memory = sharp.Memory.Allocate(1))
            {
                using (var t = sharp.Assembly.BeginTransaction(memory.BaseAddress))
                {
                    t.Instructions.Add("mov rax, " + value);
                    t.Instructions.Add("ret");
                }

                var ret = memory.Execute<long>();

                // Assert
                Assert.AreEqual(value, ret, "The return value is incorrect.");
            }

            Resources.EndTests(sharp);
        }
#endif
    }
}
