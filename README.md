# Clean Architeture and IdentityServer4

This repo is a fork from https://github.com/thanhle0212/Self-Order-System for use as a project baseline.  To learn more about the original project, visit [Using Dapper and SQLKata in .NET Core for high-performance application](https://medium.com/@letienthanh0212/using-dapper-and-sqlkata-in-net-core-for-high-performance-application-716d5fd43210)

The forked repo is then integrated with IdentityServer4 to support Identity and Access Management.  This repo uses the design pattern similar to the [jasontaylordev
/CleanArchitecture](https://github.com/jasontaylordev/CleanArchitecture).  To learn more about IdentityServer4 integration to support enterprise applications, visit [DevKit API Security — IdentityServer4 with Admin UI, ASP.NET WebAPI, and Angular Tutorial](https://medium.com/scrum-and-coke/devkit-webapi-security-d7a45e34a5cd?source=friends_link&sk=d995ee034b01e79077b77925e5bae1b2) 

# Self Order System

NOTE: Run database/database_scripts.sql to create the database

Architecture
- Clean Architecture

Backend technology stack
- ASP .NET Core 3.1
- Dapper (Micro ORM)
- SQLKata for SQL Query Builder
- Web API
- Fluent Validation
- Swagger
- AutoMapper

Front-end 
- Blazor (comming soon)

Design Patterns
- CQRS
- Mediator
- Dependency Injection
