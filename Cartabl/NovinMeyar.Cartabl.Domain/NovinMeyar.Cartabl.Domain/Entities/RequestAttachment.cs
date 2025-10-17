using NovinMeyar.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Cartabl.Domain.Entities
{
    /// <summary>
    /// فایل های پیوستی هر درخواست
    /// </summary>
    public class RequestAttachment:BaseEntity
    {
        public AttachmentType AttachmentType { get; set; }
        public long FileTag { get; set; }
        public Request Request { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public bool HasAccepted { get; set; }
    }
}
