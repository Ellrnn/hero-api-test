# BNP .NET Technical Challenge

This is a [minimal API](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/min-web-api?view=aspnetcore-7.0&tabs=visual-studio-code) project modded to implement [REPR Design Pattern](https://deviq.com/design-patterns/repr-design-pattern) using [FastEndpoints](https://fast-endpoints.com/) and [use cases](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

The idea of this approach is to get as close as possible to how our brain organizes information. First we think about the thing, then what the thing is capable of doing.

If you noticed similarities with the approach that frameworks like React, Angular, Vue && Laravel, it's not for nothing. The idea is that any DEV can work on this architecture regardless of knowledge background with no compromising performance and scalability. 😎


## Getting Started

- Install nuget packages

```bash
dotnet restore
```

- Then, run it with 

```bash
dotnet run --project ./src/backend-challenge.csproj
```

- OK, now you can open [http://localhost:3000/swagger](http://localhost:3000/swagger) with your browser to see the result.


You can run the following command to execute the tests

```bash
dotnet test
```


## Project Arch

This project has the following structure

```
root
|
-📂 src                 // main project
|
--📂 Context            // EF core files, extensions and interceptors
|
--📂 Modules            // Feature folders, eg: entities, features, actions etc.
|
---📂 <Entity name>     // Group of all what is needed to implement the feature
|
----📂 [repositoty]     // If the entity needs to be persisted, here are the files needed for persistence configuration
|
-----🗒️ data.cs         // Repo implementation
-----🗒️ entity.cs       // Entity class
-----🗒️ interface.cs    // Repo interface
|
----📂 [useCases]       // Where the capabilities (use cases) of the entity are configured
|
-----📂 [useCase name]  
|
------🗒️ C#...          // useCase implementation
|
-📂 test                // Unit tests project

```

## Challenges

We give an example entity called **HERO** with CRUD implemented. You can use it as a reference to complete the challenges.


1. [Simple validation](src/Modules/hero/first_challenge.md)
2. [Improving endpoint](src/Modules/hero/second_challenge.md)
3. [Hero relations](src/Modules/hero/third_challenge.md)
4. [TO-DO CRUD](src/Modules/todo/fourth_challenge.md)
5. [Refactor challenge](src/Modules/refactor/fifth_challenge.md)
