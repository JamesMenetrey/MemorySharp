# MemorySharp #

## Synopsis ##

MemorySharp is a C# based memory editing library targeting Windows applications, offering various functions to extract and inject data and codes into remote processes to allow interoperability.

The goal of this library is to provide a safe, powerful and easy to use API, keeping the remote process as clean as possible.
The library can only be used within 32-bit development.

MemorySharp is available under two different models of distribution, as explained in the license:

- **The community edition**: enabling open source and non commercial development (this version available on Github).
- **The commercial edition**: enabling closed source distribution and commercial development. This package also provides **premium support** and the **official documentation** dedicated to learn the art of Memory Editing with the library.

Discover all the [premium features](http://binarysharp.com/products/memorysharp#premium). Visit the [official webpage of MemorySharp](http://binarysharp.com/products/memorysharp).

## Features ##

MemorySharp is divided into several parts. Here is list the all the features available.

- **Process interactions**
 - Check if the process is debugged
 - Gather information of the process
 - Interact with the PEB (Process Environment Block)

- **Memory interactions**
 - Allocate and free a chunk of memory
 - Change the protection of allocated regions
 - Get an absolute/relative address from a pointer
 - Query the memory allocated
 - Read and write primitive and complex data types

- **Module interactions**
 - Enumerate all modules loaded
 - Find functions inside a module
 - Get the main module
 - Inject and eject modules

- **Thread interactions**
 - Create and terminate threads
 - Get the exit code of terminated threads
 - Get the main thread
 - Get the segments addresses
 - Get threads by identifier
 - Interact with the TEB (Thread Environment Block)
 - Join threads
 - Manage the context of threads
 - Query the state of threads
 - Suspend and resume threads

- **Window interactions**
 - Enumerate the windows of the process
 - Enumerate the child windows of the process
 - Enumerate the child windows of another window
 - Flash the window (once or repeatedly)
 - Get a window by its class name
 - Get a window by its title (or a part of its title)
 - Get the attached thread of a window
 - Get the main window
 - Interact with the keyboard with a window (press and release keys, write texts) without activate it
 - Interact with the mouse with the window (clicks, movement)
 - Post and send message
 - Query the class name
 - Query and modify the title
 - Query and modify the size (height, width) and the position (X, Y)

- **Assembly interactions**
 - Assemble mnemonics
 - Embed FASM compiler ([https://github.com/ZenLulz/Fasm.NET](https://github.com/ZenLulz/Fasm.NET "wrapped by ZenLulz")) 
 - Execute remote codes (such as functions) with/without parameter(s) synchronously and asynchronously
 - Inject mnemonics
 - Support several calling conventions

- **Data types manipulations**
 - Extract useful information from data types
 - Convert a byte array to a managed object
 - Convert a managed object to a byte array
 - Convert a pointer to a managed object
 - Store data in the remote process in safe (collected when unused)

- **Helpers available**
 -  ApplicationFinder: Find the right process to interact
 -  HandleManipulator: Convert an handle to a process or a thread
 -  Randomizer: Generate random numbers, strings and Guid
 -  SerializationHelper: Serialize and deserialize managed object into XML
 -  Generic singleton: Implement a singleton on any of your class

## Premium Features ##
These premium features are only available in the commercial edition. 

### Code ###
The following features are available within the premium edition of the library. 


- **Helpers available**
 - Randomizer: Generate random numbers, strings and Guid
 - SerializationHelper: Serialize and deserialize managed object into XML
- **Executor Mechanism** *(not available yet, coming soon)*
- **Hook Mechanism** *(not available yet, coming soon)*
- **Pattern Mechanism** *(not available yet, coming soon)*
- **Patching Mechanism** *(not available yet, coming soon)*

### Memory Editing documentation ###
Always dreamt to make Memory Editing ? This online documentation will learn you the basis of the art of Memory Editing and how to use the full power of the library. This online documentation is available when you have an active subscription. Here is its table of contents.

**Getting Started**

- **Introduction**
- **Install the IDE and tools**
 - Set up the IDE
 - Choose a target application
 - Debug our work
 - Reverse Engineering Tools
- **Download and import the library**
 - Download the library
 - Import in Visual Studio
- **Interact with your first program**
 - Start the target application
 - Start coding
 - Invoking a messagebox
 - Summarize

**Interacting with the memory**


- **Discover the MemorySharp class**
 - Native vs library's classes
 - Discover the factories
 - Browse the PEB
 - Dispose implementation
- **Learn vocabulary about memory addresses**
 - Virtual address, application image
 - Base address, rebased address and absolute address
 - Relative virtual address, relative address and offset
 - Static address
 - Understand the ASLR
 - Go further
- **Query the memory**
 - RemotePointer and RemoteRegion classes
 - Find the application base address using Cheat Engine
 - Find the application base address using MemorySharp
 - Browse the regions
- **Read and write primitive and complex data types**
 - Different ways to read and write
 - Read and write primitive data types
 - Read and write complex data types
 - Read and write strings
 - Changing the protection of the memory
- **Allocate and free memory**
 - RemoteAllocation class
 - Allocate and free chunks
 - Query the allocated memory
 - Summarize
- **Interacting with modules** *(not available yet, coming soon)*
- **Interacting with threads** *(not available yet, coming soon)*
- **Interacting with windows** *(not available yet, coming soon)*
- **Interacting with assembly** *(not available yet, coming soon)*
- **Manipulating data types** *(not available yet, coming soon)*
- **Using helpers in the library** *(not available yet, coming soon)*

### Support ###
MemorySharp Commercial edition also include a dedicated forum for premium support regarding the library and the online documentation.

Compare the different MemorySharp edition on the [official website of MemorySharp](http://binarysharp.com/products/memorysharp#editions).

## Examples ##

### Reading/Write data ###

These are basically two ways to read/write data. The first one is to use the the `MemorySharp` class :

```csharp
var address = IntPtr.Zero;
var sharp = new MemorySharp(Process.GetCurrentProcess());

// Read an array of 3 integers
int[] integers = sharp.Read<int>(address, 3);
// Write a string
sharp.WriteString(address, "I love managed languages.");
```

The second way is to use `RemotePointer` objects. These objects are instanciated using the indexer on `MemorySharp` objects :

```csharp
var address = IntPtr.Zero;
var offset = IntPtr.Zero;
var sharp = new MemorySharp(Process.GetCurrentProcess());

// Read an array of 3 integers
int[] integers = sharp[address].Read<int>(offset, 3);
// Write a string
sharp[address].WriteString("I love managed languages.");
```

### Execute/Inject code ###

Executing code is very similar to read and write memory. The `Assembly` factory can be used :

```csharp
var address = IntPtr.Zero;
var sharp = new MemorySharp(Process.GetCurrentProcess());

// Execute code and get the return value as boolean
var ret = sharp.Assembly.Execute<bool>(address);
```

Using RemotePointer is also possible :

```csharp
var address = IntPtr.Zero;
var sharp = new MemorySharp(Process.GetCurrentProcess());

// Execute code and get the return value as a Vector3 structure
var vector = sharp[address].Execute<Vector3>(address, "a parameter", "another one");
```

The parameters like `string` are dynamically allocated in the remote process memory and freed as soon as the execution of the code terminated.

Here, some FASM mnemonics are injected at a given address :

```csharp
var address = IntPtr.Zero;
var sharp = new MemorySharp(Process.GetCurrentProcess());

// Inject mnemonics
sharp.Assembly.Inject(
    new[]
        {
            "push 0",
            "add esp, 4",
            "retn"
        },
    address);
```

Lazy people will enjoy the assembly transactions to remote inject and execute code :

```csharp
var address = IntPtr.Zero;
var sharp = new MemorySharp(Process.GetCurrentProcess());

// Inject and execute code lazily
using(var t = sharp.Assembly.BeginTransaction())
{
	t.AddLine("mov eax, {0}", address);
	t.AddLine("call eax");
	t.AddLine("retn");
}
```

The code is then automatically executed in the remote process.

### Thread-and-play ###

Here are some examples to show how it's easy to play with remote threads.

Hijacking a thread :

```csharp
var sharp = new MemorySharp(Process.GetCurrentProcess());

sharp.Threads.MainThread.Context.Eip = address;
```

What ? Yes of course... the code suspends and resumes the thread when changing its context.

Freeze the application :

```csharp
var sharp = new MemorySharp(Process.GetCurrentProcess());

sharp.Threads.SuspendAll();
```

Extract specific information from the TEB :

```csharp
var sharp = new MemorySharp(Process.GetCurrentProcess());

var tlsPtr = sharp.Threads.MainThread.Teb.Tls;
```

TLS cloning (only for the demo, it would be quite evil to really do that) :

```csharp
var sharp = new MemorySharp(Process.GetCurrentProcess());

sharp.Threads.RemoteThreads.First().Teb.TlsSlots = sharp.Threads.RemoteThreads.Last().Teb.TlsSlots;
```

### Inject/eject Modules ###

Here a module is injected and ejected using the `IDisposable` interface :

```csharp
string path = [..];
var sharp = new MemorySharp(Process.GetCurrentProcess());

using (var module = sharp.Modules.Inject(path))
{
    module.FindFunction("MessageBoxW").Execute(0, "Hey", "Title", 0);
}
```

One more time, using indexer here is interesting :

```csharp
var address = IntPtr.Zero;
var sharp = new MemorySharp(Process.GetCurrentProcess());

// It's in[dexer]ception !
sharp["kernel32"]["MessageBoxW"].Execute(0, "Hey", "Title", 0);
```

The traditional way is also available :

```csharp
var address = IntPtr.Zero;
var sharp = new MemorySharp(Process.GetCurrentProcess());

var module = sharp.Modules.Inject(path);
module.Eject();
```

### Query/interact with windows ###

Resize and move a window :

```csharp
var sharp = new MemorySharp(Process.GetCurrentProcess());

// Move and resize
sharp.MainWindow.X = 200;
sharp.MainWindow.Y = 200;
sharp.MainWindow.Height = 200;
sharp.MainWindow.Width = 200;
```

Write a text in Notepad++ :

```csharp
var sharp = new MemorySharp(Process.GetCurrentProcess());

// Find Scintilla
var scintilla = sharp.Windows.GetWindowsByClassName("Scintilla").FirstOrDefault();
// If scintilla was found
if(scintilla != null)
{
	// Write something
	scintilla.Keyboard.Write("Hello, World!");
}
```

Click on the top left corner of a window :

```csharp
var sharp = new MemorySharp(Process.GetCurrentProcess());

// Get the window
var window = sharp.Windows.MainWindow;
// Activate it to be in foreground
window.Activate();
// Move the cursor
window.Mouse.MoveTo(0, 0);
// Perform a left click
window.Mouse.ClickLeft();
```

How about pressing a key ?

```csharp
var sharp = new MemorySharp(Process.GetCurrentProcess());

// Get the window
var window = sharp.Windows.MainWindow;
// Press the bottom arrow down and repeat the message every 20ms
window.Keyboard.Press(Keys.Down, TimeSpan.FromMilliseconds(20));
// Wait 3 seconds
Thread.Sleep(3000);
// Release the key
window.Keyboard.Release(Keys.Down);
```

## Go ahead! ##

This library offers a huge and fully documented API. I highly suggest you to use an IDE that has Intellisense or an equivalent to see the list of the properties/methods available.

The best way to learn how to use it is by participating to the community present on the [official forum](http://www.binarysharp.com/forums "official forum") of MemorySharp and of course... make thousand tests on random apps and crashing them !

I would be very happy to listen your feedback on my [official website](http://www.binarysharp.com "offcial website"), where you also can find premium support and features.

The last but not the least point, I suggest you to read the below paragraph about licensing to fully understand how you can legally use MemorySharp.


## License model ##

MemorySharp is made available under a dual-license model. MemorySharp is freely available for non-commercial use under the terms of the GNU General Public License. A proprietary version of MemorySharp developed in parallel for professional commercial use by [Binarysharp](http://www.binarysharp.com "Binarysharp") is made available under different license terms, to suit end-user need.

I believe this model offers the best of both worlds. People developing their software under an open source model are freely availed of the MemorySharp source code and the MemorySharp open source project benefits in return from enhancements, bug reports and external development ideas. Those people developing under a proprietary source model, from whom the MemorySharp code base does not benefit through reciprocal openness, contribute financially instead. License fees fund research and development of today's and tomorrow's versions of the MemorySharp through research activities at partner institutions.


### The GPL-licensed library ###

MemorySharp is available under the GPL. Please read the full text of the GPL (available in the LICENSE file) prior to downloading and/or using the MemorySharp source code. Your downloading and/or use of the code signifies acceptance of the terms and conditions of the license. If you are unable to comply with the license terms, please immediately destroy all copies of the code in your possession.

Please be aware that while the GPL allows you to freely use the source code, it also imposes certain restrictions on the way in which you can use the code. Your attention is drawn particularly to section 2b of the GPL: "You must cause any work that you distribute or publish, that in whole or in part contains or is derived from the Program or any part thereof, to be licensed as a whole at no charge to all third parties under the terms of this License.", i.e. your software incorporating or linking to MemorySharp must also be open-source software, licensed under the GPL. Use of the MemorySharp in breach of the terms of the GPL will be subject to legal action by the copyright holders.

### Licenses for professional and commercial use ###

The holders of the copyright of MemorySharp have elected to make this code available under proprietary licenses for professional and commercial use by people for whom the GPL license is not ideal. These license arrangements are managed by [Binarysharp](http://www.binarysharp.com "Binarysharp"). Please visit the Binarysharp's [website](http://www.binarysharp.com "website") for information on products, license terms and pricing.

Binarysharp also provide a variety of value-added services, including premium support and premium features.

## Credits ##

At the beginning, I thank my Notepad++ app, because it suffered so many crashes due to bad injections and wrong codes of my part.

More seriously, I thank the entire [Ownedcore](http://www.ownedcore.com "Ownedcore") community, which allows me to learn the art of the Memory Editing. Especially **Apoc**, who is a very inspirational person for me with his  posts giving so well-written pieces of code without asking anything in return (this includes examples / offsets / guides /libraries), **Cypher** for his *very* critical mind about coding practices, **Bananenbrot** for giving nice advices in a lot of threads of the board, **TOM_RUS** for his very high-skilled eyes to read asm, making very comprehensive wrappers and **Shynd**, who gave me the idea of creating my own library. I certainly forget tons of people here.

This is because there are so many people ready to share their skills that I decided to publish a GPL-licensed version of MemorySharp.

## Author ##

This developer and the copyright holder of this library is [ZenLulz (Jämes Ménétrey)](https://github.com/ZenLulz).  
The official website of MemorySharp is [www.binarysharp.com](http://ww.binarysharp.com).