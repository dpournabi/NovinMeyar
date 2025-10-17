using NovinMeyar.Common;

namespace NovinMeyar.Technical.Domain.Contracts
{
    public class SearchProperty : Pagination
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Deleted { get; set; }
    }
}
