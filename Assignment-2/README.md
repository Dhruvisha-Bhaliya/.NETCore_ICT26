# Practical Assignment – 2

## Assignment Objectives

1) Create a C# application to demonstrate use of Generic Abstract class.

## Project Type
- **Application Type:** Console Application  
- **Framework:** .NET Core  
- **Language:** C#  
- **Project Template:** **ConsoleApp** (must always be selected while creating the project)

## Important Note
- **Always select the project template as `ConsoleApp`** when creating the console application in .NET Core.

## Application Template

![Project Template – Console App](ScreenTemplate/Project%20Template%20Console%20App.png)


2) Create an MVC Core web application to perform CRUD operations for Project allocation to employees using EntityFramework. Also create advance search functionality to search employee on project.

## Project Type
- **Application Type:** MVC Application 
- **Framework:** .NET Core  
- **Language:** C#  
- **Project Template:** **ASP.NET Core Web App(Model-View-Controller)** (must always be selected while creating the MVC project)

**Step - 1** :-

In Sql Server Management Studio -> Connect Server -> In Database -> Create New Database

**Step - 2** :-

---->  Go to Visual Studio -> Data Connections -> Add Connection -> 

**Data source** = Mirosoft SQL Server(Sql Client)
**Server Name** = paste server name that copied from Sql Server Management studio server properties
**Trust Server Certificate** -> must check true
Select Database Name 
**Test Connection** -> Must Succeeded.
Final Click OK

![Connection – ASP.NET Core Web App(Model-VIew-Controller)](Assignment-2_2/screenshots/Connection%20success.png)

**Step - 3** :-

![NuGet packages – ASP.NET Core Web App(Model-VIew-Controller)](Assignment-2_2/screenshots/NuGet%20packages.png)

- Above packages must download 

- **CMD For Model Creation:** Scaffold-DbContext "Name=ProjectAllocateString" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

- In Above CMD Name=ConnectionString <- that define in appsettings.json file

**Step - 4** :-

In **Program.cs** File Also Add Services

![builder Services – ASP.NET Core Web App(Model-VIew-Controller)](Assignment-2_2/screenshots/builder%20services.png)

**Step - 5** :-

-- **How to Make Controllers**

Controller -> Right Click -> Add -> Controller -> MVC -> Controller -> **MVC Controller with views,using Entity Framework** -> Select Model class as per requirements -> Select DbCOntext class -> ControllerName auto created as per requirements also change manually

## Important Note
- **Always select the project template as `ASP.NET Core Web App(Model-VIew-Controller)`** when creating the MVC application in .NET Core.

## Application Template

![Project Template – ASP.NET Core Web App(Model-VIew-Controller)](Assignment-2_2/screenshots/MVC%20selection%20template.png)


3) Demonstrate use of String Indexer and multivalued Indexer to search data from a Generic collection.
---

## Project Type
- **Application Type:** Console Application  
- **Framework:** .NET Core  
- **Language:** C#  
- **Project Template:** **ConsoleApp** (must always be selected while creating the project)

## Important Note
- **Always select the project template as `ConsoleApp`** when creating the console application in .NET Core.

## Application Template

![Project Template – Console App](ScreenTemplate/Project%20Template%20Console%20App.png)