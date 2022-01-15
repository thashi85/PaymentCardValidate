using ConnXTestAPI.Business;
using ConnXTestAPI.Models;
using ConnXTestAPI.Models.Payment;
using ConnXTestAPI.Models.Payment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ConnXTestAPI.Controllers
{
    [Route("api/V1.0/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentCard> _logger;
        private readonly PaymentManager _paymentManager;
        public PaymentController(ILogger<PaymentCard> logger, PaymentManager paymentManager)
        {
            _logger = logger;
            _paymentManager = paymentManager;
        }
        #region Card Type

        [HttpPost("card-types/validate")]
        public IActionResult ValidateCardType([FromBody] PaymentCard jsonParam)
        {
            //controller will handle input and output
            var _retData = new APIResult<CardValidationResponse>();
            try
            {
                
                //Input Validtaion 
                Error _err;
                if (!_paymentManager.ValidateInput(jsonParam, out _err))
                {
                    RequestHandler.ToBadRequest(_retData, errors:new List<Error>() { _err });
                }
                else
                {                    
                    List<Error> _errors = null;
                    _retData.Data = new CardValidationResponse();
                    _retData.Data.IsValid = _paymentManager.ValidateCardType(jsonParam, out _errors);
                    
                    if (_errors?.Count > 0)
                        _retData.Data.ErrorDetails = _errors;
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ValidateCardType", new { });
                 RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }
       
        #endregion Card Type
    }
}
