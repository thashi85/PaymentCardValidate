using ConnXTestAPI.Models;
using ConnXTestAPI.Models.Interfaces;
using ConnXTestAPI.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnXTestAPI.Business.Payment
{
    public class AmexPaymentValidator : PaymentCardValidator
    {
        //this is added to concrete class level,
        //because in future if we need to add another validation to amex it can be added easily without effecting to other card types

        //public override bool ValidateCardNumber(Card card,out List<Error> errors)
        //{
        //    errors = null;

        //    return true;
        //}


        protected override bool ValidateCardLength(PaymentCard card, out Error errors)
        {

            if (!(card.CardNumber.Length == 15))
            {
                errors = new Error()
                {
                    Description = Constants.ErrorMessage.InvalidCardLength,
                    ErrorCode = Constants.ErrorCode.InvalidCardLength
                };
                return false;
            }
            errors = null;
            return true;
        }
        protected override bool ValidateFirstTwoDigits(PaymentCard card, out Error errors)
        {
            if (!(card.CardNumber.StartsWith("34") || card.CardNumber.StartsWith("37")))
            {
                errors = new Error()
                {
                    Description = Constants.ErrorMessage.InvalidCardNumber,
                    ErrorCode = Constants.ErrorCode.InvalidFirstTwoDigits
                };
                return false;
            }
            errors = null;
            return true;
        }
    }
}
