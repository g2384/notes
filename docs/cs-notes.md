# C#

**From**

Programming C# 10

by Ian Griffiths

Released August 2022

Publisher(s): O'Reilly Media, Inc.

ISBN: 9781098117818

## Introduction

**.NET** encompasses both the runtime and the main class library that C# programs use. The runtime part is called the **Common Language Runtime** (usually abbreviated to CLR) because it supports not just C#, but any .NET language. Microsoft also offers Visual Basic, F#, and .NET extensions for C++, for example. The CLR has a Common Type System (CTS) that enables code from multiple languages to interoperate freely, which means that .NET libraries can normally be used from any .NET language—F# can consume libraries written in C#, C# can use Visual Basic libraries, and so on.

C# compiler uses a model called **managed code**. With managed code, the compiler does not generate the machine code that the CPU executes. Instead, the compiler produces a form of binary code called the **intermediate language** (IL). The executable binary is produced later, usually, although not always, at runtime.

- Benefit: compiler’s output is not tied to a single CPU architecture. With .NET, you can compile a single component that contains just one version of the code, and it can run on any of architectures.

CLR uses an approach called **just-in-time** (JIT) compilation, in which each individual function’s machine code is generated the first time it runs.

The cross-platform .NET is where most of the new development of .NET has occurred for the last few years.

**Package repository** for .NET components：http://nuget.org, which is where Microsoft publishes all of the .NET libraries it produces that are not built into .NET itself, and it is also where most .NET developers publish libraries they’d like to share.

But which version should you build for?

This is a two-dimensional question:
 - there is the runtime implementation (.NET, .NET Framework, Mono),
 - and also the version (e.g., .NET Core 3.1 or .NET 6.0; .NET Framework 4.7.2 or 4.8).
 
Many authors of popular open source packages distributed through NuGet support a plethora of versions, old and new.

**.NET Standard**: defines common subsets of the .NET class library’s API surface area.
 - Not for .NET 5 and later versions. Because they adopt a different approach to establishing uniformity that eliminates the need for .NET Standard in most scenarios.
 - However, if you want to share code between .NET Framework and any other .NET implementation, such as .NET Core, your library should target **.NET Standard 2.0**.
 - No new versions of .NET Standard will be released.
 - source: https://docs.microsoft.com/en-us/dotnet/standard/net-standard

Visual Studio is an **Integrated Development Environment** (IDE), so it takes an “everything included” approach.

A project can belong to more than one solution. In a large codebase, it’s common to have **multiple .sln files** with different combinations of projects. You would typically have a main solution that contains every single project, but not all developers will want to work with all the code all of the time.
 - e.g. Someone working on the desktop application in our hypothetical example will also want the shared library, but probably has no interest in loading the web project.

**Boilerplate** is the name used to describe code that needs to be present to satisfy certain rules or conventions, but which looks more or less the same in any project.

Namespaces:
- without namespace:
  - it becomes hard to guarantee uniqueness.
  - it can become challenging to discover the API you need.


## Coding Style Convention

.NET source code analysis:
- Starting in .NET 5, these analyzers are included with the .NET SDK and you don't need to install them separately. If your project targets .NET 5 or later, code analysis is enabled by default.
- For .NET Core, .NET Standard, or .NET Framework, you must manually enable code analysis by setting the `EnableNETAnalyzers` property to `true`.

