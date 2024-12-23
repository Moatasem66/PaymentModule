
using Microsoft.EntityFrameworkCore;
using PaymentModule.Context;
using PaymentModule.Contracts;
using PaymentModule.Services;
using System;
using System.Reflection;

namespace PaymentModule
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

            builder.Services.AddDbContext<AppDbContext>(
                o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
               
                

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddScoped<IInvoiceService , InvoiceService>();
            builder.Services.AddScoped<IDiscountService, DiscountService>();
            
            
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
