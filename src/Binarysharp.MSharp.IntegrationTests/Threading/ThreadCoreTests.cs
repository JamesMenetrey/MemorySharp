/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/

using System.ComponentModel;
using System.Diagnostics;
using Binarysharp.MSharp.Helpers;
using Binarysharp.MSharp.Memory;
using Binarysharp.MSharp.Native;
using Binarysharp.MSharp.Threading;

namespace Binarysharp.MSharp.IntegrationTests.Threading
{
    [TestClass]
    public class ThreadCoreTests
    {
        /// <summary>
        /// Suspends and restores the main thread.
        /// </summary>
        [TestMethod]
        public void SuspendRestore()
        {
            // Arrange
            var threadHandle = ThreadCore.OpenThread(ThreadAccessFlags.SuspendResume, Resources.ProcessTest.Threads[0].Id);

            // Act
            try
            {
                var retSuspend = ThreadCore.SuspendThread(threadHandle);
                var retResume = ThreadCore.ResumeThread(threadHandle);

                // Assert
                Assert.AreEqual((uint)0, retSuspend);
                Assert.AreEqual((uint)1, retResume);
            }
            catch (Win32Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Terminates the main thread.
        /// </summary>
        [TestMethod]
        public void Terminate()
        {
            // Arrange
            var handle = ThreadCore.OpenThread(ThreadAccessFlags.Terminate, Resources.ProcessTest.Threads[0].Id);
            var threadId = Resources.ProcessTest.Threads[0].Id;

            // Act
            try
            {
                ThreadCore.TerminateThread(handle, 0);
            }
            // Assert
            catch (Win32Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Resources.ProcessTest.Refresh();
            Assert.AreNotEqual(threadId, Resources.ProcessTest.Threads[0].Id, "The main thread was not properly killed.");
            Resources.Restart();
        }

        /// <summary>
        /// Creates an suspended remote thread.
        /// </summary>
        [TestMethod]
        public void CreateRemoteThread()
        {
            // Arrange
            var handle = MemoryCore.OpenProcess(ProcessAccessFlags.AllAccess, Resources.ProcessTest.Id);

            // Act
            var thread = ThreadCore.CreateRemoteThread(handle, new IntPtr(1), IntPtr.Zero ,ThreadCreationFlags.Suspended);
            var threadId = HandleManipulator.HandleToThreadId(thread);

            // Assert
            Assert.IsFalse(thread.IsInvalid);
            Assert.IsTrue(Resources.ProcessTest.Threads.Cast<ProcessThread>().Any(t => t.Id == threadId));
        }

        /// <summary>
        /// Gets main thread context of the process test
        /// </summary>
        [TestMethod]
        public void GetSetThreadContextSuspendResume()
        {
            // Arrange
            var handle = ThreadCore.OpenThread(ThreadAccessFlags.AllAccess, Resources.ProcessTest.Threads[0].Id);

            // Act
            try
            {
                ThreadCore.SuspendThread(handle);

#if x86
                const uint eaxToTest = 0x666;

                // Get the context
                ThreadContext32 context = new ThreadContext32(ThreadContextFlags.All);
                ThreadCore.GetThreadContext(handle, ref context);

                Assert.AreNotEqual(0u, context.Eip);

                // Set a value to eax
                var originalEax = context.Eax;
                context.Eax = eaxToTest;

                // Set the context
                ThreadCore.SetThreadContext(handle, ref context);

                // Re-get the context to check if it's all right
                context.Eax = 0;
                ThreadCore.GetThreadContext(handle, ref context);

                Assert.AreEqual(eaxToTest, context.Eax);

                // Restore the original context
                context.Eax = originalEax;
                ThreadCore.SetThreadContext(handle, ref context);
#elif x64
                const ulong raxToTest = 0x666;
                // The data structure must be aligned to 16 bytes
                StackAllocAlignment.Allocate(16, (ref ThreadContext64 context) =>
                {
                    // Get the context
                    context.ContextFlags = ThreadContextFlags.All;
                    ThreadCore.GetThreadContext(handle, ref context);

                    Assert.AreNotEqual(0ul, context.Rip);

                    // Set the value to rax
                    var originalRax = context.Rax;
                    context.Rax = raxToTest;

                    // Set the context
                    ThreadCore.SetThreadContext(handle, ref context);

                    // Re-get the context to check if it's all right
                    context.Rax = 0;
                    ThreadCore.GetThreadContext(handle, ref context);

                    Assert.AreEqual(raxToTest, context.Rax);

                    // Restore the original context
                    context.Rax = originalRax;
                    ThreadCore.SetThreadContext(handle, ref context);
                });
#endif
            }
            finally
            {
                ThreadCore.ResumeThread(handle);
            }
        }

        /// <summary>
        /// Waits for the end of the main thread.
        /// </summary>
        [TestMethod]
        public void WaitForSingleObject()
        {
            // Arrange
            var handle = ThreadCore.OpenThread(ThreadAccessFlags.Synchronize, Resources.ProcessTest.Threads[0].Id);

            // Act
            var task = new Task<WaitValues>(() => ThreadCore.WaitForSingleObject(handle));
            task.Start();
            Resources.Restart();

            // Assert
            Assert.AreEqual(WaitValues.Signaled, task.Result);
        }

        /// <summary>
        /// Gets the exit code of the main thread.
        /// </summary>
        [TestMethod]
        public void GetExitCodeThread()
        {
            // Arrange
            var handle = ThreadCore.OpenThread(ThreadAccessFlags.QueryInformation | ThreadAccessFlags.Terminate, Resources.ProcessTest.Threads[0].Id);

            // Act
            var exitCodeBefore = ThreadCore.GetExitCodeThread(handle);
            // Exit the application
            ThreadCore.TerminateThread(handle, 1337);
            // Wait the process is terminating
            Thread.Sleep(2000);
            // Check the exit code
            var exitCodeAfter = ThreadCore.GetExitCodeThread(handle);

            // Assert
            Assert.AreEqual(null, exitCodeBefore);
            Assert.AreEqual((IntPtr)1337, exitCodeAfter, "The exit code didn't match to the expected value.");

        }
    }
}
