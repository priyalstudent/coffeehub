using CoffeeHub.Api.Contracts.Storage;
using CoffeeHub.Api.Data;
using CoffeeHub.Api.Services;
using CoffeeHub.Api.Storage;
using CoffeeHub.Api.Storage.Azure;
using CoffeeHub.Api.Storage.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
//using Stripe;

namespace CoffeeHub.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions =>           //waits a few seconds if the DB is “waking up”
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorNumbersToAdd: null
                        );
                    }
                )
            );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy
                        .WithOrigins(
                            "https://coffeehub-frontend-web-e9b4exbufwfxh8bn.francecentral-01.azurewebsites.net"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://coffeehub-identity-erdyavdqfdcsdbac.francecentral-01.azurewebsites.net";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false // TEMPORARILY disable audience check
        };
    });

            builder.Services.AddAuthorization();

            builder.Services.Configure<ImageStorageOptions>(
                builder.Configuration.GetSection("ImageStorage"));

            builder.Services.AddScoped<IImageStorage, AzureBlobImageStorage>();
            Stripe.StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowFrontend");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
