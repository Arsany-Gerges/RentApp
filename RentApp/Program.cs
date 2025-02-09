using Microsoft.EntityFrameworkCore;
using RentApp.Infrastructure;
using RentApp.Domain.Abstraction;
using RentApp.Infrastructure.Repositories;

namespace RentProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddDbContext<RentAppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           
            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            var app = builder.Build();

           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
