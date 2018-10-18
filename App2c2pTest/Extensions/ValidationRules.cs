using System;
using App2c2pTest.Model;

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
            var firstDigits = inputCard[0];
            return firstDigits.Substring(0,1).Equals("4");
        }
        /// <summary>
        /// check whether  the input string is Master Visa Card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static bool IsValidMasterCard(this string card)
        {
            var inputCard = card.Split('-');
            var firstDigits = inputCard[0];
            return firstDigits.Substring(0, 1).Equals("5");
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
            if (inputCard.Length == 4)
            {
                return string.Join("",inputCard).Length == 15;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static CardResponse ValidateVisaYear(this CardResponse response, int year)
        {
            if (year.IsExpiryDateLeadYear())
            {
                response.Result = "Valid";
            }
            else
            {
                response.Result = "InValid";
            }
            return response;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static CardResponse ValidateIsMaterYearPrimeNumber(this CardResponse response, int year)
        {
            if (year.IsPrime())
            {
                response.Result = "Valid";
            }
            else
            {
                response.Result = "InValid";
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
   
        /// <param name="processingCard"></param>
        /// <returns></returns>
        public static CardResponse ValidateIsAmexCard15Digit(this CardResponse response, string processingCard)
        {
            if (processingCard.IsCard15Digita())
            {
                response.Result = "Valid";
            }
            else
            {
                response.Result = "InValid";
            }
            return response;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        /// <param name="cardtype"></param>
        /// <returns></returns>
        public static CardResponse SetCard(this String card, string cardtype)
        {
             
            return new CardResponse{CardType = cardtype};
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static CardResponse SetResult(this CardResponse card, string result)
        {

              card.Result = result ;
            return card;
        }




    }
}
