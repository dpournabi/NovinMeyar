using System;
using System.Globalization;

namespace NovinMeyar.Common
{
    public class PaymentIdentityGenerator
    {
        public string GenerateTraceNumber(long id, string accountNumber, decimal price)
        {
            var traceNumber = GetDateFormattedTraceNumber(id);
            var checkDigitNumber = GetCheckDigitNumber(traceNumber, accountNumber, price);
            return traceNumber + checkDigitNumber;
        }
        private string GetCheckDigitNumber(string traceNumber, string accountNumber, decimal amount)
        {
            int[] primeNumbersA = new int[] { 53, 47, 43, 41, 37, 31, 29, 23, 19, 17, 13, 11, 7, 5, 3 };
            //int[] primeNumbersB = new int[] { 59, 53, 47, 43, 41, 37, 31, 29, 23, 19, 17, 13, 11 };
            int[] primeNumbersB = new int[] { 37, 31, 29, 23, 19, 17, 13, 11, 7, 5 };
            int[] primeNumbersC = new int[] { 61, 59, 53, 47, 43, 41, 37, 31, 29, 23, 19, 17, 13, 11, 7 };
            var sumA = GetSumFromPrimeNumbers(traceNumber, primeNumbersA);
            //var sumB = GetSumFromPrimeNumbers(accountNumber.ToString().PadLeft(13, '0'), primeNumbersB);
            var sumB = GetSumFromPrimeNumbers(accountNumber.ToString().PadLeft(10, '0'), primeNumbersB);
            var sumC = GetSumFromPrimeNumbers(amount.ToString("0").PadLeft(15, '0'), primeNumbersC);
            var mode = (sumA + sumB + sumC) % 99;
            return mode.ToString().PadLeft(2, '0');
        }
        private int GetSumFromPrimeNumbers(string parameter, int[] primeNumbers)
        {
            var sum = 0;
            var primaryNumbersLength = primeNumbers.Length;
            for (int i = 0; i < primaryNumbersLength; i++)
            {
                var parameterIndex = primeNumbers.Length - (i + 1);
                sum += int.Parse(parameter[parameterIndex].ToString()) * primeNumbers[i];
            }
            return sum;
        }
        private string GetDateFormattedTraceNumber(long pk)
        {
            var pCalendar = new PersianCalendar();
            var currentDate = DateTime.Now;
            var year = pCalendar.GetYear(currentDate).ToString();
            var dateFormat = $"{year.Substring(year.Length - 2)}{pCalendar.GetMonth(currentDate):00}{pCalendar.GetDayOfMonth(currentDate):00}";

            var pkLength = pk.ToString().Length;

            string pkFormat;

            //algorim Peymani 99 with amount length fix 17  digit
            if (pkLength < 8)
            {
                pkFormat = pk.ToString().PadLeft(8, '0');
            }
            else
            {
                pkFormat = pk.ToString().Substring(pkLength - 8, 8);
            }
            var traceNumber = dateFormat + pkFormat + "2";
            return traceNumber;
        }
    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public class PaymentIdentityGenerator
    //    {
    //		private static int[,] _multiplicationTable = {
    //	{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
    //	{ 1, 2, 3, 4, 0, 6, 7, 8, 9, 5 },
    //	{ 2, 3, 4, 0, 1, 7, 8, 9, 5, 6 },
    //	{ 3, 4, 0, 1, 2, 8, 9, 5, 6, 7 },
    //	{ 4, 0, 1, 2, 3, 9, 5, 6, 7, 8 },
    //	{ 5, 9, 8, 7, 6, 0, 4, 3, 2, 1 },
    //	{ 6, 5, 9, 8, 7, 1, 0, 4, 3, 2 },
    //	{ 7, 6, 5, 9, 8, 2, 1, 0, 4, 3 },
    //	{ 8, 7, 6, 5, 9, 3, 2, 1, 0, 4 },
    //	{ 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }
    //};

    //		private static int[,] _permutationTable = {
    //	{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
    //	{ 1, 5, 7, 6, 2, 8, 3, 0, 9, 4 },
    //	{ 5, 8, 0, 3, 7, 9, 6, 1, 4, 2 },
    //	{ 8, 9, 1, 6, 0, 4, 3, 5, 2, 7 },
    //	{ 9, 4, 5, 3, 1, 2, 6, 8, 7, 0 },
    //	{ 4, 2, 8, 6, 5, 7, 3, 9, 0, 1 },
    //	{ 2, 7, 9, 3, 8, 0, 6, 4, 1, 5 },
    //	{ 7, 0, 4, 6, 9, 1, 3, 2, 5, 8 }
    //};

    //		private static int[] _inverseTable = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

    //		public static int CheckSum(string number)
    //		{
    //			int c = 0;
    //			int len = number.Length;

    //			for (int i = 0; i < len; ++i)
    //				c = _multiplicationTable[c, _permutationTable[((i + 1) % 8), number[len - i - 1] - '0']];

    //			return _inverseTable[c];
    //		}

    //		public static bool Validate(string number)
    //		{
    //			int c = 0;
    //			int len = number.Length;

    //			for (int i = 0; i < len; ++i)
    //				c = _multiplicationTable[c, _permutationTable[(i % 8), number[len - i - 1] - '0']];

    //			return c == 0;
    //		}
//}
}
