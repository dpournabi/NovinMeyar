using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Cartabl.Domain.Entities
{
    /// <summary>
    /// درخواست ها
    /// </summary>
    public class Request:BaseEntity
    {
        public long BranchId { get; set; }
        public long RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string SystemName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string RequestTitle { get; set; }
        public int States { get; set; }
        public int LastState { get; set; }
        public string Url { get; set; }
        public bool IsSeen { get; set; }
        public bool IsArchive { get; set; }
        public bool IsActive { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string ExteraInformation { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BranchName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string CustomerFullName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string InstallationCompanyName { get; set; }

        public long? InstallationCompanyId { get; set; }
        public long? SourceTableKey { get; set; }
    }
}
