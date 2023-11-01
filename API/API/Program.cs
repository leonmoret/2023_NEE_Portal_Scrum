using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
                options.EnableSensitiveDataLogging();
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                seed(services);
            }

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

        private static void seed(IServiceProvider serviceProvider)
        {
            using var ctx = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>());

            var deleted = ctx.Database.EnsureDeleted();
            var created = ctx.Database.EnsureCreated();

            if (created)
            {
                var plant1 = new Plant() { X = 2611936, Y = 1257011 };
                var plant2 = new Plant() { X = 2645758, Y = 1265094 };
                var plant3 = new Plant() { X = 2610547, Y = 1188979 };
                var plant4 = new Plant() { X = 2610529, Y = 1167346 };
                var plant5 = new Plant() { X = 2705863, Y = 1240553 };

                ctx.Plants.AddRange(plant1, plant2, plant3, plant4, plant5);

                ctx.SaveChanges();
            }
        }
    }
}