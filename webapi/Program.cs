using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Reflection;
using webapi.DatabaseContext;


namespace webapi
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddTransient<ICharacterService, CharacterService>();


            // Add controllers and database context to the container
            builder.Services.AddControllers();
            builder.Services.AddDbContext<MeFitContext>();


            // Add AutoMapper and Swagger to the container
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Set up Swagger documentation
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "MeFit API",
                    Description = "This API provides access to information about the MeFit application.",
                    Contact = new OpenApiContact
                    {
                        Name = "Emil Bo Solgaard Utsen, Farhang Younis, Mads Ohmsen, Simon L�vschal",
                        Url = new Uri("https://github.com/hostilelogout/MeFit/tree/main/webapi")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT 2022",
                        Url = new Uri("https://opensource.org/license/mit/")
                    }
                });
                //options.IncludeXmlComments(xmlPath);
            });

            // Build the application.
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Use Swagger UI in development environment
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Set up database migration
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<MeFitContext>();
            //dbContext.Database.EnsureCreated(); 
            dbContext.Database.Migrate();

            // Set up HTTPS redirection and authorization
            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Map the controllers to HTTP endpoints
            app.MapControllers();

            // Run the application.
            app.Run();


        }
    }
}