using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace NovinMeyar.Finance.Domain.DTO
{
    public class PaymentRequestModel : BasePaymentInput
    {
        [JsonIgnore]
        public const string secretKey = "<RSAKeyValue><Modulus>xhFrnCkqb/D7zO1usM8XZG2PrR+8hJb4aQ9VSbAC82PyXKQT/jnbFSm1D/V5l4w2WVlkRwVco+tyywkoT8Rt1CdLv8oiQzJxhiFxj/1HQxpwNjDUFrNsm0Az1Y0226aKlVxn1AgiOYUXURRIT5QFk+tFFjNGfuULlqHbpPLIYpc=</Modulus><Exponent>AQAB</Exponent><P>+HO2ldq8rG91CrGV0nPKx/D+haxECdmbIqIo24wznoaCMzRAcfpzNcYuM/nNKoNPW5fqUD34JlLg5rCjaSw9jw==</P><Q>zBXbFGEyUuK0rVWcbjDlN21g/O9ZQUC54HvnBuObqjHx3+9rFYkOhK1piyaHHeeXvLGgfsIy1UAp/8tXNpsWeQ==</Q><DP>6NBltB741gzLfG3UmxTuXFWz68b1KtXCzb1u0+yZIl+g+iJokWXDOAyxlvrqCoBpiMbeRrsLIb5gCUxUlGVkeQ==</DP><DQ>VHDGkIwWskyyzPUbIEyCyogrFPxDRchuH/+j+ym5gpXfqfP5rpNiumq1vKlYRntIQP6NlWTse2ds+TU9BI7uoQ==</DQ><InverseQ>CTaSQMu9Eqxh33a8sqzF1C7u49cLP3KlTJpHMaRybYs17vkRs6WP4osegJWGBifcJCUiJ7D60yizNciLyiyT5Q==</InverseQ><D>jy/0zXXtGfPq9OEIzoVH8fBKl+uDi47gkoLlM1otJ+svQM3VLkqBGTGHlbvuZSKV/83h8n3r1QzXdfRu0gu9IQUIP/QLvP8gQtxqas198j71jG9yoEJMiD6MyNOHBmelCy8+ONGS7GdwKQFo4ABuF1aHRuP8+5ii7tFMfYN4FiE=</D></RSAKeyValue>";

        private string _invoiceDate = null;
        public string InvoiceDate
        {
            set
            {
                _invoiceDate = value;
            }
            get
            {
                if (_invoiceDate != null)
                    return _invoiceDate;

                var pCaledar = new PersianCalendar();
                return $"{pCaledar.GetYear(DateTime.Now)}/{pCaledar.GetMonth(DateTime.Now)}/{pCaledar.GetDayOfMonth(DateTime.Now)} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
            }
        }
        public string RedirectAddress { get => "http://gateway.nmaa.co.ir/NovinMeyar.Finance.Api/PaymentBack/VerifyTransaction"; }
        public string Action { get => "1003"; }

        private string _timestamp;
        public string Timestamp 
        {
            set => _timestamp = value;
            get 
            {
                if (_timestamp != null)
                    return _timestamp;

                return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); 
            }
        }
        public static string GetSign(string data)
        {
            var cs = new CspParameters { KeyContainerName = "PaymentTest" };
            var rsa = new RSACryptoServiceProvider(cs) { PersistKeyInCsp = false };
            rsa.Clear();
            rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(secretKey);
            byte[] signMain = rsa.SignData(Encoding.UTF8.GetBytes(data), new
            SHA1CryptoServiceProvider());
            string sign = Convert.ToBase64String(signMain);
            return sign;
        }

        //Send below propertis from client side
        public long InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public string Tag { get; set; }
        public string SourceTable { get; set; }
        public string SourceKey { get; set; }
        public string CreatorUserName { get; set; }
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public string DataFlag { get; set; }
    }
}
