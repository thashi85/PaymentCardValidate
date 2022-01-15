using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnXTestAPI.Models.Payment
{
    public class CardValidationResponse
    {
        public bool IsValid { get; set; }
        public List<Error> ErrorDetails { get; set; }
    }
}
