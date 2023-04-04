# CRUD Application for Degrees and CVs

This is a demonstration application that showcases various technologies, including Entity Framework, Dapper, Mediator, Fluent Migration, and React. The application allows you to perform CRUD (Create, Read, Update, Delete) operations on degrees and CVs, as well as connect a CV to a degree and upload a file for each record.

## Technical Specifications

### Back End
- .NET Standard 7
- Mediator
- Fluent Migration
- Entity Framework
- Dapper

### Front End
- React

## Configuration

### Back End
- Define the connection string in the `appsettings.json` file
- Define the front-end URL for CORS

### Front End
- Define the back-end URL for CRUD operations

## Features
- The code is structured using the Mediator design pattern, which separates business logic and data access concerns
- Both Entity Framework and Dapper are used to interact with the database, demonstrating different ways of accessing data in a single application
- The front-end code is organized into reusable components, allowing for better maintainability and scalability



**Note**: Entity Framework and Dapper are not typically used together. Additionally, the backend and frontend are separate projects and solutions. 
