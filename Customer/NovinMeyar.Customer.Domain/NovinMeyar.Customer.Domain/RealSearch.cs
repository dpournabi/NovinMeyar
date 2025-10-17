using NovinMeyar.Common;

namespace NovinMeyar.Customer.Domain
{
    public class RealSearch : Pagination
    {
        public long? Id { get; set; }
        public string Code { get; set; }//کد اختصاصی مشتری
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string TellPhone { get; set; }
    }
}
