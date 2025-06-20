
using Data;
using Microsoft.EntityFrameworkCore;

namespace EjercicioChatLibros
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

            var app = builder.Build();

            builder.Services.AddDbContext<EjercicioChatLibrosContext>
                (options =>
                    {
                        options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BibliotecaEjercChat;Integrated Security=True;");
                    });
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
