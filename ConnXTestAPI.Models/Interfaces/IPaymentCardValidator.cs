using ConnXTestAPI.Models.Payment;
using ConnXTestAPI.Models.Payment;
using System.Collections.Generic;

namespace ConnXTestAPI.Models.Interfaces
{
    public interface IPaymentCardValidator
    {
        bool ValidateCardNumber(Payment.PaymentCard card,out List<Error> errors);
    }
}
