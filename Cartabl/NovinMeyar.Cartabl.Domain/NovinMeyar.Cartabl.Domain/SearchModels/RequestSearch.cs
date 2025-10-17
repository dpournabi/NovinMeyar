using NovinMeyar.Common;
using System;

namespace NovinMeyar.Cartabl.Domain.SearchModels
{
   public class RequestSearch: Pagination
    {
        public string DocumentNumber { get; set; }
        public int? StatesId { get; set; }
        public int? LastStateID { get; set; }
        public long? RequestTypeId { get; set; }
        public bool? IsSeen { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long? InstallationCompanyId { get; set; }
    }
}
