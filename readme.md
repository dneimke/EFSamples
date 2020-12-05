# EntityFramework Examples

![Build EF Examples and run tests](https://github.com/dneimke/EFSamples/workflows/Builds%20EF%20Examples%20and%20runs%20tests/badge.svg)

A repo to play around with Entity Framework code and store examples of how to perform common tasks.

Some interesting things to note:


## Relationships

**One-to-many**

Each subject is `TaughtBy` a single teacher (who is a `Person`).

**Many-to-many**

There is a many-to-many relationship between `Person` and `Subject`. A student (who is a `Person`) can attend many subjects while 
a `Subject` has many `Students` (who are people). The [Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#many-to-many) 
site explains how this type of relationship works. There is also a brilliant walkthrough of the latest many-to-many features in 
[this YouTube video](https://www.youtube.com/watch?v=BIImyq8qaD4).

## Testing

The demonstrated scenarios are run as tests and are exercised against a SQL Server database instance. 