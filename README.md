Tacta_ShoppingList is a straightforward shopping list creator with convenient management options. This web application is built using the .NET and Angular frameworks, utilizing tools such as Visual Studio 2022, WebStorm 2022, and SQL Server (SQLite can also be used).

Setup Instructions

Visual Studio:
Open the solution in Visual Studio.
Verify the connection string in appsettings.json in the API project.
Check the Swagger URL in the environments folder in the Client project.
Make any necessary changes to the connection string and Swagger URL.
Run the following command in the Package Manager Console: update-database to apply the pre-made migration with user seed data.
Before running the application, change the running option to ISS Express to match the URL being used.

WebStorm:
Open the project in WebStorm.
Run the command npm install to install all project dependencies.
These steps ensure a smooth setup for the application. Feel free to reach out if you encounter any issues during the setup process.
