using System;

namespace App2c2pTest.Extensions
{
    /// <summary>
    /// An extension method to test valid card.
    /// Input card are expected to be in the format XXXX-XXXXX-XXXX-XXX-XXXX
    /// </summary>
    public static  class ValidationRules
    {
        /// <summary>
        /// check whether  the input string is valid Visa Card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static bool IsValidVisaCard(this string card)
        {
            var inputCard = card.Split('-');
            return inputCard[0].Length==4;
        }
        /// <summary>
        /// check whether  the input string is Master Visa Card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static bool IsValidMasterCard(this string card)
        {
            var inputCard = card.Split('-');
            return inputCard[0].Length == 5;
        }
        /// <summary>
        /// check whether  the input string is valid Amex Card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static bool IsValidAmexCard(this string card)
        {
            var inputCard = card.Split('-');
            if(inputCard[0].Length > 2)
            {
                return inputCard[0].Substring(0,2).Equals("37") || inputCard[0].Substring(0, 2).Equals("34");
            }
            return false;
        }

         /// <summary>
        /// check whether  the input string is valid JBC Card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static bool IsValidJCBCard(this string card)
        {
            var inputCard = card.Split('-');
            if (inputCard.Length > 1)
            {
                return $"{inputCard[0].Substring(0, 4)}-{inputCard[1].Substring(0, 4)}".Equals("3528-3589");
            }
            return false;
        }
        /// <summary>
        /// Check whether the card is 2 digits
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static bool IsCard15Digita(this string card)
        {
            var inputCard = card.Split('-');
            if (inputCard.Length == 3)
            {
                return inputCard[3].Length == 3;
            }
            return false;
        }
        /// <summary>
        /// Check whether the year is lead year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsExpiryDateLeadYear(this int year)
        {
            return DateTime.IsLeapYear(year);
        }
        /// <summary>
        /// Check wheher a number is prime number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPrime(this int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
        /// <summary>
        /// Convert to number
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>

        public static int ToNumber(this string year)
        {
            if (int.TryParse(year, out var n))
            {
                return n;
            }
            return 0;
        }

    }
}
