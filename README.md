RecipeManagerKata
=================

A C# code kata exploring ports, adapters, and simulators...

#Introduction

This kata is practice for understanding and applying the concepts of ports, adapters, and simulators to a small program. If you are new to these concepts, I suggest reading the background section and the linked references before you start.

#Directions

Your goal is to modify the starting program - a simple windows forms editor - so that the methods in it are unit testable without directly using the file system. There are likely other modifications that you may want to make as well. 

Approach it in whatever order you would like. If you'd like some guidance, see the next section.

#Suggested approach

There are a lot of different orders here that work; I've chosen one that I like. The important concerns are to get a good adapter definition, and try to do as much of the transformation through refactoring (resharper if you have it) as possible. 

  * Refactor the file system code into a separate class so that it is contained.
  * Create the adapter abstraction on top of it. This is just an interface that the new file system class expresses.
  * Figure out what the adapter abstraction should be. Is it convenient for the application to use? Is it at the right level of abstraction? 
  * Use refactoring to morph the existing abstraction into the one that you want to have. Repeat for each change that you want to make.
  * Using TDD, create a simulator for the port that you can use for your unit tests.
  * Retarget the simulator tests that you just created and run them against the file system adapter. If there are differences in behavior, decide which is correct (simulator or file system adapter), and modify appropriately.
  * Bring the object editor code under test&nbsp; by writing tests for each of the methods that deal with the file system

At this point, you have the file system operations abstracted and 
contained. Use the same approach to deal with the UI.

#Background on ports, adapters, and simulators

This section is a summary of a pretty broad topic, and I&#39;m going to 
simplify and generalize to keep it simple.
The concept of &quot;port&quot; comes from 	<a href="http://alistair.cockburn.us/Hexagonal+architecture">Cockburn&#39;s 
Hexagonal Architecture</a>.. Simply speaking, a port is a connection that a 
program has to something external, something like a database or a user 
interface. The sample application has two ports - the user interface of the 
application (which displays data and dispatches user events), and the file 
system, which can store and retrieve the editor information.
Based on a program&#39;s usage of a port, we can derive an abstraction that 
describes how the program uses the port, and then write a concrete adapter 
that implements that abstraction. Very simply, we could do something like:
<pre>class FileSystemAdapter: IFileSystem {...}</pre>
and it will work fine. However, the real power is in the &quot;adapt&quot; part of 
the adapter; rather than maintaining the abstraction of the underlying 
service, the abstraction should be expressed using application-level 
concepts. The adapter should present an interface that is exactly what the 
program would like it to be. To take a simple example from the UI side, a UI 
(aka &quot;port&quot;)-level concept might be the user pressing a button, while the 
application concept might be &quot;SaveRequested&quot;. 
Another way to think about it is that the purpose of the adapter is to 
encapsulate the real-world details that the program doesn&#39;t really want to 
care about.
This is a fairly typical approach to getting a program under test, and, 
at this point, we can write mocks and merrily go on with our testing. But 
there are problems with this approach:

  * Mock code tends to be duplicated in multiple places in the codebase.
  * Mock code - even mock code with some complexity - is rarely tested.
  * Mocks created with mocking libraries require the developer to learn a new language - the mocking language - and do not generally participate in refactoring the way program code does. 
  * There is no verification that the behavior of the mock code is a faithful simulation of the real code. 

The way to avoid this issues is a special kind of adapter known as a 
simulator, which I learned about from <a href="http://arlobelshee.com/mock-free-example-part-2-simulators/"> 
Arlo Belshee</a>. A simulator is an implementation of an adapter that is 
designed for unit testing. In our example, it might be a FileSystemSimulator 
which implements the adapter interface but stores files in memory. 
The simulator is created using TDD, so we know that it works the way that 
we expect. But the unit tests created are not specific to the simulator, 
they are specific to the adapter interface. That means we can take the unit 
tests, run them against all of the adapters (simulators and real adapters), 
and verify that all the systems have the same behavior. We can then know 
that the tests that we write using the simulator are using a faithful 
simulation of the &quot;real adapter&quot;. 
#Evaluation Thoughts
This section is definitely full of spoilers, so it&#39;s presented in 
white-on-white text (highlight it to read) Read this after you have finished 
the kata.


  * At what level of abstraction is the storage adapter expressed? I 
think something like &quot;ObjectStorage&quot; is the right level; what the 
application cares is that storage is possible and works in a specific 
way; where the objects are stored is an implementation detail. 
  * How happy are you with the resulting code that you ended up? Does it 
seem to be well-factored, etc.?
