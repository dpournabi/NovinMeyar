namespace NovinMeyar.Common.MessageBrokers
{
    public class RequestRegistrationBroker
    {
        public long? RequestTypeId { get; set; }//نوع درخواست
        public string RequestTitle { get; set; }//عنوان درخواست
        public long BranchId { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string SystemName { get; set; }
        public long? RequestId { get; set; }
        public string BranchName { get; set; }
        public string CustomerFullName { get; set; }
        public string InstallationCompanyName { get; set; }
        public long? InstallationCompanyId { get; set; }
        public long? SourceTableKey { get; set; }//شناسه میکروسرویس مبدا
    }
}
