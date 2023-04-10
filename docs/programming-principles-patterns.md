# Principles And Patterns

## Creational Patterns

### Factory Design Pattern

A factory is an object which is used for creating other objects. providing a way to encapsulate the creation logic in a separate class or method, called a factory, rather than directly creating objects using the `new` keyword.

Solve the problem: loose coupling between the classes that use the objects and the classes that create the objects.

### Factory Method Design Pattern

Defines an interface for creating an object, but lets the subclasses decide which class to instantiate. The Factory method lets a class defer instantiation to subclasses.

```cs
public abstract class MyFactory
{
    protected abstract MyProduct MakeProduct();

    public MyProduct CreateProduct()
    {
        return this.MakeProduct();
    }
}

public class My1stFactory : MyFactory
{
    protected override MyProduct MakeProduct()
    {
        return new Product1();
    }
}
```

### Abstract Factory Design Pattern

provides a way to encapsulate a group of individual factories that have a common theme without specifying their concrete classes.

a super factory that creates other factories.

```cs
public interface ISuperFactory
{
    ICategory1 CreateCategory1();
    ICategory2 CreateCategory2();
}

public class RegularProductFactory : ISuperFactory
{
    public ICategory1 CreateCategory1()
    {
        return new RegularProduct1();
    }
    public ICategory2 CreateCategory2()
    {
        return new RegularProduct2();
    }
}

public class LuxuryProductFactory : ISuperFactory
{
    public ICategory1 CreateCategory1()
    {
        return new LuxuryProduct1();
    }
    public ICategory2 CreateCategory2()
    {
        return new LuxuryProduct2();
    }
}
```

### Builder Design Pattern

builds a complex object using many simple objects and using a step-by-step approach.

### Fluent interface (concept) + method chaining (implementation)

```cs
//Create an Instance of Wrapper class i.e. FluentEmployee
FluentEmployee obj = new FluentEmployee();
//Call Methods one by one using dot Operator whose Return Type is FluentEmployee
obj.NameOfTheEmployee("Anurag Mohanty")
        .Born("10/10/1992")
        .WorkingOn("IT")
        .StaysAt("Mumbai-India");
```

### Prototype Design Pattern

specifies the kind of objects to create using a prototypical instance, and create new objects by copying this prototype

a way to create (clone) new or cloned objects from the existing object of a class

Shallow copy (`this.MemberwiseClone()`, value type) vs deep copy (value & reference type)

### Singleton

ensure that only one instance of a particular class is going to be created and then provide simple global access to that instance for the entire application.

- constructor that should be private and parameterless.
- class should be declared as sealed
- create a private static variable that is going to hold a reference to the singleton instance of the class.
- create a public static property/method which will return the singleton instance of the class.

examples: service proxies, database connection, logs, data sharing, caching

```cs
// not thread-safe
public sealed class Singleton
{
    private static int Counter = 0;
    private static Singleton Instance = null;

    public static Singleton GetInstance()
    {
        if (Instance == null)
        {
            Instance = new Singleton();
        }
        
        return Instance;
    }
    
    private Singleton()
    {
        Counter++;
        Console.WriteLine("Counter Value " + Counter.ToString());
    }
    
    public void PrintDetails(string message)
    {
        Console.WriteLine(message);
    }
}

// thread-safe
  public sealed class Singleton
  {
      private static int Counter = 0;
      private static Singleton Instance = null;
      private static readonly object Instancelock = new object();
      
      public static Singleton GetInstance()
      {
          lock (Instancelock) // Using locks to synchronize the method. only one thread can access it at any given point in time.
          {
              if (Instance == null)
              {
                  Instance = new Singleton();
              }
          }

          return Instance;
      }
      
      private Singleton()
      {
          Counter++;
          Console.WriteLine("Counter Value " + Counter.ToString());
      }
      
      public void PrintDetails(string message)
      {
          Console.WriteLine(message);
      }
  }
```

### Object Pooling

object pool design pattern is a creational design pattern that is used to recycle objects rather than recreate them each time the application needs them. By keeping reusable instances of objects in a resource pool, and doling them out as needed, this pattern helps to minimize the overhead of initializing, instantiating, and disposing of objects and to boost the performance of your application. Create an object pool by using a `ConcurrentBag`.

---

## SOLID principles:

- Single Responsibility Principle
   - a class should do one thing and therefore it should have only a single reason to change (database logic, logging logic, and so on)
- Open-Closed Principle
   - classes should be open for extension (adding new functionality) and closed to modification (changing the code of an existing class).
- Liskov Substitution Principle
   - subclasses should be substitutable for their base classes. (the child class inherits everything that the superclass has. The child class extends the behavior but never narrows it down.)
- Interface Segregation Principle
   - separating the interfaces. (Clients should not be forced to implement a function they do no need.)
- Dependency Inversion Principle
   - classes should depend upon interfaces or abstract classes instead of concrete classes and functions.

---

**Cohesion** refers to what the class (or module) can do. Low cohesion would mean that the class does a great variety of actions - it is broad, unfocused on what it should do. High cohesion means that the class is focused on what it should be doing, i.e. only methods relating to the intention of the class.

**Coupling** refers to how related or dependent two classes/modules are toward each other. For low coupled classes, changing something major in one class should not affect the other. High coupling would make it difficult to change and maintain your code; since classes are closely knit together, making a change could require an entire system revamp.

Good software design has **high cohesion** within modules and **low coupling** between modules.
