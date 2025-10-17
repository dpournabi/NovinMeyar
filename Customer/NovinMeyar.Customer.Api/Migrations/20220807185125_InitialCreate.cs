using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovinMeyar.Customer.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TablePK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditAction = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    AuditUser = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalCustomers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EconomicCode = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    RegisterNo = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    TellPhone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CEOFirstName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CEOCell = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CEOLastName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CEOBirthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealCustomers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    TellPhone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExteraInformation = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    NationalCartId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealCustomers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "LegalCustomers");

            migrationBuilder.DropTable(
                name: "RealCustomers");
        }
    }
}
