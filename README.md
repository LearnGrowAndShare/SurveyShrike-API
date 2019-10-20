

## # **[SurveyShrike-Api]([https://github.com/dreamerNcoder/SurveyShrike-AP](https://github.com/dreamerNcoder/SurveyShrike-AP))**
This is one of the main survey data provider  module for *SurveyShrike* application. This service only deals with the survey management part and has separate database. 

[![Build Status](https://travis-ci.org/dreamerNcoder/SurveyShrike-API.svg?branch=master)](https://travis-ci.org/dreamerNcoder/SurveyShrike-API)


## Readings  
**Clean Architecture** – pplications that follow the Dependency Inversion Principle as well as the Domain-Driven Design (DDD) principles tend to arrive at a similar architecture. This architecture has gone by many names over the years. One of the first names was Hexagonal Architecture, followed by Ports-and-Adapters. More recently, it's been cited as the [Onion Architecture](https://jeffreypalermo.com/blog/the-onion-architecture-part-1/) or [Clean Architecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html).
![enter image description here](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/media/image5-7.png)

Each layer communication diagram
![enter image description here](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/media/image5-8.png)

## Getting Started

Use these instructions to get the project up and running.
### Prerequisites
You will need the following tools:

-   [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/)  (version 16.3 or later)
-   [.NET Core SDK 3](https://dotnet.microsoft.com/download/dotnet-core/3.0)
-   [Node.js](https://nodejs.org/en/)  (version 10 or later) with npm (version 6.11.3 or later)
- 
### Setup

Note: It requires the [Identity server](https://github.com/dreamerNcoder/SurveyShrike-IdentityServer/blob/master/README.md) to be up and running. 
Follow these steps to get your development environment set up:

1.  Clone the repository
    
2. Open the command prompt to project root directory _**SurveyShrike-API**_
    
    ```
    dotnet restore
    
    ```
    
3.  Next, build the solution by running:
    
    ```
    dotnet build
    
    ```
    
4.  Next, within the  `SurveyShrike-API` (root)  directory, launch the API server by running:
    
    ```
   dotnet run --project .\SurveyShrike-API\SurveyShrike-API.csproj
    
    ```
    
5.  Once the server has started, within the  navigate to ["http://localhost:61365/swagger](http://localhost:61365/swagger),
 If it does not give error, We have successfully started API server.
    
 ## Technologies
 -  .NET Core 3
-   ASP.NET Core 3
-   Entity Framework Core 3
## Project structure

![enter image description here](https://raw.githubusercontent.com/dreamerNcoder/SurveyShrike-API/de/image.png)

-   SurveyShrike-API- Actual identity server API's.
-   SurveyShrike-API.Application - It contains business-logic and types
-   SurveyShrike-API.Persistence - contains all external concerns like database & migrations
-   SurveyShrike-API.Domain- contains enterprise-wide logic and types
- -SurveyShrike-API.Common- common entities accross the api
