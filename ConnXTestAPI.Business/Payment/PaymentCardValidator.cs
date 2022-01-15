using ConnXTestAPI.Models;
using ConnXTestAPI.Models.Interfaces;
using ConnXTestAPI.Models.Payment;
using System;
using System.Collections.Generic;
using static ConnXTestAPI.Models.Constants;
using static ConnXTestAPI.Models.Enums;

namespace ConnXTestAPI.Business.Payment
{
    public abstract class PaymentCardValidator : IPaymentCardValidator
    {        

        public virtual bool ValidateCardNumber(PaymentCard card,out List<Error> errors)
        {
            errors = new List<Error>();
            {
                Error _error = null;
                if (!ValidateCardLength(card, out _error))
                {
                    errors.Add(_error);
                    return false;
                }
            }
            {
                Error _error = null;
                if (!ValidateFirstTwoDigits(card, out _error))
                {
                    errors.Add(_error);
                    return false;
                }
            }
            {
                Error _error = null;
                if (!ValidateLuhnAlgorithm(card, out _error))
                {
                    errors.Add(_error);
                    return false;
                }
            }
            return true;
        }

  
        protected abstract bool ValidateCardLength(PaymentCard card, out Error error);
        protected abstract bool ValidateFirstTwoDigits(PaymentCard card, out Error error);
        protected bool ValidateLuhnAlgorithm(PaymentCard card, out Error error)
        {
            //All of these card types also generate numbers such that they can be validated by the Luhn
            //algorithm, so that&#39;s the second check systems usually try. The steps are:
            //1.Starting with the next to last digit and continuing with every other digit going back to the
            //beginning of the card, double the digit
            //2.Sum all doubled and untouched digits in the number. For digits greater than 9 you will need
            //to split them and sum the independently(i.e. &quot; 10 & quot;, 1 + 0).
            //3.If that total is a multiple of 10, the number is valid.
            //For example, given the card number 4408 0412 3456 7893:
            //1 8 4 0 8 0 4 2 2 6 4 10 6 14 8 18 3
            //2 8 + 4 + 0 + 8 + 0 + 4 + 2 + 2 + 6 + 4 + 1 + 0 + 6 + 1 + 4 + 8 + 1 + 8 + 3 = 70
            //3 70 % 10 == 0
            //Thus that card is valid.
            error = new Error();
            try
            {
                int _total = 0;
                for (int i = 0; i < card.CardNumber.Length; i += 2)
                {
                    var number = Convert.ToInt32(card.CardNumber.Substring(i, 1)) * 2;
                    _total += GetNumberTotal(number);
                    if ((i + 1) < card.CardNumber.Length)
                    {
                        _total += GetNumberTotal(Convert.ToInt32(card.CardNumber.Substring((i + 1), 1)));
                    }
                }
                var _st = _total % 10 == 0;
                if (!_st)
                {
                    error = new Error()
                    {
                        ErrorCode = ErrorCode.InvalidLuhn,
                        Description = ErrorMessage.InvalidCardNumber
                    };
                }
               
                return _st;
            }
            catch (Exception ex)
            {
                //todo
                //need to log exception
                return false;
            }

        }

        private int GetNumberTotal(int number)
        {
            int _total = 0;

            if (number < 10)
                _total += number;
            else
            {

                while (number > 0)
                {
                    int _digit = number % 10;
                    number /= 10;
                    _total += _digit;
                }
            }
            return _total;
        }
    }

   
}
