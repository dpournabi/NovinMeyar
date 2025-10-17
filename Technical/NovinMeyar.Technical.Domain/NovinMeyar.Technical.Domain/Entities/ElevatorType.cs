
using NovinMeyar.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// نوع آسانسور
    /// </summary>
    public class ElevatorType:BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
    }
}
