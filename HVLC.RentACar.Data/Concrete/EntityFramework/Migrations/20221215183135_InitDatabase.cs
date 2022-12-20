using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HVLC.RentACar.Data.Concrete.EntityFramework.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifedBy = table.Column<int>(type: "int", nullable: true),
                    ModifedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KM = table.Column<double>(type: "float", maxLength: 7, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarServiceId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifedBy = table.Column<int>(type: "int", nullable: true),
                    ModifedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarServices_CarServiceId",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartingKm = table.Column<double>(type: "float", maxLength: 7, nullable: false),
                    FinishKm = table.Column<double>(type: "float", maxLength: 7, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifedBy = table.Column<int>(type: "int", nullable: true),
                    ModifedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcNo = table.Column<double>(type: "float", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifedBy = table.Column<int>(type: "int", nullable: true),
                    ModifedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Comment", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedeDate", "EntryDate", "ModifedBy", "ModifedDate", "ReleaseDate" },
                values: new object[] { 1, "Genel bakım yapıldı", 1, new DateTime(2022, 12, 28, 21, 31, 34, 910, DateTimeKind.Local).AddTicks(1048), null, null, new DateTime(2022, 12, 22, 21, 31, 34, 909, DateTimeKind.Local).AddTicks(9379), null, null, new DateTime(2022, 12, 27, 21, 31, 34, 910, DateTimeKind.Local).AddTicks(39) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CarServiceId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedeDate", "FuelType", "KM", "Model", "ModifedBy", "ModifedDate" },
                values: new object[] { 1, "Opel", 1, 1, new DateTime(2022, 12, 10, 21, 31, 34, 905, DateTimeKind.Local).AddTicks(439), null, null, "Benzin", 12.0, "Mokka", null, null });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CarId", "Comment", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedeDate", "DeliveryDate", "FinishKm", "ModifedBy", "ModifedDate", "RentalDate", "StartingKm" },
                values: new object[] { 1, 1, "Rahat ve komforlu bir araçtı", 1, new DateTime(2022, 12, 21, 21, 31, 34, 914, DateTimeKind.Local).AddTicks(7961), null, null, new DateTime(2022, 12, 20, 21, 31, 34, 914, DateTimeKind.Local).AddTicks(6024), 1265.0, null, null, new DateTime(2022, 12, 15, 21, 31, 34, 914, DateTimeKind.Local).AddTicks(5473), 1235.0 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedeDate", "EMail", "ModifedBy", "ModifedDate", "Name", "Password", "PhoneNumber", "ReservationId", "Surname", "TcNo" },
                values: new object[] { 1, "Bağlarbaşı mah", 1, new DateTime(2022, 12, 15, 21, 31, 34, 912, DateTimeKind.Local).AddTicks(7861), null, null, "nedimhavlaci@gmail.com", null, null, "Nedim", "1234", "05076089730", 1, "HAVLACI", 12345678910.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarServiceId",
                table: "Cars",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ReservationId",
                table: "Customers",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarServices");
        }
    }
}
