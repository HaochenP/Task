# Customer Management System
This is a simple application that allows users to manage customer records with functionalities to view, add, edit, and delete entries from a MySQL database. The backend contains API implementation for basic CRUD operation for customers. The frontend contains project for simple frontend for displaying customers in database and provides UI for CRUD operation.

# Setup
## Configure the Database
Edit Connection String: Update the ConnectionStrings in the backend's appsettings.json to match your MySQL server credentials and database name.
## Apply Migrations
Run Migrations: Navigate to the backend directory and use the command line to run:

dotnet ef database update

## Running the Application
### In Visual Studio
  Open the solution in Visual Studio.
  
  Set Multiple Startup Projects for both frontend and backend to run simultaneously.
  
  You can then start the application.
