using NovinMeyar.Common;

namespace NovinMeyar.Technical.Domain.Contracts
{
    public class BaseInformationSearch:Pagination
    {
        public long? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public long? PropertyId { get; set; }
        public long? ElevatorTypeId { get; set; }
        public bool? Deleted { get; set; }
    }
}
