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
