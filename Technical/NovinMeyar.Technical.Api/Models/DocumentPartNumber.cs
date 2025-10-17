using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using NovinMeyar.Technical.Domain.Entities;

namespace NovinMeyar.Technical.Api.Models
{
    public class DocumentPartNumber
    {
        public int ElevatorTypeId { get; set; }
        public int InspectionTypeId { get; set; }
        public string Code { get; set; }

        public static string GenerateDocumentNumber(string branchCode, ElevatorInformation elevatorInfo, string latestDocumentNamber)
        {
            var p = new PersianCalendar();
            var seedLastPartOfLatestDocNumber = latestDocumentNamber!= null ? int.Parse(latestDocumentNamber.Split("/")[3]) + 1 : 1;
            var currenyYear = p.GetYear(DateTime.Now).ToString().Substring(2, 2);
            string code = GetAllDocumentParts()
                          .First(x => x.ElevatorTypeId == elevatorInfo.ElevatorTypeId
                                   && x.InspectionTypeId == elevatorInfo.InspectionTypeId).Code;

            return $"{branchCode.PadLeft(2, '0')}/{code}/{currenyYear}/{seedLastPartOfLatestDocNumber.ToString().PadLeft(4, '0')}";
        }

        public static string UpdateDocumentNumber(ElevatorInformation elevatorInfo)
        {
            var currentDocumnetNumberArr = elevatorInfo.DocumentNumber.Split('/');
            currentDocumnetNumberArr[1] = GetAllDocumentParts()
                          .First(x => x.ElevatorTypeId == elevatorInfo.ElevatorTypeId
                                   && x.InspectionTypeId == elevatorInfo.InspectionTypeId).Code;

            return String.Join('/', currentDocumnetNumberArr);
        }

        private static IEnumerable<DocumentPartNumber> GetAllDocumentParts()
        {
            yield return new DocumentPartNumber { ElevatorTypeId = 1, InspectionTypeId = 1, Code="01" };
            yield return new DocumentPartNumber { ElevatorTypeId = 1, InspectionTypeId = 2, Code = "02" };
            yield return new DocumentPartNumber { ElevatorTypeId = 2, InspectionTypeId = 1, Code = "03" };
            yield return new DocumentPartNumber { ElevatorTypeId = 2, InspectionTypeId = 2, Code = "04" };
        }
    }
}
