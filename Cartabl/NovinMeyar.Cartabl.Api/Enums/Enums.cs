using System;
using System.ComponentModel;

namespace NovinMeyar.Cartabl.Api.Enums
{
    [Flags]
    public enum CartablStates
    {
        [Description("تایید بازرس")]
        TechnicalExpertAccept = 1, //2^0

        [Description("تایید مدیر شعبه")]
        BranchManagerAccept = 2, //2^1

        [Description("نقص مدارک-بررسی مجدد")]
        BranchManagerReject = 4, //2^2

        [Description("تایید مدیر فنی")]
        TechnicalManagerAccept = 8, //2^3

        [Description("نقص مدارک-بررسی مجدد")]
        TechnicalManagerReject = 16, //2^4
    }

    public enum RequestTypes
    {
        [Description("درخواست بازرسی آسانسور")]
        ElevatorInspection,
        [Description("درخواست بازرسی کالا")]
        ProductInspection
    }
}
