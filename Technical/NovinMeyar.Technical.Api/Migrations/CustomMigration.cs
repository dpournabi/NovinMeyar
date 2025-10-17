using Microsoft.EntityFrameworkCore.Migrations;

namespace NovinMeyar.Technical.Api.Migrations
{
    public partial class InitialCreate
    {
        public void CreateCustomView(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create View dbo.VMFastRegistration
                                   AS
                                    SELECT 
                                           EI.Id,
                                           EI.BranchId,
                                           EI.ElevatorNationalNo,
                                           EI.ISIRINo,
                                           EI.ResponsibleFullName,
                                           EI.ResponsibleCell,
                                           EI.IsActive,
                                           EI.ElevatorTypeId,
                                           EI.SerialResourceId,
                                           EI.DocumentNumber,
                                           EI.BuildingCertificateNo,
                                           EI.BuildingPleque,
                                           EI.BuildingAreaNo,
                                           EI.BuildingIssueDate,
                                           EI.InsuranceNo,
                                           EI.InsuranceIssueDate,
                                           EI.ContractServiceStartDate,
                                           EI.InspectionTypeId,
                                           EI.LatestCertificateTypeId,
                                           EI.CustomerId,
                                           EI.CustomerType,
										   CustomerFullName=(RC.FirstName + ' ' + RC.LastName),
										   CompanyName = LC.Name,
                                           EI.ProvinceId,
                                           EI.CityId,
                                           EI.Address,
                                           EI.InstallatinCompanyId,
                                           EI.LuxMeterSerialNo,
                                           EI.PowerMeterSerialNo,
                                           EI.TypeMeterSerialNo,
                                           EI.MultiMeterSerialNo,
                                           EI.LaserMeterSerialNo,
                                           EI.CollisSerialNo,
                                           EI.ThicknessGaugeSerialNo,
                                           EI.UserCreatorName,
                                           EI.CreateDate,
                                           EI.UserModifiedName,
                                           EI.UserModifiedDate,
                                           EI.Deleted,
	                                       E.[Name] AS ElevatorTypeName,
	                                       I.Title AS InspectionTypeName,
	                                       IC.[Name] AS InstallatinCompanyName,
                                           P.Name AS ProvinceName,
	                                       C.Name AS CityName,
										   EI.ScanDocumentId,
										   EI.CertificateId,
										   EI.ProjectDocumentId,
                                           EI.StopCount
                                    FROM ElevatorInformations AS EI
                                    LEFT JOIN ElevatorTypes AS E ON EI.ElevatorTypeId = E.Id
                                    LEFT JOIN InspectionTypes AS I ON EI.InspectionTypeId=I.Id
                                    LEFT JOIN InstallatinCompanies AS IC ON EI.InstallatinCompanyId = IC.Id
									LEFT JOIN [NovinMeyar.Customer].dbo.RealCustomers AS RC ON EI.CustomerId =  RC.Id
									LEFT JOIN [NovinMeyar.Customer].dbo.LegalCustomers AS LC ON EI.CustomerId =  LC.Id
                                    LEFT JOIN [NovinMeyar.Common].dbo.Cities AS C ON EI.CityId = C.Id
                                    LEFT JOIN [NovinMeyar.Common].dbo.Provinces AS P ON C.ProvinceId = P.Id");
        }
        
    }
}
