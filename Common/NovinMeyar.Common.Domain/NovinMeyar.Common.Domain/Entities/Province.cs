using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.Common.Domain.Entities
{
    public class Province
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? BranchId { get; set; }
    }
}
