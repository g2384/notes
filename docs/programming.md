## Domain-Driven Design

- keep domain model intact from anything that is related to **infrastructure**, **persistence**, **execution**, and **communication**.
- make domain model pure and keeps it focused on the business.
- Public API contracts:
  - Contracts are data-transfer objects (DTOs) and plain-old C# objects (POCOs)
  - they have no logic, only contain primitive types (complex types are okay) and do not require tricks to be serialised and deserialised.
  - Non-breaking changes: change property type (backward compatable); adding a new property;
- Commands allow users and other systems to execute actions in our domain model. When a command is successfully processed, the domain model state changes and new domain events are emitted.
- Layers of application:
  - the edge: accept requests, messaging, convert it to a command; edge components are heavily dependent on the communcation infrastructure;
  - application layer: accept commands from the edge, use domain model to handle these commands, load an entity, persist an entity;

---

- Object Relational Mapping (ORM) is a technique (Design Pattern) of accessing a relational database from an object-oriented language. e.g. Entity Framework.
- A database transaction is charactersized by 4 principles, ACID:
  - Atomicity: each statement in a transaction (to read, write, update or delete data) is treated as a **single unit**. Either the entire statement is executed, or none of it is executed. This property prevents data loss and corruption from occurring if, for example, if your streaming data source fails mid-stream.
  - Consistency: ensures that transactions only make changes to tables in **predefined, predictable** ways. Transactional consistency ensures that corruption or errors in your data do not create unintended consequences for the integrity of your table.
  - Isolation: when **multiple users** are reading and writing from the same table all at once, isolation of their transactions ensures that the concurrent transactions don't interfere with or affect one another. Each request can occur as though they were occurring one by one, even though they're actually occurring simultaneously.
  - Durability: ensures that changes to your data made by successfully executed transactions will be **saved**, even in the event of system failure.
