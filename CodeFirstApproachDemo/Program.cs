
using CodeFirstApproachDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproachDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AppCors", policy =>
                {
                    policy.WithOrigins("http://localhost:5199",
                        "http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

            });


            //If using appsettings.josn to configure cors
            //var corsSettings=builder.Configuration.GetSection("Cors");
            //var allowedOrgins = corsSettings.GetSection("AllowedOrigins").Get<string[]>();
            //var allowedCredentials = corsSettings.GetValue<bool>("AlowCredentials");




            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AppCors", policy =>
            //    {
            //        policy.WithOrigins(allowedOrgins)
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });

            //});

            // Add services to the container.
            builder.Services.AddDbContext<SchoolContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
              app.UseCors();
            //app.UseAuthentication()
            app.UseAuthorization();
            

            app.MapControllers();

            app.Run();
        }
    }
}
