using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovinMeyar.Technical.Api.Migrations
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
                name: "BedMaterialTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedMaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrakeTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrakeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CabinAntiShockTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinAntiShockTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CounterWeightAntiShockTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterWeightAntiShockTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CounterWeightTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterWeightTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoorTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IsCabin = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElevatorInspections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InspectionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    InspectionTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevatorInspections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElevatorTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevatorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstallatinCompanies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EconomicCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NationalNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DesigningCertificateId = table.Column<long>(type: "bigint", nullable: false),
                    RegistrationOfficeCertificate = table.Column<long>(type: "bigint", nullable: false),
                    TellPhone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CTOFirstName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CTOLastName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CTOCell = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CTOBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallatinCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstallationTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LatestCertificateTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatestCertificateTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LocationEnum = table.Column<int>(type: "int", nullable: false),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PulleyMaterialTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PulleyMaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TractionPulleyTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TractionPulleyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UseTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WallMaterialTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallMaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightShoesTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightShoesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SerialResources",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateSerial = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HologramNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerialResources_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObjectDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    ElevatorTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ObjectDetailId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectDetails_ElevatorTypes_ElevatorTypeId",
                        column: x => x.ElevatorTypeId,
                        principalTable: "ElevatorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ObjectDetails_ObjectDetails_ObjectDetailId",
                        column: x => x.ObjectDetailId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionTariffs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Step = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdditionalPayPerStopCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionTariffs_InspectionTypes_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalTable: "InspectionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElevatorInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    ElevatorNationalNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ISIRINo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ResponsibleFullName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ResponsibleCell = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ElevatorTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SerialResourceId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentNumber = table.Column<string>(type: "varchar(200)", nullable: true),
                    BuildingCertificateNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BuildingPleque = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BuildingAreaNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BuildingIssueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    InsuranceNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    InsuranceIssueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ContractServiceStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    InspectionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    LatestCertificateTypeId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerType = table.Column<bool>(type: "bit", nullable: false),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallatinCompanyId = table.Column<long>(type: "bigint", nullable: false),
                    LuxMeterSerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PowerMeterSerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TypeMeterSerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MultiMeterSerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LaserMeterSerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CollisSerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ThicknessGaugeSerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ScanDocumentId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectDocumentId = table.Column<long>(type: "bigint", nullable: true),
                    CertificateId = table.Column<long>(type: "bigint", nullable: true),
                    BuildingCertificateImageId = table.Column<long>(type: "bigint", nullable: true),
                    IsiriRequestImageId = table.Column<long>(type: "bigint", nullable: true),
                    StopCount = table.Column<int>(type: "int", nullable: true),
                    IsLock = table.Column<bool>(type: "bit", nullable: true),
                    CreatorRoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevatorInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElevatorInformations_ElevatorTypes_ElevatorTypeId",
                        column: x => x.ElevatorTypeId,
                        principalTable: "ElevatorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElevatorInformations_InspectionTypes_InspectionTypeId",
                        column: x => x.InspectionTypeId,
                        principalTable: "InspectionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElevatorInformations_InstallatinCompanies_InstallatinCompanyId",
                        column: x => x.InstallatinCompanyId,
                        principalTable: "InstallatinCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElevatorInformations_LatestCertificateTypes_LatestCertificateTypeId",
                        column: x => x.LatestCertificateTypeId,
                        principalTable: "LatestCertificateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElevatorInformations_SerialResources_SerialResourceId",
                        column: x => x.SerialResourceId,
                        principalTable: "SerialResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObjectDetailProperties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ObjectDetailId = table.Column<long>(type: "bigint", nullable: false),
                    PropertyId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectDetailProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectDetailProperties_ObjectDetails_ObjectDetailId",
                        column: x => x.ObjectDetailId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectDetailProperties_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinAntiShocksInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CabinAntiShockInstallationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CabinAntiShockTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CabinAntiShockTypeBrandId = table.Column<long>(type: "bigint", nullable: true),
                    CabinAntiShockTypeCount = table.Column<int>(type: "int", nullable: false),
                    CabinAntiShockTypeSerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CabinCapacityWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinAntiShocksInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabinAntiShocksInformations_CabinAntiShockTypes_CabinAntiShockTypeId",
                        column: x => x.CabinAntiShockTypeId,
                        principalTable: "CabinAntiShockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinAntiShocksInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinAntiShocksInformations_InstallationTypes_CabinAntiShockInstallationTypeId",
                        column: x => x.CabinAntiShockInstallationTypeId,
                        principalTable: "InstallationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinAntiShocksInformations_ObjectDetails_CabinAntiShockTypeBrandId",
                        column: x => x.CabinAntiShockTypeBrandId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CabinInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: false),
                    CarCapacityCount = table.Column<int>(type: "int", nullable: false),
                    CarCapacityWeight = table.Column<float>(type: "real", nullable: false),
                    CarWeight = table.Column<float>(type: "real", nullable: false),
                    MaximumAcceleration = table.Column<float>(type: "real", nullable: false),
                    CabinDepth = table.Column<float>(type: "real", nullable: false),
                    CabinHeight = table.Column<float>(type: "real", nullable: false),
                    CabinWidth = table.Column<float>(type: "real", nullable: false),
                    CabinTrayHeight = table.Column<float>(type: "real", nullable: false),
                    ApproximateCabinWeight = table.Column<float>(type: "real", nullable: false),
                    HasLightSensor = table.Column<bool>(type: "bit", nullable: false),
                    HasCarLockDoor = table.Column<bool>(type: "bit", nullable: false),
                    CalculatedCapacity = table.Column<float>(type: "real", nullable: false),
                    ShoesTypeId = table.Column<long>(type: "bigint", nullable: false),
                    VerticalShoesDistance = table.Column<float>(type: "real", nullable: false),
                    InstallRailEquipment = table.Column<int>(type: "int", nullable: false),
                    Maux = table.Column<float>(type: "real", nullable: false),
                    WallMaterialTypeId = table.Column<long>(type: "bigint", nullable: false),
                    BedMaterialTypeId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabinInformations_BedMaterialTypes_BedMaterialTypeId",
                        column: x => x.BedMaterialTypeId,
                        principalTable: "BedMaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinInformations_WallMaterialTypes_WallMaterialTypeId",
                        column: x => x.WallMaterialTypeId,
                        principalTable: "WallMaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinInformations_WeightShoesTypes_ShoesTypeId",
                        column: x => x.ShoesTypeId,
                        principalTable: "WeightShoesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChainsCableInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    WeightOfAuxChans = table.Column<float>(type: "real", nullable: false),
                    WeightOfOneMeterChans = table.Column<float>(type: "real", nullable: false),
                    AuxChainsCount = table.Column<int>(type: "int", nullable: false),
                    TravelingCableCount = table.Column<int>(type: "int", nullable: false),
                    MassOfTravelingCable = table.Column<float>(type: "real", nullable: false),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChainsCableInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChainsCableInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CounterWeightInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LocationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    BalanceWeightTypeId = table.Column<long>(type: "bigint", nullable: false),
                    BalanceWeightCount = table.Column<int>(type: "int", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceRatio = table.Column<int>(type: "int", nullable: false),
                    WeightShoesTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterWeightInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounterWeightInformations_CounterWeightTypes_BalanceWeightTypeId",
                        column: x => x.BalanceWeightTypeId,
                        principalTable: "CounterWeightTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounterWeightInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounterWeightInformations_LocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounterWeightInformations_WeightShoesTypes_WeightShoesTypeId",
                        column: x => x.WeightShoesTypeId,
                        principalTable: "WeightShoesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CounterWightAntiShocksInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CounterWeightInstallationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CounterWeightAntiShockTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CounterWeightAntiShockTypeBrandId = table.Column<long>(type: "bigint", nullable: true),
                    CounterWeightAntiShockTypeCount = table.Column<int>(type: "int", nullable: true),
                    CounterWeightAntiShockTypeSerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CounterCapacityWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterWightAntiShocksInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounterWightAntiShocksInformations_CounterWeightAntiShockTypes_CounterWeightAntiShockTypeId",
                        column: x => x.CounterWeightAntiShockTypeId,
                        principalTable: "CounterWeightAntiShockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounterWightAntiShocksInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounterWightAntiShocksInformations_InstallationTypes_CounterWeightInstallationTypeId",
                        column: x => x.CounterWeightInstallationTypeId,
                        principalTable: "InstallationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounterWightAntiShocksInformations_ObjectDetails_CounterWeightAntiShockTypeBrandId",
                        column: x => x.CounterWeightAntiShockTypeBrandId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EngineInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EngineTypeId = table.Column<long>(type: "bigint", nullable: false),
                    GeerTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NuminalStream = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartStream = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutputPower = table.Column<float>(type: "real", nullable: false),
                    HighSpeed = table.Column<int>(type: "int", nullable: false),
                    LowSpeed = table.Column<int>(type: "int", nullable: false),
                    GeerRatio = table.Column<float>(type: "real", nullable: false),
                    HasGeer = table.Column<bool>(type: "bit", nullable: false),
                    EngineWeight = table.Column<float>(type: "real", nullable: false),
                    EngineSpeed = table.Column<float>(type: "real", nullable: false),
                    ManualEngineSpeed = table.Column<bool>(type: "bit", nullable: false),
                    MaxPressureOnTractionPullyEfficiency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RopeCountOnTractionPullyEfficiency = table.Column<int>(type: "int", nullable: false),
                    BetaAngle = table.Column<float>(type: "real", nullable: false),
                    UnderCut = table.Column<bool>(type: "bit", nullable: false),
                    GrooveType = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    GammaAngle = table.Column<float>(type: "real", nullable: false),
                    GearboxEfficiency = table.Column<int>(type: "int", nullable: false),
                    GrooveMeachanics = table.Column<bool>(type: "bit", nullable: false),
                    GripesCount = table.Column<int>(type: "int", nullable: false),
                    GrooveCount = table.Column<int>(type: "int", nullable: false),
                    ManualCalculation = table.Column<bool>(type: "bit", nullable: false),
                    TractionPullyDiameter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManualAlphaLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlphaAngle = table.Column<float>(type: "real", nullable: false),
                    VerticalDistanceWires = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorizontalDistanceWires = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConversionRatio = table.Column<float>(type: "real", nullable: false),
                    AlphaResult = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CounterWeightDistanceToWall = table.Column<float>(type: "real", nullable: false),
                    CounterWeightDistanceToNextWall = table.Column<float>(type: "real", nullable: false),
                    GavernerDistanceToWall = table.Column<float>(type: "real", nullable: false),
                    GavernerDistanceToNextWall = table.Column<float>(type: "real", nullable: false),
                    GovernerLocationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngineInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineInformations_LocationTypes_GovernerLocationTypeId",
                        column: x => x.GovernerLocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineInformations_ObjectDetails_EngineTypeId",
                        column: x => x.EngineTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineInformations_ObjectDetails_GeerTypeId",
                        column: x => x.GeerTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GeneralTechnicalformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeOfStandard = table.Column<int>(type: "int", nullable: false),
                    ElevatorPhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    FloorCount = table.Column<int>(type: "int", nullable: false),
                    FloorLength = table.Column<float>(type: "real", nullable: false),
                    ManualTravelCalculation = table.Column<bool>(type: "bit", nullable: false),
                    Travel = table.Column<float>(type: "real", nullable: false),
                    ElevatorCount = table.Column<int>(type: "int", nullable: false),
                    FrictionCoefficient = table.Column<float>(type: "real", nullable: false),
                    LowSpeed = table.Column<float>(type: "real", nullable: false),
                    CabinSpeed = table.Column<float>(type: "real", nullable: false),
                    PathHeight = table.Column<float>(type: "real", nullable: false),
                    RailsCount = table.Column<int>(type: "int", nullable: false),
                    FrictionForceInsideCabin = table.Column<float>(type: "real", nullable: false),
                    FrictionForceInsideWeightBalance = table.Column<float>(type: "real", nullable: false),
                    AccelerationEmergencyStop = table.Column<float>(type: "real", nullable: false),
                    OverHead = table.Column<float>(type: "real", nullable: false),
                    DepthOfPit = table.Column<float>(type: "real", nullable: false),
                    ShaftHeight = table.Column<float>(type: "real", nullable: false),
                    ShaftDepth = table.Column<float>(type: "real", nullable: false),
                    ShaftWidth = table.Column<float>(type: "real", nullable: false),
                    CabinStandHeight = table.Column<float>(type: "real", nullable: false),
                    CounterWeightStandHeight = table.Column<float>(type: "real", nullable: false),
                    StandsDistance = table.Column<float>(type: "real", nullable: false),
                    CounterWeightToStandDistance = table.Column<float>(type: "real", nullable: false),
                    CabinToCounterWeightDistance = table.Column<int>(type: "int", nullable: false),
                    UseTypeId = table.Column<long>(type: "bigint", nullable: true),
                    PullyDiameter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TractionPullyEfficiency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MassDecreasedOfCable = table.Column<float>(type: "real", nullable: false),
                    MassOfTractionPulley = table.Column<float>(type: "real", nullable: false),
                    ThreePahseSerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpSpeedControlDescription = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HasIncpectorDoorInPit = table.Column<bool>(type: "bit", nullable: false),
                    IsHalfCloseShaft = table.Column<bool>(type: "bit", nullable: false),
                    HasShareShaft = table.Column<bool>(type: "bit", nullable: false),
                    HasEmergencyDoor = table.Column<bool>(type: "bit", nullable: false),
                    HasVisitFromShaft = table.Column<bool>(type: "bit", nullable: false),
                    MachineRoomHieght = table.Column<float>(type: "real", nullable: false),
                    TechnicalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PitSituation = table.Column<bool>(type: "bit", nullable: false),
                    HasMachineRoom = table.Column<bool>(type: "bit", nullable: false),
                    MachineLocationId = table.Column<long>(type: "bigint", nullable: false),
                    EngineAccessType = table.Column<int>(type: "int", nullable: false),
                    HasOutsideBoard = table.Column<bool>(type: "bit", nullable: false),
                    HasPullyRoom = table.Column<bool>(type: "bit", nullable: false),
                    EmergencyExitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernerLocationId = table.Column<long>(type: "bigint", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralTechnicalformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralTechnicalformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralTechnicalformations_LocationTypes_GovernerLocationId",
                        column: x => x.GovernerLocationId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeneralTechnicalformations_LocationTypes_MachineLocationId",
                        column: x => x.MachineLocationId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeneralTechnicalformations_UseTypes_UseTypeId",
                        column: x => x.UseTypeId,
                        principalTable: "UseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GovernerInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    GovernerTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MaximumValidSpeed = table.Column<float>(type: "real", nullable: false),
                    HasTwoWays = table.Column<bool>(type: "bit", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernerInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernerInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GovernerInformations_ObjectDetails_GovernerTypeId",
                        column: x => x.GovernerTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MechanicalDoorLockInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LockTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicalDoorLockInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MechanicalDoorLockInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicalDoorLockInformations_ObjectDetails_LockTypeId",
                        column: x => x.LockTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RailsInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinRailTypeId = table.Column<long>(type: "bigint", nullable: true),
                    CabinRailDistance = table.Column<float>(type: "real", nullable: false),
                    CabinRailCount = table.Column<int>(type: "int", nullable: false),
                    ManualRailDetail = table.Column<bool>(type: "bit", nullable: false),
                    K = table.Column<int>(type: "int", nullable: false),
                    h1 = table.Column<int>(type: "int", nullable: false),
                    b1 = table.Column<int>(type: "int", nullable: false),
                    RailInstallationType = table.Column<int>(type: "int", nullable: false),
                    CounterWeightRailTypeId = table.Column<long>(type: "bigint", nullable: true),
                    CounterWeightRailDistance = table.Column<float>(type: "real", nullable: false),
                    CounterWeightRailCount = table.Column<int>(type: "int", nullable: false),
                    RailLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PressureOnRail = table.Column<float>(type: "real", nullable: false),
                    CabinCenterDistanceFromRailX = table.Column<float>(type: "real", nullable: false),
                    CabinCenterDistanceFromRailY = table.Column<float>(type: "real", nullable: false),
                    CabinCenterDistanceMassFromRailX = table.Column<float>(type: "real", nullable: false),
                    CabinCenterDistanceMassFromRailY = table.Column<float>(type: "real", nullable: false),
                    AnchorCenterDistanceFromRailX = table.Column<float>(type: "real", nullable: false),
                    AnchorCenterDistanceFromRailY = table.Column<float>(type: "real", nullable: false),
                    CabinDoorDistanceFromRailX = table.Column<float>(type: "real", nullable: false),
                    CabinDoorDistanceFromRailY = table.Column<float>(type: "real", nullable: false),
                    BracketDistance = table.Column<float>(type: "real", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailsInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RailsInformations_ElevatorInformations_ElevatorInformationId",
                        column: x => x.ElevatorInformationId,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RailsInformations_ObjectDetails_CabinRailTypeId",
                        column: x => x.CabinRailTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RailsInformations_ObjectDetails_CounterWeightRailTypeId",
                        column: x => x.CounterWeightRailTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SafetyBrakesInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    SafetyBrakesTypeId = table.Column<long>(type: "bigint", nullable: false),
                    BrakeTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LocationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CapacityWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TangleSide = table.Column<bool>(type: "bit", nullable: false),
                    MaximumSpeed = table.Column<float>(type: "real", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyBrakesInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyBrakesInformations_BrakeTypes_BrakeTypeId",
                        column: x => x.BrakeTypeId,
                        principalTable: "BrakeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SafetyBrakesInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SafetyBrakesInformations_LocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SafetyBrakesInformations_ObjectDetails_SafetyBrakesTypeId",
                        column: x => x.SafetyBrakesTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SteelRopeInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RopeTypeId = table.Column<long>(type: "bigint", nullable: false),
                    RopeCount = table.Column<int>(type: "int", nullable: false),
                    CableDiameter = table.Column<float>(type: "real", nullable: false),
                    SuspendedLength = table.Column<float>(type: "real", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteelRopeInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteelRopeInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SteelRopeInformations_ObjectDetails_RopeTypeId",
                        column: x => x.RopeTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SteeringControlInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BoardTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TravelingCableTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CableCount = table.Column<int>(type: "int", nullable: false),
                    LineCount = table.Column<int>(type: "int", nullable: false),
                    CableTickness = table.Column<float>(type: "real", nullable: false),
                    Drive = table.Column<bool>(type: "bit", nullable: false),
                    Deliverance = table.Column<bool>(type: "bit", nullable: false),
                    HasEmergencyKey = table.Column<bool>(type: "bit", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteeringControlInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteeringControlInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SteeringControlInformations_ObjectDetails_BoardTypeId",
                        column: x => x.BoardTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SteeringControlInformations_ObjectDetails_TravelingCableTypeId",
                        column: x => x.TravelingCableTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TractionPulleiesInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    HasWanderingSquare = table.Column<bool>(type: "bit", nullable: false),
                    IsSquareReverse = table.Column<bool>(type: "bit", nullable: false),
                    LocationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineTypeId = table.Column<long>(type: "bigint", nullable: false),
                    PulleyMaterialTypeId = table.Column<long>(type: "bigint", nullable: false),
                    TractionPulleyTypeId = table.Column<long>(type: "bigint", nullable: false),
                    SquareReverseCount = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PulleyDiameter = table.Column<int>(type: "int", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TractionPulleiesInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TractionPulleiesInformations_ElevatorInformations_Id",
                        column: x => x.Id,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TractionPulleiesInformations_LocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TractionPulleiesInformations_ObjectDetails_EngineTypeId",
                        column: x => x.EngineTypeId,
                        principalTable: "ObjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TractionPulleiesInformations_PulleyMaterialTypes_PulleyMaterialTypeId",
                        column: x => x.PulleyMaterialTypeId,
                        principalTable: "PulleyMaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TractionPulleiesInformations_TractionPulleyTypes_TractionPulleyTypeId",
                        column: x => x.TractionPulleyTypeId,
                        principalTable: "TractionPulleyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinDoors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DoorWidth = table.Column<int>(type: "int", nullable: false),
                    DoorTypeId = table.Column<long>(type: "bigint", nullable: false),
                    EnteringDepth = table.Column<int>(type: "int", nullable: false),
                    CabinDoorDepth = table.Column<int>(type: "int", nullable: false),
                    DoorHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpeningSide = table.Column<int>(type: "int", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    GeneralTechnicalformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinDoors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabinDoors_DoorTypes_DoorTypeId",
                        column: x => x.DoorTypeId,
                        principalTable: "DoorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinDoors_ElevatorInformations_ElevatorInformationId",
                        column: x => x.ElevatorInformationId,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CabinDoors_GeneralTechnicalformations_GeneralTechnicalformationId",
                        column: x => x.GeneralTechnicalformationId,
                        principalTable: "GeneralTechnicalformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CabinDoors_LocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FloorDoorsInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DoorTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DoorWidth = table.Column<int>(type: "int", nullable: false),
                    ThresholdDepth = table.Column<int>(type: "int", nullable: false),
                    DoorTickness = table.Column<int>(type: "int", nullable: false),
                    OpeningSide = table.Column<int>(type: "int", nullable: false),
                    ElevatorInformationId = table.Column<long>(type: "bigint", nullable: true),
                    GeneralTechnicalformationId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModifiedName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorDoorsInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloorDoorsInformations_DoorTypes_DoorTypeId",
                        column: x => x.DoorTypeId,
                        principalTable: "DoorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FloorDoorsInformations_ElevatorInformations_ElevatorInformationId",
                        column: x => x.ElevatorInformationId,
                        principalTable: "ElevatorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorDoorsInformations_GeneralTechnicalformations_GeneralTechnicalformationId",
                        column: x => x.GeneralTechnicalformationId,
                        principalTable: "GeneralTechnicalformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorDoorsInformations_LocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabinAntiShocksInformations_CabinAntiShockInstallationTypeId",
                table: "CabinAntiShocksInformations",
                column: "CabinAntiShockInstallationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinAntiShocksInformations_CabinAntiShockTypeBrandId",
                table: "CabinAntiShocksInformations",
                column: "CabinAntiShockTypeBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinAntiShocksInformations_CabinAntiShockTypeId",
                table: "CabinAntiShocksInformations",
                column: "CabinAntiShockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinDoors_DoorTypeId",
                table: "CabinDoors",
                column: "DoorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinDoors_ElevatorInformationId",
                table: "CabinDoors",
                column: "ElevatorInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinDoors_GeneralTechnicalformationId",
                table: "CabinDoors",
                column: "GeneralTechnicalformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinDoors_LocationTypeId",
                table: "CabinDoors",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinInformations_BedMaterialTypeId",
                table: "CabinInformations",
                column: "BedMaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinInformations_ShoesTypeId",
                table: "CabinInformations",
                column: "ShoesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinInformations_WallMaterialTypeId",
                table: "CabinInformations",
                column: "WallMaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterWeightInformations_BalanceWeightTypeId",
                table: "CounterWeightInformations",
                column: "BalanceWeightTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterWeightInformations_LocationTypeId",
                table: "CounterWeightInformations",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterWeightInformations_WeightShoesTypeId",
                table: "CounterWeightInformations",
                column: "WeightShoesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterWightAntiShocksInformations_CounterWeightAntiShockTypeBrandId",
                table: "CounterWightAntiShocksInformations",
                column: "CounterWeightAntiShockTypeBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterWightAntiShocksInformations_CounterWeightAntiShockTypeId",
                table: "CounterWightAntiShocksInformations",
                column: "CounterWeightAntiShockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CounterWightAntiShocksInformations_CounterWeightInstallationTypeId",
                table: "CounterWightAntiShocksInformations",
                column: "CounterWeightInstallationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ElevatorInformations_ElevatorTypeId",
                table: "ElevatorInformations",
                column: "ElevatorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ElevatorInformations_InspectionTypeId",
                table: "ElevatorInformations",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ElevatorInformations_InstallatinCompanyId",
                table: "ElevatorInformations",
                column: "InstallatinCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ElevatorInformations_LatestCertificateTypeId",
                table: "ElevatorInformations",
                column: "LatestCertificateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ElevatorInformations_SerialResourceId",
                table: "ElevatorInformations",
                column: "SerialResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ElevatorInspections_ElevatorInformationId_Row",
                table: "ElevatorInspections",
                columns: new[] { "ElevatorInformationId", "Row" });

            migrationBuilder.CreateIndex(
                name: "IX_EngineInformations_EngineTypeId",
                table: "EngineInformations",
                column: "EngineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineInformations_GeerTypeId",
                table: "EngineInformations",
                column: "GeerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineInformations_GovernerLocationTypeId",
                table: "EngineInformations",
                column: "GovernerLocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorDoorsInformations_DoorTypeId",
                table: "FloorDoorsInformations",
                column: "DoorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorDoorsInformations_ElevatorInformationId",
                table: "FloorDoorsInformations",
                column: "ElevatorInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorDoorsInformations_GeneralTechnicalformationId",
                table: "FloorDoorsInformations",
                column: "GeneralTechnicalformationId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorDoorsInformations_LocationTypeId",
                table: "FloorDoorsInformations",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralTechnicalformations_GovernerLocationId",
                table: "GeneralTechnicalformations",
                column: "GovernerLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralTechnicalformations_MachineLocationId",
                table: "GeneralTechnicalformations",
                column: "MachineLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralTechnicalformations_UseTypeId",
                table: "GeneralTechnicalformations",
                column: "UseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernerInformations_GovernerTypeId",
                table: "GovernerInformations",
                column: "GovernerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTariffs_InspectionTypeId",
                table: "InspectionTariffs",
                column: "InspectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalDoorLockInformations_LockTypeId",
                table: "MechanicalDoorLockInformations",
                column: "LockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectDetailProperties_ObjectDetailId",
                table: "ObjectDetailProperties",
                column: "ObjectDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectDetailProperties_PropertyId",
                table: "ObjectDetailProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectDetails_ElevatorTypeId",
                table: "ObjectDetails",
                column: "ElevatorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectDetails_ObjectDetailId",
                table: "ObjectDetails",
                column: "ObjectDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_RailsInformations_CabinRailTypeId",
                table: "RailsInformations",
                column: "CabinRailTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RailsInformations_CounterWeightRailTypeId",
                table: "RailsInformations",
                column: "CounterWeightRailTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RailsInformations_ElevatorInformationId",
                table: "RailsInformations",
                column: "ElevatorInformationId",
                unique: true,
                filter: "[ElevatorInformationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyBrakesInformations_BrakeTypeId",
                table: "SafetyBrakesInformations",
                column: "BrakeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyBrakesInformations_LocationTypeId",
                table: "SafetyBrakesInformations",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyBrakesInformations_SafetyBrakesTypeId",
                table: "SafetyBrakesInformations",
                column: "SafetyBrakesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialResources_BranchId",
                table: "SerialResources",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SteelRopeInformations_RopeTypeId",
                table: "SteelRopeInformations",
                column: "RopeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SteeringControlInformations_BoardTypeId",
                table: "SteeringControlInformations",
                column: "BoardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SteeringControlInformations_TravelingCableTypeId",
                table: "SteeringControlInformations",
                column: "TravelingCableTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TractionPulleiesInformations_EngineTypeId",
                table: "TractionPulleiesInformations",
                column: "EngineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TractionPulleiesInformations_LocationTypeId",
                table: "TractionPulleiesInformations",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TractionPulleiesInformations_PulleyMaterialTypeId",
                table: "TractionPulleiesInformations",
                column: "PulleyMaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TractionPulleiesInformations_TractionPulleyTypeId",
                table: "TractionPulleiesInformations",
                column: "TractionPulleyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "CabinAntiShocksInformations");

            migrationBuilder.DropTable(
                name: "CabinDoors");

            migrationBuilder.DropTable(
                name: "CabinInformations");

            migrationBuilder.DropTable(
                name: "ChainsCableInformations");

            migrationBuilder.DropTable(
                name: "CounterWeightInformations");

            migrationBuilder.DropTable(
                name: "CounterWightAntiShocksInformations");

            migrationBuilder.DropTable(
                name: "ElevatorInspections");

            migrationBuilder.DropTable(
                name: "EngineInformations");

            migrationBuilder.DropTable(
                name: "FloorDoorsInformations");

            migrationBuilder.DropTable(
                name: "GovernerInformations");

            migrationBuilder.DropTable(
                name: "InspectionTariffs");

            migrationBuilder.DropTable(
                name: "MechanicalDoorLockInformations");

            migrationBuilder.DropTable(
                name: "ObjectDetailProperties");

            migrationBuilder.DropTable(
                name: "RailsInformations");

            migrationBuilder.DropTable(
                name: "SafetyBrakesInformations");

            migrationBuilder.DropTable(
                name: "SteelRopeInformations");

            migrationBuilder.DropTable(
                name: "SteeringControlInformations");

            migrationBuilder.DropTable(
                name: "TractionPulleiesInformations");

            migrationBuilder.DropTable(
                name: "CabinAntiShockTypes");

            migrationBuilder.DropTable(
                name: "BedMaterialTypes");

            migrationBuilder.DropTable(
                name: "WallMaterialTypes");

            migrationBuilder.DropTable(
                name: "CounterWeightTypes");

            migrationBuilder.DropTable(
                name: "WeightShoesTypes");

            migrationBuilder.DropTable(
                name: "CounterWeightAntiShockTypes");

            migrationBuilder.DropTable(
                name: "InstallationTypes");

            migrationBuilder.DropTable(
                name: "DoorTypes");

            migrationBuilder.DropTable(
                name: "GeneralTechnicalformations");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "BrakeTypes");

            migrationBuilder.DropTable(
                name: "ObjectDetails");

            migrationBuilder.DropTable(
                name: "PulleyMaterialTypes");

            migrationBuilder.DropTable(
                name: "TractionPulleyTypes");

            migrationBuilder.DropTable(
                name: "ElevatorInformations");

            migrationBuilder.DropTable(
                name: "LocationTypes");

            migrationBuilder.DropTable(
                name: "UseTypes");

            migrationBuilder.DropTable(
                name: "ElevatorTypes");

            migrationBuilder.DropTable(
                name: "InspectionTypes");

            migrationBuilder.DropTable(
                name: "InstallatinCompanies");

            migrationBuilder.DropTable(
                name: "LatestCertificateTypes");

            migrationBuilder.DropTable(
                name: "SerialResources");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
