using Ralelu.Infrastructure.Repository.Interface;
using Ralelu.Infrastructure.Repository;
using Ralelu.Infrastructure;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Ralelu.Domain.Entity;
using Ralelu.WebAPI.Arguments.Out.User;
using Ralelu.WebAPI.Services.Interfaces;
using Ralelu.WebAPI.Services;

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

        // AutoMapper
        var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserOut>();
            });

        IMapper mapper = autoMapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        // Context for entity framework
        var connectionString = ConfigurationExtensions.GetConnectionString(builder.Configuration, "mysql");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion));

        // Dependency Injection - Repositories
        builder.Services.AddTransient<IUserRepository, UserRepository>();

        // Dependency Injection - Services
        builder.Services.AddTransient<IUserService, UserService>();

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