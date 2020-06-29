# HR Application

## Introduction 
HR Application is MVC web application created with .Net Core 3.0. Application was created for typical recruitment scenario using various solutions provided by Microsoft Azure platform. HR Application provides functionality for Human Resource management activity as sending CV, notification system, users management, etc.

## Business requirements
* HTML Interface
* Ability to submit application for the user
* Ability to manage all data for administrator, including users role 
* Ability to attach and send CV file
* Candidate data need to be stored in database
* Candidates data need to be presented for HR team 
* HR team need to receive email notification about new candidate
* Sorting and searching

## Architecture
* Website by default hosted as Azure Web App
* SQL database and *Entity Framework*
* Storage service - *Azure Blob*
* User Authentication - *Azure AD B2C*
* Email notifications - *Azure SendGrid*

## Technology stack
* Visual Studio 2019
* Azure Services used: App Service, Azure SQL DB, Azure AD B2C, SendGrid
* ASP.NET Core MVC 3.0
* SQL and Entity Framework
* Authentication - OAuth 2.0, Azure AD B2C
* CD/CI - PowerShell, ARM
* Unit Tests, Integration tests - Xunit
* UI Tests - Selenium
* Documentation - Swagger
* Monitoring - ApplicationInsight

## Technical overview:
* Application uses Razor to generate UI
* User authentication using *Azure AD B2C*
* Application logic divided into three areas for different user role (admin, user, HR)
* Authorization based on user Claims (by custom implementation of IClaimsTransformation)
* Page visual layer provided by *Bootstrap*
* Application uses *Knockout* for data binding
* Data for views loaded asynchronously (request send via *AJAX*)
* Forms are validated on client and server site
* Saving data to database - data from View are maped to object and saved in database 
* Sending email notification via *SendGrid* when new CV was send by user
* Saving data to Azure Blob Storage -  files with CV are stored
* *Application Insight* integration
* *Entity Framework* for migrations, creating and updating database, auto migration on deply
* Quick deployment of Database and App Service on Azure using *ARM Tempaltes* and *PowerShell script*
* *Swagger* documentation created for API endpoints
* UI tests using *Selenium*
* Unit Tests, Integration tests created using *Xunit* framework

## Screenshots

<p align="center">
  <img src="/Demo/s1.jpg" width="600" height="300">
  <img src="/Demo/s2.jpg" width="600" height="300">
  <img src="/Demo/s3.jpg" width="600" height="300">
  <img src="/Demo/s4.jpg" width="600" height="300">
</p>

