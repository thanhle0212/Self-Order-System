# ASP.NET Core WebAPI, Dapper, SQLKata and IdentityServer4

## Credit 
This repo is a fork from [thanhle0212/Self-Order-System](https://github.com/thanhle0212/Self-Order-System).  The author Thanh Le published an excellent blog [Using Dapper and SQLKata in .NET Core for high-performance application](https://medium.com/@letienthanh0212/using-dapper-and-sqlkata-in-net-core-for-high-performance-application-716d5fd43210)

## Background
I am working on a modernization project where the backend databases have ton of procedures.  The plan is to use Dapper to call existing procedures to provide data as a service  via WebAPI.   This repo is based on the Clean Architecture which utilizes best practices in design patterns and .NET CORE libaries. I decided to use the repo as the baseline project and enhanced it with Identity and Access Management product IdentityServer4.   

I kept the original repo in the "forked" branch.   If you want to see the code changes as a result of IdentityServer4 integration, compare the "forked" vs "master" branch.  If you are new to IdentityServer4 and look for an enterprise application security solution, check out my blog [DevKit API Security — IdentityServer4 with Admin UI, ASP.NET WebAPI, and Angular Tutorial](https://medium.com/scrum-and-coke/devkit-webapi-security-d7a45e34a5cd)

## Enhancements Made to Original Repo
- Integration example with IdentityServer4 to secure WebAPI using authorizaton filter policy
- Registering SQLKaa in dependency injection (DI) container
- Adding paging example code in CQRS for SQLKata "ForPage"
- Adding Swagger and Swagger filter to allow entering of Bearer Token in Swagger UI in order to test WebAPI

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

# IdentityServer4 Integration Code
### RegisterIdentityServerAuthentication.cs in IntantPOS.WebAI > Installers

    internal class RegisterIdentityServerAuthentication : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            //Setup JWT Authentication Handler with IdentityServer4
            //You should register the ApiName a.k.a Audience in your AuthServer
            //More info see: http://docs.identityserver.io/en/latest/topics/apis.html

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = config["Sts:ServerUrl"];
                        options.RequireHttpsMetadata = false;
                        options.ApiName = config["ApiResource:ApiName"];
                    });
        }
    }
### StartupHelpers.cs in IntantPOS.WebAI > Helpers
    public static class StartupHelpers
    {
        public static void AddAuthorizationPolicies(this IServiceCollection services, IConfiguration configuration)
        {
            var adminApiConfiguration = configuration.GetSection(nameof(AdminApiConfiguration)).Get<AdminApiConfiguration>();


            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationConsts.AdministrationPolicy,
                    policy =>
                        policy.RequireAssertion(context => context.User.HasClaim(c =>
                                (c.Type == JwtClaimTypes.Role && c.Value == adminApiConfiguration.AdministrationRole) ||
                                (c.Type == $"client_{JwtClaimTypes.Role}" && c.Value == adminApiConfiguration.AdministrationRole)
                            )
                        ));
            });
        }
    }

### ProductsController.cs in InstantPOS.WebAPI > Controllers

namespace InstantPOS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]

    public class ProductsController : CustomBaseApiController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {

        }
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<ProductResponseModel>> Get(int pageNo, int pageSize)
        {
            var query = new FetchProductQuery() { PageNo = pageNo, PageSize = pageSize };
            return await Mediator.Send(query);
        }



### ProductTypesController.cs in InstantPOS.WebAPI > Controllers

namespace InstantPOS.WebAPI.Controllers
{
    [Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]

    public class ProductTypesController : CustomBaseApiController
    {
        public ProductTypesController(IMediator mediator) : base(mediator)
        {

        }

        // We can update search criteria later
        [HttpGet]
        public async Task<IEnumerable<ProductTypeResponseModel>> Get()
        {
            var query = new FetchProductTypeQuery();
            return await Mediator.Send(query);
        }


# Registering SQLKata in DI container

### RegisterServices.cs in InstantPOS.Infrastructure

    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductTypeDataService, ProductTypeDataServices>();
            services.AddTransient<IProductDataService, ProductDataServices>();
            services.AddTransient<IDatabaseConnectionFactory>(e => {
                return new SqlConnectionFactory(configuration[Configuration.ConnectionString]);
            });
            services.AddScoped(factory =>
            {
                return new QueryFactory
                {
                    Compiler = new SqlServerCompiler(),
                    Connection = new SqlConnection(configuration[Configuration.ConnectionString]),
                    Logger = compiled => Console.WriteLine(compiled)
                };
            });
            return services;
        }
    }


# CQRS Paging Code

### FetchProductQuery.cs in InstantPOS.Application > CQRS > Product > Query
    public class FetchProductQuery : IRequest<IEnumerable<ProductResponseModel>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }

    }

    public FetchProductQueryHandler(IProductDataService productDataService): base(productDataService)
    {
    }
    public async Task<IEnumerable<ProductResponseModel>> Handle(FetchProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _productDataService.FetchProduct(request.PageNo, request.PageSize);

        return result;
    }

### FetchProductQueryHandler.cs in InstantPOS.Application > CQRS > Product > QueryHandler
    public class FetchProductQuery : IRequest<IEnumerable<ProductResponseModel>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }

    }

    public FetchProductQueryHandler(IProductDataService productDataService): base(productDataService)
    {
    }
    public async Task<IEnumerable<ProductResponseModel>> Handle(FetchProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _productDataService.FetchProduct(request.PageNo, request.PageSize);

        return result;
    }

### ProductDataServices.cs in InstantPOS.Infrastructure > DatabaseServices
    public async Task<IEnumerable<ProductResponseModel>> FetchProduct(int pageNo, int pageSize)
    {

        var result = _db.Query("Product")
            .Select(
            "ProductID",
            "ProductKey",
            "ProductName",
            "ProductImageUri",
            "ProductTypeName",
            "Product.RecordStatus")
            .Join("ProductType", "ProductType.ProductTypeID", "Product.ProductTypeID")
            .OrderByDesc("Product.UpdatedDate")
            .OrderByDesc("Product.CreatedDate")
            .ForPage(pageNo, pageSize); 

        return await result.GetAsync<ProductResponseModel>();
    }

### IProductDataService.cs in InstantPOS.Application > DatabaseServices > Interfaces
    public interface IProductDataService
    {
        Task<bool> CreateProduct(CreateProductCommand request);
        Task<bool> DeleteProduct(Guid productTypeId);
        Task<IEnumerable<ProductResponseModel>> FetchProduct(int pageNo, int pageSize);
    }
### ProductsController in  InstantPOS.WebAPI > Controllers

    // GET: api/values
    [HttpGet]
    public async Task<IEnumerable<ProductResponseModel>> Get(int pageNo, int pageSize)
    {
        var query = new FetchProductQuery() { PageNo = pageNo, PageSize = pageSize };
        return await Mediator.Send(query);
    }

# Register Swagger 
### Startup.cs in IntantPOS.WebAI 
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Instant POS API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            Description = "Enter 'Bearer' following by space and JWT.",
            Name = "Authorization",
            //Type = SecuritySchemeType.Http,
            Type = SecuritySchemeType.ApiKey,
            In = ParameterLocation.Header,
        });

        c.AddFluentValidationRules();
        c.OperationFilter<SwaggerAuthorizeCheckOperationFilter>();
    });

### SwaggerAuthorizeCheckOperationFilter.cs, project InstantPOS.WebAPI > Filters

    public class SwaggerAuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Check for authorize attribute
            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                               context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            if (!hasAuthorize) return;

            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });

            operation.Security = new List<OpenApiSecurityRequirement>
            {
               new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
            } };

        }
    }
