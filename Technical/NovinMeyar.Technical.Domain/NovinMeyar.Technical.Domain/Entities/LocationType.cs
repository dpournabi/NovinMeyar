using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// نوع موقعیت
    /// </summary>
    public class LocationType : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        /// <summary>
        /// 1- ترمز ایمنی
        /// 2- محل قرارگیری فلکه
        /// 3- اطلاعات درب طبقه
        /// 4- اطلاعات درب کابین
        /// 5- موقعیت وزنه تعادل
        /// 6- موقعیت گاورنر
        /// 7- موقعیت سیستم محرکه در چاه
        /// </summary>
        public int LocationEnum { get; set; }
    }
}
