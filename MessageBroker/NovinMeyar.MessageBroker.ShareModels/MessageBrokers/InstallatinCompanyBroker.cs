using System;

namespace NovinMeyar.Common.MessageBrokers
{
    public class InstallatinCompanyBroker : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string EconomicCode { get; set; }
        public string RegistrationNo { get; set; }
        public string NationalNo { get; set; }
        public long DesigningCertificateId { get; set; }
        public long RegistrationOfficeCertificate { get; set; }
        public string TellPhone { get; set; }
        public string CTOFirstName { get; set; }
        public string CTOLastName { get; set; }
        public string CTOCell { get; set; }
        public DateTime? CTOBirthDate { get; set; }
        public string Address { get; set; }
    }
}
