namespace NovinMeyar.Common.Domain
{ 
    public class SearchCity : Pagination
    {
        public string Name { get; set; }
        public long? CityId { get; set; }
        public long ProvinceId { get; set; }
    }
}
