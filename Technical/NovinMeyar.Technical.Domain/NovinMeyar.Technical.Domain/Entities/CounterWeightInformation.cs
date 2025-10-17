using NovinMeyar.Common;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// وزنه تعادل
    /// </summary>
    public class CounterWeightInformation : BaseEntity
    {
        public long LocationTypeId { get; set; }//موقعیت وزنه تعادل
        public CounterWeightType BalanceWeightType { get; set; }//نوع وزنه تعادل
        public long BalanceWeightTypeId { get; set; }
        public int BalanceWeightCount { get; set; }//تعداد وزنه
        public decimal TotalWeight { get; set; }//وزن کل کادر وزنه-Z
        public int BalanceRatio { get; set; }//ضریب تعادل وزنه q (بالانس)
        public ShoesType WeightShoesType { get; set; }//نوع کفشک راهنمای کادر وزنه
        public long WeightShoesTypeId { get; set; }

        //One to one relationship
        public virtual ElevatorInformation ElevatorInformation { get; set; }
        public long ElevatorInformationId { get; set; }
        public LocationType LocationType { get; set; }
    }
}
