# EFSamples

A repo to play around with Entity Framework code and store examples of how to perform common tasks.

Some interesting things to note:

## Relationships

**One-to-many**

Each subject is `TaughtBy` a single teacher (who is a `Person`).

**Many-to-many**

There is a many-to-many relationship between `Person` and `Subject`. A student (who is a `Person`) can attend many subjects while a `Subject` has many `Students` (who are people).
