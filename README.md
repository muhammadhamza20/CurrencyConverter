# CurrencyConverter

# Overview:
This is a .NET 8 Web API Project that consumes the public API endpoints exposed by https://www.frankfurter.app for performing different functions over currencies. 

Some of the functionalities are listed below:
- Fetching the latest exchange rates.
- Fetching the historical exchange rates.
- Allowing conversion of currencies.

# Project Startup:
This guide will walk you through the steps required to set up and run the application after cloning it from GitHub.

## Prerequisites:
- Install .NET 8 SDK: Ensure you have the .NET 8 SDK installed on your machine. You can download it from the .NET Download page. [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Code Editor: Use an IDE like Visual Studio, Visual Studio Code, or Rider. [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/), or [JetBrains Rider](https://www.jetbrains.com/rider/)
- Git: Ensure you have Git installed to clone the repository.[Git](https://git-scm.com/)

## Cloning the Repository
To get started, clone the repository to your local machine using Git.

- git clone [<repository-url>](https://github.com/muhammadhamza20/CurrencyConverter.git)
- cd CurrencyConverter

## Restoring Dependencies
Restore the project dependencies by running the following command:
- dotnet restore

## Building the Application
Build the project to ensure all dependencies and the project itself are properly set up:
- dotnet build

## Running the Application
To start the application, use the dotnet run command:
- dotnet run

By default, the application will run on http://localhost:5000. You should see an output indicating that the application is running and listening on a specific port.

## Project Structure
- Program.cs: Entry point of the application & Configuration for services and the application's request pipeline.
- Controllers: Folder containing API controllers.
- appsettings.json: Configuration file for application settings.

## Debugging
- Visual Studio
  Open the project in Visual Studio.
  Press F5 to run and debug.
- Visual Studio Code
  Open the project in Visual Studio Code.
  Use the integrated terminal to run dotnet run or configure a launch.json file for debugging.
- Command Line
  Use dotnet run to start the application from the command line.

# Additional Resources
- [.NET Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [ASP.NET Core Web API Documentation](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0)

# Contributing
Feel free to fork this repository and submit pull requests. For major changes, please open an issue first to discuss what you would like to change.
