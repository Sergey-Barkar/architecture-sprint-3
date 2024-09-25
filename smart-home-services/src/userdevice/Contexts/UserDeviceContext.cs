using Microsoft.EntityFrameworkCore;
using SmartHomeSystem.Model;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SmartHomeSystem.Context;

public class UserDeviceContext : DbContext
{
    public DbSet<UserDevice> UserDevice { get; set; }

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDevice>().HasData(GetUserDevices(2));
    }

    private static IEnumerable<UserDevice> GetUserDevices(int seed)
    {
        var deviceList = new List<UserDevice>();
        for (var j = 0; j < seed; j++)
        {
            deviceList.Add(new UserDevice
            {
                UserId = Guid.NewGuid(),
                UserDeviceId = j + 1
            });
        }

        return deviceList;
    }
    */

    public UserDeviceContext(DbContextOptions<UserDeviceContext> options) : base(options)
    {
    }
}