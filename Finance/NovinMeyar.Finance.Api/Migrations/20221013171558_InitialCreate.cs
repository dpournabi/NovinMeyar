using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovinMeyar.Finance.Api.Migrations
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
                name: "PaymentHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tag = table.Column<string>(type: "varchar(20)", nullable: true),
                    SourceTable = table.Column<string>(type: "varchar(20)", nullable: true),
                    SourceKey = table.Column<string>(type: "varchar(50)", nullable: true),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ReferenceNumber = table.Column<long>(type: "bigint", nullable: false),
                    TraceNumber = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Action = table.Column<string>(type: "varchar(5)", nullable: true),
                    TransactionReferenceID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    InvoiceNumber = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceDate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    MerchantCode = table.Column<int>(type: "int", nullable: false),
                    TerminalCode = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaskedCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HashedCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShaparakRefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorUserName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExteraInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "PaymentHistories");
        }
    }
}
