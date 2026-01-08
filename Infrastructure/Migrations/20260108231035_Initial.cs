using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movements",
                columns: new[] { "Id", "Amount", "Category", "Description", "OperationDate", "ValueDate" },
                values: new object[,]
                {
                    { new Guid("261bf873-3891-4638-b3f4-cfc6fd7ce685"), -55.00m, "Servicios públicos", "6.Factura Gas", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c7fa20f-c048-45ee-b6b6-07a3099855c0"), -120.50m, "Servicios públicos", "3.Factura Luz", new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43fea005-ce95-4195-a5f2-dd0b5e9fe249"), -50.25m, "Alimentación", "4.Compra Mercadona", new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("50e404fa-9668-453a-ba9c-303331a5e848"), 2500.00m, "Salario", "1.Nómina Octubre", new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("731deb45-9c4f-470e-b96d-2854a3e97932"), -80.25m, "Servicios públicos", "5.Factura Agua", new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9132904b-f312-4060-8f68-0a2d58c1cf23"), -25.00m, "Alimentación", "7.Compra Carrefour", new DateTime(2025, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("960b50e2-c71b-4214-bad7-c4a06529f6cd"), 800.00m, "Salario", "8.Nomina Noviembre", new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6d91354-26e8-495f-8bf4-6899fa83acfa"), -850.00m, "Alquiler", "9.Alquiler piso Noviembre", new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca8ac275-3490-46b0-9326-7196ba1230bf"), -800.00m, "Alquiler", "2.Alquiler piso Octubre", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d203486f-ef3b-449a-8e17-e57d500e62ec"), -80.00m, "Servicios públicos", "10.Factura Agua", new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movements");
        }
    }
}
