using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnXTestAPI.Models
{
    public class Constants
    {
        public class ErrorCode
        {
            public const string InvalidCardLength = "ERROR_001";
            public const string InvalidFirstTwoDigits = "ERROR_002";
            public const string InvalidCardNumber = "ERROR_003";
            public const string EmptyCardNumber = "ERROR_004";
            public const string InvalidLuhn = "ERROR_005";

        }
        public class ErrorMessage
        {
            public const string InvalidCardLength = "Card length is not valid";
           // public const string InvalidFirstTwoDigits = "First two digits are not valid";
            public const string InvalidCardNumber = "Invalid card number";
            public const string EmptyCardNumber = "Card number is empty";

        }
    }
}
