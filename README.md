# CRUD-LotR (Lord of the Rings)

This project is an application that allows the management (CRUD) of characters from the "Lord of the Rings" universe using SAPUI5 technologies for the web interface and ASP.NET Core for the backend, integrating with an API to manipulate character, race, and profession data.

## Technologies Used

- **Frontend**: SAPUI5 (UI5), HTML5, CSS3, JavaScript
- **Backend**: ASP.NET Core, C#
- **Databsae**: SQLServer (via FluentMigrator for migrations)
- **API**: ASP.NET Core Web API
- **Tools**: Visual Studio, Visual Studio Code, Postman
- **Dependency Management**: npm (for frontend), NuGet (for backend)

## Features

- **Character Listing**: Displays a list of characters with filters by name, race, profession, and date range.
- **Character Creation and Editing**:  Allows creating new characters and editing existing ones, with specific validations.
- **Excel Data Import**: Functionality to import characters from Excel files.
- **Routing with SAPUI5**: Navigation based on routes, where applied filters update the URL, allowing searches to be replicated via URL.

## Prerequisites

- [Node.js](https://nodejs.org/) and npm installed
- [.NET SDK](https://dotnet.microsoft.com/download)
- Visual Studio ou Visual Studio Code
