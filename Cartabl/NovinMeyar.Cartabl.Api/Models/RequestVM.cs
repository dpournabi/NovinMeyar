using NovinMeyar.Cartabl.Api.Enums;
using NovinMeyar.Cartabl.Domain.Entities;
using NovinMeyar.Common;
using System;
using System.Text;

namespace NovinMeyar.Cartabl.Api.Models
{
    public class RequestVM
    {
        public long Id { get; set; }
        public long BranchId { get; set; }
        public long? SourceTableKey { get; set; }
        public long RequestTypeId { get; set; }
        public string RequestType { get; set; }
        public string SystemName { get; set; }
        public string RequestTitle { get; set; }
        public string States { get; set; }
        public string LastState { get; set; }
        public int LastStateValue { get; set; }
        public string Url { get; set; }
        public string IsSeen { get; set; }
        public bool IsSeenValue { get; set; }
        public bool IsArchive { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string ExteraInformation { get; set; }
        public long? InstallationCompanyId { get; set; }
        public string BranchName { get; set; }
        public string CustomerFullName { get; set; }
        public string InstallationCompanyName { get; set; }

        public static explicit operator RequestVM(Request m)
        {
            return new RequestVM
            {
                Id = m.Id,
                BranchId = m.BranchId,
                ExteraInformation = m.ExteraInformation,
                IsActive = m.IsActive,
                IsArchive = m.IsActive,
                IsSeen = m.IsSeen ? "دیده شده" : "دیده نشده",
                IsSeenValue = m.IsSeen,
                LastState = m.LastState==-1 ? "درخواست جدید" : ((CartablStates)m.LastState).GetDescription(),
                LastStateValue = m.LastState,
                RequestTitle = m.RequestTitle,
                RequestType = ((RequestTypes)m.RequestTypeId).GetDescription(),
                RequestTypeId = m.RequestTypeId,
                States = GetHistory(m.States),
                SystemName = m.SystemName,
                InstallationCompanyId = m.InstallationCompanyId,
                InstallationCompanyName = m.InstallationCompanyName,
                SourceTableKey = m.SourceTableKey,
                BranchName = m.BranchName,
                CustomerFullName = m.CustomerFullName,
                Url = m.Url,
                CreateDate = m.CreateDate
            };
        }

        public static string GetHistory(int states)
        {
            if(states<=0)
                return null;

            StringBuilder stringBuilder = new StringBuilder();
            if (((CartablStates)states).HasFlag(CartablStates.TechnicalExpertAccept))
                stringBuilder.Append(CartablStates.TechnicalExpertAccept.GetDescription() + " - ");

            if (((CartablStates)states).HasFlag(CartablStates.BranchManagerAccept))
                stringBuilder.Append(CartablStates.BranchManagerAccept.GetDescription() + " - ");

            if (((CartablStates)states).HasFlag(CartablStates.BranchManagerReject))
                stringBuilder.Append(CartablStates.BranchManagerReject.GetDescription() + " - ");

            if (((CartablStates)states).HasFlag(CartablStates.TechnicalManagerAccept))
                stringBuilder.Append(CartablStates.TechnicalManagerAccept.GetDescription() + " ");

            if (((CartablStates)states).HasFlag(CartablStates.TechnicalManagerReject))
                stringBuilder.Append(CartablStates.TechnicalManagerReject.GetDescription() + " ");
            return stringBuilder.ToString();
        }
    }
}
