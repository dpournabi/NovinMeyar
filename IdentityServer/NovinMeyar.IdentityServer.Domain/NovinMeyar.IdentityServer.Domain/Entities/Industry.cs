using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.IdentityServer.Domain.Entities
{
    public class Industry : BaseEntity
    {
        [Column(TypeName = "nvarchar(10)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
    }
}
