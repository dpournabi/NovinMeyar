using NovinMeyar.Common;

namespace NovinMeyar.Customer.Domain
{
    public class LegalSearch : Pagination
    {
        public long? Id { get; set; }
        public string Code { get; set; }//کد اختصاصی مشتری
        public string Name { get; set; }
        public string EconomicCode { get; set; }
        public string RegisterNo { get; set; }
        public string NationalCode { get; set; }
        public string CEOFirstName { get; set; }//نام مدیرعامل
        public string CEOLastName { get; set; }//نام خانوادگی مدیرعامل
    }
}
