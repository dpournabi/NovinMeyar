using NovinMeyar.Common;

namespace NovinMeyar.Technical.Domain.Entities
{
    /// <summary>
    /// سیم بکسل, کابل و زنجیر جبران
    /// </summary>
    public class ChainsCableInformation : BaseEntity
    {
        public float WeightOfAuxChans { get; set; }//وزن زنجیر جبران
        public float WeightOfOneMeterChans { get; set; }//جرم واحد هر متر زنجیر
        public int AuxChainsCount { get; set; }//تعداد زنجیر جبران
        public int TravelingCableCount { get; set; }//تعداد کابل متحرک
        public float MassOfTravelingCable { get; set; }//جرم واحد طول کابل متحرک
        
        //One to one relationship
        public virtual ElevatorInformation ElevatorInformation { get; set; }
    }
}
