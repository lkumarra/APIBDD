using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Helpers.StringExtension
{
    static class StringExtension
    {
        /// <summary>
        /// Generate a string on the basis of input string
        /// </summary>
        /// <param name="inputStr">Input String</param>
        /// <returns>Requested string</returns>
        public static string RequestStringParser(this string inputStr)
        {
            return inputStr.Equals(Constants.NullString) ? null
                : inputStr.Equals(Constants.EmptyString) ? string.Empty
                : inputStr.Equals("SpecialCharacters") ? Constants.specialCharacter
                : inputStr.StartsWith("RepeatCharacters:") ? string.Concat(Enumerable.Repeat("A", Convert.ToInt32(inputStr.Split(':')[1])))
                : inputStr;
        }
    }
}
