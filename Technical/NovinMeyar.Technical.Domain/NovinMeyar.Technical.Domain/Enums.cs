using System;
using System.ComponentModel;

namespace NovinMeyar.Technical.Domain
{
    [Flags]
    public enum InstallRailEquipment
    {
        [Description("گاورنر")]
        Governer = 1,// 2^0

        [Description("موتور")]
        Engine = 2, // 2^1

        [Description("سربکسل")]
        RopeAttachments = 4// 2^2
    }



    public enum EngineAccessType
    {
        OnTheCabin = 0,//از روی کابین
        InTheCabin = 1,//از داخل کابین
        InThePit = 2,//از داخل چاهک
        OnThePaltform = 3,//از روی کفی
        OutOfShaft = 4//از بیرون چاه
    }
}
