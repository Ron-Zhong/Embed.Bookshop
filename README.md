# Embed.Bookshop.API 
* Demo https://embed-bookshop.azurewebsites.net/
![image](https://user-images.githubusercontent.com/43414651/123507736-acaa8d00-d69d-11eb-9116-b4bc138fc0b7.png)


# Architecture Design (Cloud Hosted)
* Frontend SPA WebApp (Blazor WebAssembly)
* Identity Server with Social SSO Services
* Azure API Management (security and throttling)
* Web API (Azure AppService)
* Azure SQL Server with Azure Key Vaulte for securing database credential
* Function Apps (triggered by blob storage)
* Logic Apps (triggered by incoming emails)
![image](https://user-images.githubusercontent.com/43414651/123509975-52182d80-d6ab-11eb-96ff-193c42828c90.png)



# Solution (Layered Structure)
* Embed.Bookshop.API (BFF API/Microservices)
* Embed.Bookshop.Shared (Business Logic + Shared Classes)
* Embed.Bookshop.Database (Data Access Layer)
* Embed.Bookshop.UnitTest (TDD Project)
![image](https://user-images.githubusercontent.com/43414651/123507201-c696a080-d69a-11eb-92de-79d7dd7402a0.png)


# Database Design (SQL)
* Code-first approach with EF Core 5.0
![image](https://user-images.githubusercontent.com/43414651/123507251-03629780-d69b-11eb-96c6-9ca3c008b66e.png)


