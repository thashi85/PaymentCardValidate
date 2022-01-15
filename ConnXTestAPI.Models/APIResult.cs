using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnXTestAPI.Models
{
    public class APIResult<T>
    {
        public APIResult()
        {
            Status = new APIResultStatus();
        }

        public APIResultStatus Status { get; set; }

        public T Data { get; set; }

      

    }

    public class APIResultStatus
    {
        public bool IsError { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public List<Error> ErrorDetails { get; set; }

    }
    
}
