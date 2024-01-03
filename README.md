# Net7 - Sistema Prayaga

## Basic Components

* Net7
* Entity Framework Core
* MediatR
* FluentValidation


## Folder Structure
* Controllers
* Application
* Infraestructure
* Domain
* Extensions


## How to use

Migrations 

```sh
dotnet ef migrations add [MigrationName] -o ./Infraestructure/Migrations
dotnet ef database update 
```

Clone using git.

Install it and run:

```sh
dotnet clean build
dotnet run
```
