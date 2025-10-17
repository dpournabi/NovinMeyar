using NovinMeyar.Common;
using System.ComponentModel.DataAnnotations;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// اطلاعات ریل ها
    /// </summary>
    public class RailsInformation:BaseEntity
    {
        public ObjectDetail CabinRailType { get; set; }//نوع ریل کابین
        public long? CabinRailTypeId { get; set; }

        public float CabinRailDistance { get; set; }//فاصله ریل کابین
        public int CabinRailCount { get; set; }//تعداد ریل کابین

        public bool ManualRailDetail { get; set; }
        public int K { get; set; } //ابعاد ریل راهنما کابین
        public int h1 { get; set; }//ابعاد ریل راهنما کابین
        public int b1 { get; set; }//ابعاد ریل راهنما کابین

        public int RailInstallationType { get; set; }//نحوه نصب ریل راهنما: 0-مرکزی 1-لیفتراکی 2-قطری
        
        public ObjectDetail CounterWeightRailType { get; set; }//نوع ریل کادر وزنه
        public long? CounterWeightRailTypeId { get; set; }
        public float CounterWeightRailDistance { get; set; }//فاصله ریل کادر وزنه
        public int CounterWeightRailCount { get; set; }//تعداد ریل کادر وزنه
        public decimal RailLength { get; set; }//طول ریل کابین
        public float PressureOnRail { get; set; }//نیرو در ریل ناشی از بار تجهیزات جانبی**
        public float CabinCenterDistanceFromRailX { get; set; }//فاصله مرکز کابین از ریل راهنما در جهت Xc
        public float CabinCenterDistanceFromRailY { get; set; }//فاصله مرکز کابین از ریل راهنما در جهت Yc
        public float CabinCenterDistanceMassFromRailX { get; set; }//فاصله مرکز جرم کابین از ریل راهنما در جهت Xp
        public float CabinCenterDistanceMassFromRailY { get; set; }//فاصله مرکز جرم کابین از ریل راهنما در جهت Yp
        public float AnchorCenterDistanceFromRailX { get; set; }//فاصله مرکز آویز از ریل راهنما در جهت Xs
        public float AnchorCenterDistanceFromRailY { get; set; }//فاصله مرکز آویز از ریل راهنما در جهت Ys
        public float CabinDoorDistanceFromRailX { get; set; }//فاصله در کابین از ریل راهنما در جهت Xi
        public float CabinDoorDistanceFromRailY { get; set; }//فاصله در کابین از ریل راهنما در جهت Yi
        public float BracketDistance { get; set; }//حداکثر فاصله براکت ها
        //One to one relationship
        public long? ElevatorInformationId { get; set; }
        public virtual ElevatorInformation ElevatorInformation { get; set; }
    }
}
