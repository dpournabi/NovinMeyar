using System.Collections.Generic;
using System.Net;

namespace NovinMeyar.Common
{
    public class ResponseModel
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public object ExteraInformation { get; set; }
    }
    public class ResponseModel<T> : ResponseModel
    {
        public IEnumerable<T> ResponseList { get; set; }
    }
}
