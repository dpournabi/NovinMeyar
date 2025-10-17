using NovinMeyar.Common;
using System;

namespace NovinMeyar.FileManagment.Domain.Entities
{
    public class DownloadLinkHistory: BaseEntity
    {
        public long StreamId { get; set; }
        public string EncryptedKey { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
