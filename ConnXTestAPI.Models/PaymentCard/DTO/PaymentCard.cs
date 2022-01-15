using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnXTestAPI.Models.Interfaces;
using static ConnXTestAPI.Models.Enums;

namespace ConnXTestAPI.Models.Payment
{
    public class PaymentCard
    {
        public string CardNumber { get; set; }
        public CardType CardType { get; set; }
       
    }
}
