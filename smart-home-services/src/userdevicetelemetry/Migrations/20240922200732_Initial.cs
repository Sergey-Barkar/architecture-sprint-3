using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace userdevicetelemetry.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDeviceTelemetry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserDeviceId = table.Column<long>(type: "bigint", nullable: true),
                    ValueType = table.Column<int>(type: "integer", nullable: true),
                    Value = table.Column<decimal>(type: "numeric", nullable: true),
                    CreatedDateTime = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeviceTelemetry", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UserDeviceTelemetry_Idx",
                table: "UserDeviceTelemetry",
                columns: new[] { "UserDeviceId", "CreatedDateTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDeviceTelemetry");
        }
    }
}
