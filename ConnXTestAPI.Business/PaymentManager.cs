using ConnXTestAPI.Business.Payment;
using ConnXTestAPI.Models;
using ConnXTestAPI.Models.Payment;
using ConnXTestAPI.Models.Payment;
using System;
using System.Collections.Generic;

namespace ConnXTestAPI.Business
{
    public class PaymentManager
    {
        public bool ValidateCardType(PaymentCard jsonParam, out List<Error>  errors)
        {            
            errors = new List<Error>();
            //Process Json
            jsonParam.CardNumber = jsonParam.CardNumber.Replace(" ", "");
            var _validator = PaymentCardFactory.GetPaymentCardValidator(jsonParam);
            return _validator!=null? _validator.ValidateCardNumber(jsonParam,out errors): false;
        }
        public bool ValidateInput(PaymentCard card, out Error error)
        {
            error = new Error();
            if (card==null || string.IsNullOrEmpty(card.CardNumber))
            {
                error = new Error()
                {
                    Description = Constants.ErrorMessage.EmptyCardNumber,
                    ErrorCode = Constants.ErrorCode.EmptyCardNumber
                };
                return false;
            }
            return true;
        }
    }
}
