# Library API
A simple API for managing a library system.

## Prerequisites
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - ORM for .NET
- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/)
- [AutoMapper](https://www.nuget.org/packages/automapper/)
## Building the Project

To build the project, follow these steps:

1. **Clone the Repository**
    ```bash
   git clone https://github.com/jaymonrivera/Zigzag.Library.API.git
   cd Zigzag.Library.API

2. **Restore Dependencies**
   ```bash
   dotnet restore

3. **Build the Solution**
   ```bash
   dotnet build

## Running the Project
1. **Run the Application**

   Navigate to the API project directory and run.
   
   ```bash
   dotnet run --project Zigzag.Library.API/Zigzag.Library.API.csproj

2. **Access the API**

   Use the swagger
   ```
   https://localhost:7203/swagger/index.html
