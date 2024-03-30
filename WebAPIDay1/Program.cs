
using Microsoft.EntityFrameworkCore;
using WebAPIDay1.Models;

namespace WebAPIDay1
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
            builder.Services.AddDbContext<ITIContext>(option => {
                option
                .UseSqlServer("Data Source=.;Initial Catalog=ITIWebApi44;Integrated Security=True;Encrypt=False");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseAuthorization();


            app.MapControllers();//not include default route each controller determine his route

            app.Run();
        }
    }
}
