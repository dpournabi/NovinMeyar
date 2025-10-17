using NovinMeyar.Common;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// فلکه های کشش(هرزگرد)
    /// </summary>
    public class TractionPulleiesInformation:BaseEntity
    {
        public bool HasWanderingSquare { get; set; }//فلکه هرزگرد دارد؟
        public bool IsSquareReverse { get; set; }//هرزگرد معکوس
        public LocationType LocationType { get; set; }
        public long LocationTypeId { get; set; }//محل قرارگیری فلکه
        public string SerialNo { get; set; }//سریال فلکه هرزگرد
        public ObjectDetail EngineType { get; set; }//نام سازنده فلکه هرزگرد
        public long EngineTypeId { get; set; }
        public PulleyMaterialType PulleyMaterialType { get; set; }//جنس فلکه هرزگرد
        public long PulleyMaterialTypeId { get; set; }
        public TractionPulleyType TractionPulleyType { get; set; }//نوع فلکه کششی(جنس)
        public long TractionPulleyTypeId { get; set; }
        public int SquareReverseCount { get; set; }//تعداد هرزگرد معکوس
        public int Quantity { get; set; }//تعداد
        public int PulleyDiameter { get; set; }//قطر فلکه بر حسب میلیمتر


        //One to one relationship
        public virtual ElevatorInformation ElevatorInformation { get; set; }
        public long? ElevatorInformationId { get; set; }
    }
}
