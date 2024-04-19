
using Microsoft.EntityFrameworkCore;
using OpenQuantTest.Data;
using OpenQuantTest.Repositories;
using OpenQuantTest.Repositories.Interfaces;
using OpenQuantTest.Services;

namespace OpenQuantTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

            builder.Services.AddScoped<IAccountRepository, AccountRepository>();



            builder.Services.AddScoped<TransactionService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("*")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);


            app.MapControllers();

            app.Run();
        }
    }
}
