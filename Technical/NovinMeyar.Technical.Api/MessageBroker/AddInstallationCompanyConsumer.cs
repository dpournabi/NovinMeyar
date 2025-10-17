using MassTransit;
using Newtonsoft.Json;
using NovinMeyar.Common;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.Entities;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.MessageBroker
{
    public class AddInstallationCompanyConsumer : IConsumer<InstallatinCompanyBroker>
    {
        private readonly IInstallatinCompanyService installatinCompanyService;
        public AddInstallationCompanyConsumer(IInstallatinCompanyService installatinCompanyService)
        {
            this.installatinCompanyService = installatinCompanyService;
        }
        public async Task Consume(ConsumeContext<InstallatinCompanyBroker> context)
        {
            try
            {
                Log.Information("New request for register a new installatin company recieved!");
                var installationCompany = await installatinCompanyService.SearchAsync(new InstallatinCompanySearch { RegistrationNo = context.Message.RegistrationNo }, true, null, null);
                var obj = installationCompany.ResponseList.FirstOrDefault();
                var response = new ResponseModel { Succeed = true, Data = obj?.Id };
                if (obj == null)
                    response = await installatinCompanyService.RegisterNewAsync(new InstallatinCompany
                    {
                        Id = context.Message.Id,
                        Code = context.Message.Code,
                        Name = context.Message.Name,
                        CTOBirthDate = context.Message.CTOBirthDate,
                        CTOCell = context.Message.CTOCell,
                        CTOFirstName = context.Message.CTOFirstName,
                        CTOLastName = context.Message.CTOLastName,
                        NationalNo = context.Message.NationalNo,
                        EconomicCode = context.Message.EconomicCode,
                        DesigningCertificateId = context.Message.DesigningCertificateId,
                        RegistrationOfficeCertificate = context.Message.RegistrationOfficeCertificate,
                        RegistrationNo = context.Message.RegistrationNo,
                        TellPhone = context.Message.TellPhone,
                        Address = context.Message.Address,
                        CreateDate = context.Message.CreateDate,
                        Deleted = context.Message.Deleted,
                        UserCreatorName = context.Message.UserCreatorName,
                        UserModifiedDate = context.Message.UserModifiedDate,
                        UserModifiedName = context.Message.UserModifiedName
                    }, "System");
                Log.Information($"Register a new installation company at {DateTime.Now}. Recieved model: {JsonConvert.SerializeObject(context.Message)}");
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{DateTime.Now} - {nameof(AddInstallationCompanyConsumer)} --> {nameof(Consume)} --> Error deatail");
            }

        }
    }
    public class UndoAddInstallationCompanyConsumer : IConsumer<RemoveInstallationCompanyBroker>
    {
        private readonly IInstallatinCompanyService installatinCompanyService;
        public UndoAddInstallationCompanyConsumer(IInstallatinCompanyService installatinCompanyService)
        {
            this.installatinCompanyService = installatinCompanyService;
        }
        public async Task Consume(ConsumeContext<RemoveInstallationCompanyBroker> context)
        {
            try
            {
                Log.Information("New request for undoing registered new installatin company recieved!");
                var response = await installatinCompanyService.PhysicalDeleteAsync(context.Message.Id, "System");
                Log.Information($"Deleted installation company at {DateTime.Now}. Recieved model: {JsonConvert.SerializeObject(context.Message)}");
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"{DateTime.Now} - {nameof(AddInstallationCompanyConsumer)} --> {nameof(Consume)} --> Error deatail");
            }

        }
    }
}