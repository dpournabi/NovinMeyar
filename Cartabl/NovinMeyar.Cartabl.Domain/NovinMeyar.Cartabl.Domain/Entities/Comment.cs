using NovinMeyar.Common;

namespace NovinMeyar.Cartabl.Domain.Entities
{
    /// <summary>
    /// گردش کار هر درخواست
    /// </summary>
    public class Comment:BaseEntity
    {
        public long RequestId { get; set; }
        public Request Request { get; set; }
        public string Descrption { get; set; }
    }
}
