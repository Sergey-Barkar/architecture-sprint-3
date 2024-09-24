using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartHomeSystem.Model;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SmartHomeSystem.Context;

public class UserDeviceTelemetryContext(DbContextOptions<UserDeviceTelemetryContext> options) : DbContext(options)
{
    public DbSet<UserDeviceTelemetry> UserDeviceTelemetry { get; set; }

}