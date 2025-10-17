using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Common.Domain.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long ProvinceId { get; set; }

        [Required]
        public string Name { get; set; }
        public Province Province { get; set; }
    }
}
