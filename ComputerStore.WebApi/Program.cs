using AutoMapper;
using ComputerStore.Data;
using ComputerStore.Data.Interfaces;
using ComputerStore.Data.Repositories;
using ComputerStore.Services;
using ComputerStore.Services.Interfaces;
using ComputerStore.Services.Profiles;
using ComputerStore.WebApi.ConnectionString;
using ComputerStore.WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace ComputerStore.WebApi
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();


            // Connection strings
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json")
                .Build();

            Configuration = configuration;

            builder.Services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            builder.Services.AddDbContextPool<ComputerStoreContext>((ServiceProvider, options) =>
            {
                options.UseSqlServer(Configuration.GetSection("ConnectionStrings")
                    .GetSection("DefaultConnection").Value,
                    x => x.MigrationsAssembly("ComputerStore.Data"));
            });


            // Mappers 
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CategoryProfile());
                mc.AddProfile(new ProductProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            // Services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<DiscountCalculatorService>();


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddSwaggerGen();


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
}
