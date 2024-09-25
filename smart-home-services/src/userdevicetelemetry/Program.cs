using SmartHomeSystem.Extensions;
using SmartHomeSystem.Context;
using Microsoft.EntityFrameworkCore;
using SmartHomeSystem.Kafka;
using SmartHomeSystem.Controllers;

namespace SmartHomeSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGetWithAuth(builder.Configuration);
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<UserDeviceTelemetryContext>(w => w.UseNpgsql($"Host={builder.Configuration["DB:Host"]};Port={builder.Configuration["DB:Port"]};Database={builder.Configuration["DB:Name"]};Username={builder.Configuration["DB:User"]};Password={builder.Configuration["DB:Password"]};"));
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<UserDeviceTelemetryApiController, UserDeviceTelemetryApiController>();
            builder.Services.AddHostedService<KafkaConsumerService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<UserDeviceTelemetryContext>().Database.Migrate();
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
