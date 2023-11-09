# CRUD Operations System Using ASP.NET Core MVC

This project is a CRUD (Create, Read, Update, Delete) operations system built with ASP.NET Core MVC. It allows you to manage employee and department information using Entity Framework Core, Microsoft SQL Server, C#, Bootstrap, and jQuery. The project follows a 3-Tier architecture for organized development.

## Features

- Create, Read, Update, and Delete employees and departments.
- Store data in a Microsoft SQL Server database using Entity Framework Core.
- Utilize Bootstrap and jQuery for a responsive and interactive user interface.
- Implement a 3-Tier architecture for clean separation of concerns and maintainability.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- **ASP.NET Core SDK**: Make sure you have the ASP.NET Core SDK installed on your machine.

- **SQL Server**: You need Microsoft SQL Server to host the project's database. Ensure you have a running instance with the necessary database configuration.

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/your-repo-name.git
   
- Open the project in your favorite code editor.

- Configure the database connection in the appsettings.json file:
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server;Database=your-database;User Id=your-username;Password=your-password;"
}

- Open the Package Manager Console in Visual Studio or use the CLI to apply Entity Framework migrations:
dotnet ef database update

- Build and run the project:
dotnet run

Open a web browser and navigate to http://localhost:5000 to access the application.

**Usage
- Use the web interface to create, read, update, and delete employees and departments.
- The application provides a user-friendly interface for managing your data.

**Folder Structure
Controllers: Contains the application's controllers.
Models: Define the data models used in the project.
Views: Store the views used for the web interface.
Data: Contains the database context and data access logic.
Services: Define application services and business logic.
wwwroot: Houses static files like CSS, JavaScript, and images.

**Acknowledgments
This project was inspired by the need for a simple CRUD system using ASP.NET Core MVC.
Special thanks to Route Academy for their invaluable contributions.

**Contact
If you have any questions or need further assistance, feel free to contact the project maintainer at youmna.gabr97@gmail.com.
