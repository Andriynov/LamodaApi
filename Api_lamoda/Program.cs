using Api_lamoda.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Api_lamoda
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);





            builder.Services.AddDbContext<AndriynovContext>(
                optionsAction: option => option.UseSqlServer(
                    connectionString:"Server=DESKTOP-U3OPFQS;Database=Andriynov;Integrated Security=True; TrustServerCertificate=True"));
      







        // Add services to the container.

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
