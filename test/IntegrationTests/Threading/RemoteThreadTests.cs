/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/
using System;
using System.Linq;
using System.Threading;
using Binarysharp.MemoryManagement.Helpers;
using Binarysharp.MemoryManagement.Native;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySharpTests.Threading
{
    [TestClass]
    public class RemoteThreadTests
    {
        /// <summary>
        /// Suspends and resumes the main thread.
        /// </summary>
        [TestMethod]
        public void SuspendResumeMainThread()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            var thread = sharp.Threads.MainThread;

            // Act - Assert
            thread.Suspend();
            Assert.IsTrue(thread.IsSuspended, "The thread is not suspended.");
            thread.Resume();
            Assert.IsFalse(thread.IsSuspended, "The thread is still suspended.");
            using (thread.Suspend())
            {
                Assert.IsTrue(thread.IsSuspended, "The thread is not suspended (2).");
            }
            Assert.IsFalse(thread.IsSuspended, "The thread is still suspended (2).");
        }

        /// <summary>
        /// Kill a main thread.
        /// </summary>
        [TestMethod]
        public void TerminateMainThread()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            var thread = sharp.Threads.MainThread;

            // Act - Assert
            Assert.IsTrue(thread.IsAlive);
            thread.Terminate();
            Thread.Sleep(1000);
            Assert.IsTrue(thread.IsTerminated);

            Resources.Restart();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Gets the context of the main thread.
        /// </summary>
        [TestMethod]
        public void GetContextMainThread()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
#if x86
            var context = new ThreadContext32(ThreadContextFlags.All);
            sharp.Threads.MainThread.GetContext(ref context);

            // Assert
            Assert.AreNotEqual(0, context.Eip);
#elif x64
            // The data structure must be aligned to 16 bytes
            StackAllocAlignment.Allocate(16, (ref ThreadContext64 context) =>
            {
                context.ContextFlags = ThreadContextFlags.All;
                sharp.Threads.MainThread.GetContext(ref context);

                // Assert
                Assert.AreNotEqual(0, context.Rip);
            });
#endif
        }

        /// <summary>
        /// Gets all segment addresses of the main thread.
        /// </summary>
        [TestMethod]
        public void GetRealSegmentAddress_GetAllSegmentsMainThreadX86()
        {
#if x86
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
            var context = new ThreadContext32(ThreadContextFlags.All);
            sharp.Threads.MainThread.GetContext(ref context);

            var thread = sharp.Threads.MainThread;
            var fs = ((WindowsRemoteThread)thread).GetRealSegmentAddress(SegmentRegisters.Fs, ref context);

            // Assert.
            Assert.AreNotEqual(IntPtr.Zero, fs, "The FS segment is null.");
#endif
        }

        /// <summary>
        /// Copies the TlsSlots from a thread to the main one by erasing them (YEAH, it's a bit evil :D).
        /// </summary>
        [TestMethod]
        public void TebTlsSlots_CopyTlsFromAnotherThread()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            var t1 = sharp.Threads.MainThread;
            var t2 = sharp.Threads.RemoteThreads.Last();
            var values = new[] { new IntPtr(0x1123344), new IntPtr(0x55667788) };

            // Act
            // Write identifiable data
            t2.Teb.TlsSlots = values;
            // Erase main tls :O
            t1.Teb.TlsSlots = t2.Teb.TlsSlots;

            // Assert
            Assert.AreEqual(values[0], t1.Teb.TlsSlots[0], "Couldn't read/write TLS.");
            Assert.AreEqual(values[1], t1.Teb.TlsSlots[1], "Couldn't read/write TLS (2).");

            Resources.Restart();
        }

        /// <summary>
        /// Changes the EIP register.
        /// </summary>
        [TestMethod]
        public unsafe void SuspendResumeSetContextIp()
        {
            // Arrange
            var sharp = Resources.MemorySharp;
            var thread = sharp.Threads.MainThread;

            // Act
#if x86
            const uint newEip = 0x666;

            // Get the original value
            var context = new ThreadContext32(ThreadContextFlags.All);
            thread.GetContext(ref context);
            var originalEip = context.Eip;

            //Set the value
            context.Eip = newEip;
            thread.SetContext(ref context);

            // Get the context again to validate the change
            thread.GetContext(ref context);

            // Assert
            Assert.AreEqual(newEip, context.Eip, "The values are not equal.");

            // Set the original value back
            context.Eip = originalEip;
            thread.SetContext(ref context);
#elif x64
            const ulong newRip = 0x666;

            // The data structure must be aligned to 16 bytes
            StackAllocAlignment.Allocate(16, (ref ThreadContext64 context) =>
            {
                // Get the original value
                context.ContextFlags = ThreadContextFlags.All;
                thread.GetContext(ref context);

                var originalRip = context.Rip;

                //Set the value
                context.Rip = newRip;
                thread.SetContext(ref context);

                // Get the context again to validate the change
                thread.GetContext(ref context);

                // Assert
                Assert.AreEqual(newRip, context.Rip, "The values are not equal.");

                // Set the original value back
                context.Rip = originalRip;
                thread.SetContext(ref context);
            });
#endif  
        }

        /// <summary>
        /// Waits on the main thread during 3 seconds or until it terminates..
        /// </summary>
        [TestMethod]
        public void Join3SecMainThread()
        {
            // Arrange
            var sharp = Resources.MemorySharp;

            // Act
            var ret = sharp.Threads.MainThread.Join(TimeSpan.FromSeconds(3));

            // Assert
            Assert.AreEqual(WaitValues.Timeout, ret);
        }
    }
}
