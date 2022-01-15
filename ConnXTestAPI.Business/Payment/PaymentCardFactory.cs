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
    public class PaymentCardFactory
    {
        public static IPaymentCardValidator GetPaymentCardValidator(PaymentCard card)
        {
            if (card != null)
            {
                switch (card.CardType)
                {
                    case Enums.CardType.Amex:
                        return new AmexPaymentValidator();
                    case Enums.CardType.Discover:
                        return new DiscoverPaymentValidator();
                    case Enums.CardType.Master:
                        return new MasterPaymentValidator();
                    case Enums.CardType.Visa:
                        return new VisaPaymentValidator();
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
