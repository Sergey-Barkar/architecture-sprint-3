using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SmartHomeSystem.Extensions;
using SmartHomeSystem.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using SmartHome.Devices.Kafka;

namespace SmartHomeSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGetWithAuth(builder.Configuration);
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<UserDeviceContext>(w => w.UseNpgsql($"Host={builder.Configuration["DB:Host"]};Port={builder.Configuration["DB:Port"]};Database={builder.Configuration["DB:Name"]};Username={builder.Configuration["DB:User"]};Password={builder.Configuration["DB:Password"]};"));
            builder.Services.AddControllers();
            builder.Services.AddSingleton<KafkaProducer>();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<UserDeviceContext>();
                db.Database.Migrate();
            }
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllers();

            app.Run();
        }
    }
}
