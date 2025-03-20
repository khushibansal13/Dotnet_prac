using System.Text;
using System.Threading.RateLimiting;
using Dapper;
using EncomApi.Handlers;
using EncomApi.Interfaces;
using EncomApi.Models;
using EncomApi.Repositories;
using EncomApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Encom API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid JWT token in the format 'Bearer {token}'",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddScoped<DatabaseConfig>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.Configure<MyRateLimitOptions>(
    builder.Configuration.GetSection("MyRateLimit"));

var myOptions = new MyRateLimitOptions();
builder.Configuration.GetSection("MyRateLimit").Bind(myOptions);

builder.Services.AddRateLimiter(options =>
{
    // Global rate limiter by IP address
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = myOptions.PermitLimit,
                Window = TimeSpan.FromSeconds(myOptions.Window),
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                QueueLimit = myOptions.QueueLimit
            }));

    // (POST /api/products/add)
    options.AddFixedWindowLimiter(policyName: "productAdd", productAddOptions =>
    {
        productAddOptions.PermitLimit = myOptions.ProductAddPermitLimit;
        productAddOptions.Window = TimeSpan.FromSeconds(myOptions.ProductAddWindow);
        productAddOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        productAddOptions.QueueLimit = myOptions.ProductAddQueueLimit;
    });

    // (PUT /api/products/{id})
    options.AddFixedWindowLimiter(policyName: "productUpdate", productUpdateOptions =>
    {
        productUpdateOptions.PermitLimit = myOptions.ProductUpdatePermitLimit;
        productUpdateOptions.Window = TimeSpan.FromSeconds(myOptions.ProductUpdateWindow);
        productUpdateOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        productUpdateOptions.QueueLimit = myOptions.ProductUpdateQueueLimit;
    });

    //  (DELETE /api/products/{id})
    options.AddFixedWindowLimiter(policyName: "productDelete", productDeleteOptions =>
    {
        productDeleteOptions.PermitLimit = myOptions.ProductDeletePermitLimit;
        productDeleteOptions.Window = TimeSpan.FromSeconds(myOptions.ProductDeleteWindow);
        productDeleteOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        productDeleteOptions.QueueLimit = myOptions.ProductDeleteQueueLimit;
    });

    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        await context.HttpContext.Response.WriteAsync(
            "Too many requests. Please try again later.", cancellationToken: token);
    };
});

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!);

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://encomify.netlify.app") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

SqlMapper.AddTypeHandler(new JsonTypeHandler<Dimensions>());
SqlMapper.AddTypeHandler(new JsonTypeHandler<List<string>>());
SqlMapper.AddTypeHandler(new JsonTypeHandler<List<Review>>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();
app.UseRateLimiter();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();


