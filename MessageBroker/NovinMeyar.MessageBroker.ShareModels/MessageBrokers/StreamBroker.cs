namespace NovinMeyar.Common.MessageBrokers
{
    public class StreamBroker : BaseEntity
    {
        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public string Tag { get; set; }//SystemName-EntityName-PrimaryKey-Guid
        public byte[] Content { get; set; }
        public bool IsValid { get; set; }
    }
}
