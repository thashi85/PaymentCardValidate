using ConnXTestAPI.Models;
using ConnXTestAPI.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnXTestAPI.Business.Payment
{
    public class VisaPaymentValidator : PaymentCardValidator
    {
        public bool ValidateCard(PaymentCard card ,out List<Error> errors)
        {
            errors = null;
            if (!ValidateCardNumber(card,out errors))
            {
                return false;
            }
            return true;
        }

        protected override bool ValidateCardLength(PaymentCard card, out Error errors)
        {

            if (!(card.CardNumber.Length == 13 || card.CardNumber.Length == 16))
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
            if (!(card.CardNumber.StartsWith("4")))
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
