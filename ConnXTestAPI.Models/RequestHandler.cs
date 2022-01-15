using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnXTestAPI.Models
{
    public class RequestHandler
    {
        public static void ToInternalServerError<T>(APIResult<T> response, string message = "Error Occured")
        {
            response.Status.IsError = true;
            response.Status.ErrorCode = "500";
            response.Status.ErrorMessage = message;
        }
        public static void ToBadRequest<T>(APIResult<T> response, string message = "Invalid Request",List<Error> errors =null)
        {
            response.Status.IsError = true;
            response.Status.ErrorCode = "400";
            response.Status.ErrorMessage = message;
            if (errors != null)
            {
                response.Status.ErrorDetails = errors;
            }
        }
    }
}
