using AutoMapper;
using webapi.Dtos;
using webapi.Models;

namespace webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();

            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Record, RecordDto>();
                x.CreateMap<RecordRequest, Record>();
            });
            var mapper = mapperConfiguration.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddScoped<IRecordsService, RecordsService>();

            var app = builder.Build();

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("*"); // https://localhost:7268
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DataContext>();
                context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}