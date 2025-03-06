
using SmartParkingLot.Api.AppStartup;
using Microsoft.OpenApi.Models;
using SmartParkingLot.Api.Domain.Variables;
using SmartParkingLot.Api.Repository.EF;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SmartParkingLot.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        SQLitePCL.Batteries.Init();
        IConfiguration config = builder.Configuration.AddJsonFile("appsettings.json").Build();

        // Add services to the container.
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString: config.GetConnectionString(AppSettingsKeys.DB_CONNECTION),
            sqliteOptionsAction: op =>
            {
                op.MigrationsAssembly(
                    Assembly.GetExecutingAssembly().FullName
                    );
            })
        );
        builder.Services.AddCorsDocumentation(config);
        builder.Services.AddControllers();
        builder.Services.AddDependencyInjectionConfig(config);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt => { 
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Smart Parking Lot API", Version = "v1" });
            opt.OperationFilter<DeviceHeaderFilter>();
        });

        var app = builder.Build();
        app.UseCorsDocumentation();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseExceptionMiddleware();

        app.UseAuthorization();

        app.MapControllers();

        app.MapFallbackToFile("/index.html");

        app.Run();
    }
}
