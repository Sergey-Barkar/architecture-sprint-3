using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace userdevice.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDevice",
                columns: table => new
                {
                    UserDeviceId = table.Column<int>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<int>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserDevicePrimary_Idx", x => x.UserDeviceId);
                });

            migrationBuilder.CreateIndex(
                name: "UserDevice_Idx",
                table: "UserDevice",
                columns: new[] { "UserId", "UserDeviceId" });
            /*
            migrationBuilder.InsertData(
                table: "UserDevice",
                columns: new[] { "UserDeviceId", "UserId" },
                values: new object[,]
                {
                    { 2, Guid.NewGuid() },
                    { 3, Guid.NewGuid() }
                });
            */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDevice");
        }
    }
}