StyleCop:
- third-party analyzer (https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/overview)
- originally from Microsoft (https://en.wikipedia.org/wiki/StyleCop). 
- used by dotnet open source repos (https://github.com/search?q=org%3Adotnet+StyleCop&type=code)
- nuget: https://www.nuget.org/packages/StyleCop.Analyzers

### Using directives

> SA1208: System using directives must be placed before other using directives.
>
> SA1210: Using directives must be ordered alphabetically by namespace.

Visual Studio > Options > C# > Advanced > `Place 'System' directives first when sorting usings`.

## Generics

**type parameters**: placeholders that let you plug in different types at compile time.

**generic type**: write just one type and then produce multiple versions of it.

`List<T>` is a generic class, `T` is a type parameter.

When there's only one parameter, `T` is usually the name for type parameter. For multiparameter generics, use descriptive names prefixed with `T`, e.g. ` Dictionary<TKey, TValue>`.

A generic type declaration is **unbound**, meaning that there are type parameters that must be filled in
to produce a complete type.

**Constraints**: C# allows you to state that a type argument must fulfil certain requirements.
- supports only six kinds of constraints on a type argument:
  - type constraint, e.g. `where T : IComparable<T>`
  - reference type constraint, e.g. `where T : class`, This constraint prevents the use of value types such as `int`, `double`, or any `struct` as the type argument.
    - enables 3 features:
    - you can write code that tests whether variables of the relevant type are null.
    - you can use it as the target type of the `as` operator.
    - the ability to use certain other generic types.
    - useful for mocking/testing
  - value type constraint, e.g. `where T : struct`
  - `notnull`, especially for nullable references feature.
  - `unmanaged`,
    - it requires that the type argument be a value type. All of the type’s fields must be value types, and if any of those fields is not a built-in primitive type, then its type must in turn contain only fields that are value types, and so on all the way down.
    - This is mainly of interest in interop scenarios, because types that match the unmanaged constraint can be passed safely and efficiently to unmanaged code.
  - `new()`, e.g. `where T : new()`
  - `delegate`, e.g. `where T : Delegate`, All delegate types derive from `System.Delegate`.
  - `enum`, e.g. `where T : Enum`, all enumeration types derive from `System.Enum`.

**generic methods**: the generic type parameter list follows the method name and precedes the method’s normal parameter list.

**type inference**, C# compiler is often able to infer the type arguments for a generic method. With APIs that make extensive use of generics (such as LINQ), explicitly listing every type argument can make the code very hard to follow, so it is common to rely on type inference.

**Tuples**: `(int, int)`, or `ValueTuple<int, int>`, 
 - The ValueTuple family names its elements Item1, Item2, Item3, etc.
 - named tuple, ` (int X, int Y)`, When you declare a local variable with named tuple elements, those names are entirely a fiction maintained by C#—there is no runtime representation of those at all.

`Tuple<T>`, `Tuple<T1, T2>` vs `ValueTuple`:
 - The difference is that the `Tuple` family of generic types are all **classes**, whereas all the `ValueTuple` types are **structs**. The C# lightweight tuple syntax only uses the `ValueTuple` family.
 - The `Tuple` family has been around in the .NET class libraries for much longer though, so you often see them used in older code that needed to bundle a set of values together without defining a new type just for that job.

## Object Lifetime

In most cases, you do not need to take any action to reclaim memory. The runtime provides a **garbage collector** (GC), a mechanism that automatically discovers when objects are no longer in use, and recovers the memory they had been occupying so that it can be used for new objects.

### Garbage Collection
The CLR maintains a **heap**, a service that provides memory for the objects and values whose lifetime is managed by the GC.
- Each time you construct an instance of a class with new, or you create a new array object, the CLR allocates a new heap block.
- The GC decides when to deallocate that block.
- A heap block contains all the nonstatic fields for an object, or all the elements if it’s an array.

The CLR also adds a header.
- This includes a pointer to a structure describing the object’s type.
- also a field which is used for a variety of diverse purposes, including multithreaded synchronization and default hash code generation.
- Most types are fixed header size. There are only two exceptions, **strings** and **arrays**, which the CLR handles as special cases.
- On a 32-bit system, the header is 8 bytes long
- if you’re running in a 64-bit process, the header takes 16 bytes.
- An object that contained just one field of type `double` (an 8-byte type) would consume 16 bytes in a 32-bit process, and 24 bytes in a 64-bit process.

**objects** (i.e., instances of a class) always live on the heap.

for **value types**, The CLR stores some value-typed local variables on the **stack**, for example, but if the value is in an instance field of a class, the class instance will live on the heap, and that value will therefore live inside that object on the **heap**. And in some cases, a value will have an entire heap block to itself.

**Determining Reachability**
- The CLR starts by determining all of the **root references** in your program.
- A **root** is a storage location, such as a local variable, that could contain a reference and is known to have been initialized, and that your program could use at some point in the future without needing to go via some other object reference.
- Not all storage locations are considered to be roots. If an object contains an instance field of some reference type, that field is not a root.
- a reference type static field is a root reference

`100.ToString()`: call `ToString()` on an `int`.

The garbage collector cannot collect an object in use by an application while the application's code can reach that object. The application is said to have a **strong reference** to the object.

A **weak reference** permits the garbage collector to collect the object while still allowing the application to access the object. A weak reference is valid only during the indeterminate amount of time until the object is collected when no strong references exist.
- useful for objects that use a lot of memory, but can be recreated easily if they are reclaimed by garbage collection.
- useful for a cache dictionary: `private readonly Dictionary<TKey, WeakReference<TValue>> _cache = new ();`

The length of an object’s lifetime has an impact on how hard the GC must work. 
- Objects that live for a very short time are handled efficiently, because the memory they use will be recovered quickly in a generation 0 or 1 collection, and the amount of data that needs to be moved to compact the heap will be small.
- Objects that live for an extremely long time are also OK, because they will end up in generation 2. They will not be moved about often, because collections are infrequent for that part of the heap.

`GC.AllocateArray<byte>(4096, pinned: true)` (new in .NET 5.0): By passing true as that second argument, you are telling the CLR that you want this array to be pinned permanently. The CLR maintains an additional heap especially for this purpose called the **Pinned Object Heap** (POH). As with the large object heap (LOH), arrays in the POH will not be moved around, avoiding the overhead that pinning can otherwise cause.
- In fact, the best strategy for dealing with pinning is often just to use `MemoryPool<T>`. On runtimes without a POH, it takes steps to mitigate pinning overheads for you, and on .NET 5.0 or later it will allocate memory in the POH by default.

when would you **force a garbage collection**? If you happen to know that your application has just finished some work and is about to go idle, it might be worth considering forcing a collection.
- Garbage collections are usually triggered by activity, so if you know that your application is about to go to sleep—perhaps it’s a service that has just finished running a batch job, and will not do any more work for another few hours

### Finalizer

CLR doesn’t guarantee to call the **finalizer** straightaway. Finalizers run on a dedicated thread. Because current versions of the CLR have only one finalization thread (regardless of which GC mode you choose), a slow finalizer will cause other finalizers to wait.

The main reason finalization exists at all is to make it possible to write .NET types that are wrappers for the sorts of entities that are traditionally represented by handles—things like files and sockets.
- If you are writing code that wraps a handle, you should normally use one of the built-in classes that derive from `SafeHandle`.

Some classes contain a finalizer that checks that the object was not abandoned in a state where it had unfinished work. you could write a finalizer that checks to see if the object was put into a safe state before being abandoned (e.g. `Flush`, `Close`), raising an error if not. This would provide a way to discover when programs have forgotten to clean things up correctly.

If you write a finalizer, you should disable it when your object is in a state where it no longer requires finalization, because finalization has its costs. If you offer a `Close` or `Flush` method, finalization is unnecessary once these have been called, so you should call the `System.GC` class’s `SuppressFinalize` method to let the GC know that your object no longer needs to be finalized. If your object’s state subsequently changes, you can call the `ReRegisterForFinalize` method to reenable it.

### IDisposable

This then provides the object with an opportunity to free up resources it may have allocated. If the object being disposed of was using resources represented by handles, it will typically close those handles immediately rather than waiting for finalization to kick in (and it should suppress finalization at the same time).

Dispose does not cause the GC to do something.
- Dispose does not finalize the object.
- It does not cause the object to be garbage collected.
- The CLR does not handle IDisposable or Dispose differently than any other interface or method.

When to use:
- It’s imperative that we close connection objects as soon as we can, without waiting for the GC to tell us which ones are out of use.
- It’s critically important for any object that is a front for something that lives outside the CLR, such as a file or a network connection.

If a resource is expensive to create, you may want to reuse it. This is often the case with database connections, so the usual practice is to maintain a **pool** of connections. Instead of closing a connection when you’re finished with it, you return it to the pool, making it available for reuse. (Many of .NET’s data access providers can do this for you.)
- The `IDisposable` model is still useful here. When you ask a resource pool for a resource, it usually provides a wrapper around the real resource, and when you dispose that wrapper, it returns the resource to the pool instead of freeing it. So calling `Dispose` is really just a way of saying, “I’m done with this object,” and it’s up to the `IDisposable` implementation to decide what to do next with the resource it represents.

C# supports IDisposable in three ways: `foreach` loops, `using` statements, and `using` declarations.

This pattern is called the Dispose Pattern, but do not take that to mean that you should normally use this when implementing IDisposable. On the contrary, it is extremely unusual to need this pattern. Even back when it was invented, few classes needed it, and now that we have SafeHandle, it is almost never necessary. (SafeHandle was introduced in .NET 2.0, so it has been a very long time since the Dispose Pattern was broadly useful.)
The pattern’s main relevance today is that you sometimes encounter it in old types such as `Stream`.

Do not dispose the object that you want to reuse.

### Boxing

**Boxing** is the process that enables a variable of type `object` to refer to a value type (e.g. `int`). An `object` variable is capable only of holding a reference to something on the heap. a box generated by C# is essentially a reference type wrapper for a value.

Implicit boxing can occasionally cause problems for either of two reasons. 
- First, it makes it easy to generate extra work for the GC. The CLR does not attempt to cache boxes (causes problem in a for loop)
- Second, each box operation (and each unbox) **copies** the value, which might not provide the semantics you were expecting.

Boxing used to be a much more common occurrence in early versions of .NET. Before generics arrived in .NET 2.0, collection classes all worked in terms of `object`, so if you wanted a resizable list of integers, you’d end up with a box for each int in the list. Generic collection classes do not cause boxing—a `List<int>` is able to store unboxed values directly

`Nullable<T> `itself is a value type, so if you attempt to get a reference to it, the compiler will generate code that attempts to box it, as it would with any other value type. However, at runtime, the CLR will not produce a box containing a copy of the `Nullable<T>` itself.
- `HasValue = false` -> return `null`.
- otherwise, produce a box of type `int`.

```cs
object boxed = 42;
int? nv = boxed as int?; // correct
int? nv2 = (int?) boxed; // correct
int v = (int) boxed; // correct
```

## Delegates, Lambdas, and Events

The most common way to use an API is to **invoke the methods and properties** its classes provide, but sometimes, things need to work in reverse—the API may need to call your code, an operation often described as a **callback**.

```cs
public static int FindIndex<T>(
  T[] array,
  Predicate<T> match)
```

**predicate**: in the sense of a function that determines whether something is true or false.

Instances of delegate types are usually just called delegates, and they refer to methods. A method is compatible with (i.e., can be referred to by an instance of) a particular delegate type if its signature matches.

**Multicast delegates**: delegates can refer to more than one method. This is mostly of interest in notification scenarios where you may need to invoke multiple methods when some event occurs.
- Delegate combination always produces a new delegate. The Combine method does not modify either of the delegates you pass it.
- we rarely call `Delegate.Combine` explicitly, because C# has built-in support for combining delegates. You can use the `+` or `+=` operators.

```cs
//combining the three delegates into a single multicast delegate. The two resulting delegates are equivalent
Predicate<int> megaPredicate1 = greaterThanZero + greaterThanTen + greaterThanOneHundred;

Predicate<int> megaPredicate2 = greaterThanZero;
megaPredicate2 += greaterThanTen;
megaPredicate2 += greaterThanOneHundred;
```

`-` or `-=` operators: produce a new delegate that is a copy of the first operand, but with its last reference to the method referred to by the second operand removed. This turns into a call to `Delegate.Remove`.

If you want to get all the return values from a multicast delegate, you can take control of the invocation process. Delegates offer a `GetInvocationList` method, which returns an array containing a single-method delegate for each of the methods to which the original multicast delegate refers.

The .NET class library provides several useful delegate types
- `Action`, this type has a `void` return type. take up to 16 parameters.
- `Func`, allows any return type. take up to 16 parameters.

reason to define a custom delegate type:
- there are some cases that cannot be expressed with generic type arguments.  if you need a delegate that can work with `ref`, `in`, or `out` parameters.
- you cannot use a `ref struct` as a generic type argument. e,g, `Action<T>` type `T` can't be the `ref struct` type `Span<int>` (compiler error `Action<Span<int>>`).

sometimes it’s useful to define a specialized delegate type to **indicate particular semantics**.
- `Predicate<T>` vs `Func<T, bool>`, `Predicate<T>` has an implied meaning: it makes a decision about that `T` instance, and returns `true` or `false` accordingly; not all methods that take a single argument and return a `bool` necessarily fit that pattern.

`in T`: the type parameter `T` in `Predicate<T>` is **contravariant**, which means that if an implicit reference conversion exists between two types, `A` and `B` (e.g. `string` and `object`), an implicit reference conversion also exists between the types `Predicate<B>` and `Predicate<A>`.

`out T`: **Covariance** also works in the same way as it does with interfaces, so it would typically be associated with a delegate’s **return** type.

### anonymous functions

old way: `delegate (int value) { return value > 0; }` (**anonymous method**)

new way: `value => value > 0` (**lambda expression**)

In performance-critical code, you may need to bear the **costs of anonymous functions** in mind. If the anonymous function uses variables from the outer scope, then in addition to the delegate object that you create to refer to the anonymous function, you may be creating an additional one: an instance of the generated class to hold shared local variables. you’re creating additional objects, increasing the pressure on the garbage collector.

**Expression tree**: If that argument to Setup were just a delegate, there would be no way for Moq to inspect it.

### Event

use the `+=` syntax to **attach** that delegate as the handler.

**raise** an event = **invoke** all the handlers that have been attached to the event.

Events are particularly important for UI elements.

Standard Event Delegate Pattern:
- This pattern requires the delegate’s method signature to have two parameters. The first parameter’s type is `object`, and the second’s type is either `EventArgs` or some type derived from `EventArgs`.

`public delegate void EventHandler(object sender, EventArgs e);`

if you want your API to support the **asynchronous** features in C#, you will need to implement the pattern which uses **delegates**, but not events, for completion callbacks.

if you are writing a **UI element**, **events** will most likely be appropriate, because that’s the predominant idiom.

Events, on the other hand, provide a clear way to **subscribe** and **unsubscribe**.

If there will be multiple subscribers for a notification, an event could be the best choice. This is not absolutely necessary, because any delegate is capable of multicast behavior.

## LINQ

Language Integrated Query (LINQ) 

**Deferred Evaluation**: they return objects that will perform the work on demand. has the benefit of not doing work until you need it, and it makes it possible to work with infinite sequences.

A LINQ provider typically uses `IQueryable<T>` if it wants these expression trees. And that’s usually because it’s going to inspect your query and convert it into something else, such as a SQL query.

```cs
int[] numbers = { 1, 2, 3, 4, 5 };
string[] letters = { "A", "B", "C" };
IEnumerable<string> flattened = numbers.SelectMany(
  number => letters,
  (number, letter) => letter + number);
// A1 B1 C1 A2 B2 C2 A3 B3 C3 A4 B4 C4 A5 B5 C5
```

`Chunk()` This can be useful in cases where it’s more efficient to process multiple items in a batch than handling them one at a time. That’s often true when IO is involved—there are fixed minimum costs for writing data to disk or sending it over the network, which can often mean that the cost of writing or sending a single record is only slightly smaller than a single operation that writes or sends 10 records. a.k.a `Buffer()` in some libraries.

Some LINQ providers therefore choose to offer asynchronous versions of these operators. For example, EF Core offers `SingleAsync`, `ContainsAsync`, `AnyAsync`, `AllAsync`, `ToArrayAsync`, and `ToListAsync`, and equivalents for the other operators we’ll see that perform immediate evaluation.

.NET 6.0 adds a refinement to `SingleOrDefault`, `FirstOrDefault`, and `LastOrDefault`. These get new overloads enabling you to supply a value to return as the default, instead of the usual zero-like value.

.NET 6.0 adds an overload to Take that accepts a Range, enabling the use of the range syntax. For example, `source.Take(10..^10)` skips the first 10 and also the last 10 items (so it is equivalent to `source.Skip(10).SkipLast(10)`).

`source.Take(10..20)` has the same effect as `source.Skip(10).Take(10)`.

`source.Take(^10..^2)` is equivalent to `source.TakeLast(10).SkipLast(2)`.

>>> **Aggregation** The Sum and Average operators add together

### Namespace match folder structure

> Warning IDE0130 Namespace ... does not match folder structure

This is disabled in dotnet/roslyn-analyzers (https://github.com/search?q=org%3Adotnet+IDE0130&type=code)

- It's an anti-pattern (https://medium.com/@steve_verm/matching-namespaces-to-folders-is-an-anti-pattern-e8edb3a6b8e5)
- because:
  - if not, refactoring folder structure would be a breaking change. Accoriding to semver, the project should increment its major version.
  - if not, more noise in the source control history, more potential merge conflicts.
  - it may reveal implementation detail which should not be exported outside.
  - the entire code base is made significantly more fragile and inflexible as a result of adopting this convention of matching folders to namespaces. Developers working inside the library are discouraged from doing simple refactorings, to avoid all this trouble that comes with it.
- https://stackoverflow.com/a/29255554

### IComparable

if there's `class Foo : IComparable<Foo> {...}`, you can get the comparer from `Comparer<Foo>.Default`. (https://stackoverflow.com/a/14960372/2431645)

For string comparisons, the `StringComparer` class is recommended over `Comparer<String>`.