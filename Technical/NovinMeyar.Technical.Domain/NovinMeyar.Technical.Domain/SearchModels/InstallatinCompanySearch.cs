using NovinMeyar.Common;
using System.Linq;

namespace NovinMeyar.Technical.Domain.Contracts
{
    public class InstallatinCompanySearch: Pagination
    {
        public long? Id { get; set; }

        public string _Name { get; set; }
        public string Name 
        { 
            get 
            { 
                return _Name?.Trim(); 
            } 
            set 
            {
                _Name = value.Replace('ی', 'ی'); 
            } 
        }
        public string Code { get; set; }
        public string EconomicCode { get; set; }
        public string RegistrationNo { get; set; }
        public string NationalNo { get; set; }
    }
}
