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
            builder.Services.AddSingleton<ContactMessageCosmosService>();
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy
                        .WithOrigins(
                            "https://thankful-bush-00bbe7e03.7.azurestaticapps.net"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://coffeehub-identity-fea4crgrhna8f8eq.francecentral-01.azurewebsites.net";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false 
        };
    });

            builder.Services.AddAuthorization();

            builder.Services.Configure<ImageStorageOptions>(
                builder.Configuration.GetSection("ImageStorage"));

            builder.Services.AddScoped<IImageStorage, AzureBlobImageStorage>();
            Stripe.StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

            builder.Services.AddHttpClient();

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
