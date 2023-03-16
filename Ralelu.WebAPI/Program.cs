using Ralelu.Infrastructure.Repository.Interface;
using Ralelu.Infrastructure.Repository;
using Ralelu.Infrastructure;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors();

        // Context for entity framework
        var connectionString = ConfigurationExtensions.GetConnectionString(builder.Configuration, "mysql");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion));

        // Dependency Injection - Repositories
        builder.Services.AddTransient<IUserRepository, UserRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}