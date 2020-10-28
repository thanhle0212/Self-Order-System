# ASP.NET Core WebAPI, Dapper, SQLKata and IdentityServer4

## Credit
This repo is a fork from [thanhle0212/Self-Order-System](https://github.com/thanhle0212/Self-Order-System).  The author Thanh Le published an excellent blog about [Using Dapper and SQLKata in .NET Core for high-performance application](https://medium.com/@letienthanh0212/using-dapper-and-sqlkata-in-net-core-for-high-performance-application-716d5fd43210)

## Background
I am working on a modernization project where the backend databases have ton of procedures.  The plan is to use Dapper to re-use existing procedures and provide data access via WebAPI.   This repo is based on the Clean Architecture, utilizing best-practice design patterns and .NET CORE libaries. I decided to use the repo as the baseline project and enhanced it with Identity and Access Management product IdentityServer4.   

I keep the original repo in the "forked" branch.   If you want to see the code changes as a result of IdentityServer4 integration, compare the Forked vs Master branch.  If you are new to IdentityServer4, check out my blog [DevKit API Security — IdentityServer4 with Admin UI, ASP.NET WebAPI, and Angular Tutorial](https://medium.com/scrum-and-coke/devkit-webapi-security-d7a45e34a5cd)

# Self Order System

NOTE: Run database/database_scripts.sql to create the database

Architecture
- Clean Architecture

Backend technology stack
- ASP.NET Core 3.1
- Dapper (Micro ORM)
- SQLKata for SQL Query Builder
- Web API
- Fluent Validation
- Swagger
- AutoMapper
- IdentityServer4

Design Patterns
- CQRS
- Mediator
- Dependency Injection
