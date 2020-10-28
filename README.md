# ASP.NET Core WebAPI, Dapper, SQLKata and IdentityServer4

## Credit
This repo is a fork from [thanhle0212/Self-Order-System](https://github.com/thanhle0212/Self-Order-System).  The author Thanh Le published an excellent blog about [Using Dapper and SQLKata in .NET Core for high-performance application](https://medium.com/@letienthanh0212/using-dapper-and-sqlkata-in-net-core-for-high-performance-application-716d5fd43210)

## Background
I am working on a modernization project where the backend databases have ton of procedures.  The plan is to use Dapper to call existing procedures to provide data as a service  via WebAPI.   This repo is based on the Clean Architecture which utilizes best practices in design patterns and .NET CORE libaries. I decided to use the repo as the baseline project and enhanced it with Identity and Access Management product IdentityServer4.   

I keep the original repo in the "forked" branch.   If you want to see the code changes as a result of IdentityServer4 integration, compare the "forked" vs "master" branch.  If you are new to IdentityServer4 and look for an enterprise application security solution, check out my blog [DevKit API Security — IdentityServer4 with Admin UI, ASP.NET WebAPI, and Angular Tutorial](https://medium.com/scrum-and-coke/devkit-webapi-security-d7a45e34a5cd)

## Enhancements to Original Repo
- Integration with IdentityServer4 to secure WebAPI with policy
- Implementing Dependency Injection for SQLKata
- Adding paging example code to use SQLData "ForPage"
- Adding Swagger filter to support Bearer Token

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
