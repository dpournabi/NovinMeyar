namespace NovinMeyar.Common.MessageBrokers
{
    public class UpdateRequestBroker
    {
        public long SourceTableKey { get; set; }
        public string DocumentNumber { get; set; }
        public string BranchName { get; set; }
    }
}
