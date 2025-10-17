using NovinMeyar.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// نوع درب
    /// </summary>
    public class DoorType : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        public bool IsCabin { get; set; }
    }
}
