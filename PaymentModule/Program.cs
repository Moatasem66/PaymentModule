using Microsoft.EntityFrameworkCore;
using PaymentModule.Context;
using PaymentModule.Contracts;
using PaymentModule.Services;
using Swashbuckle.AspNetCore.SwaggerUI;
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
          

            builder.Services.AddScoped<IDiscountService , DiscountService>();
            builder.Services.AddScoped<IInvoiceService , InvoiceService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IPaymentHistoryService, PaymentHistoryService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Module");
                    options.DocExpansion(DocExpansion.None);
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
