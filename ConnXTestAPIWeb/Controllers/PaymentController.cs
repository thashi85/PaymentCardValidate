using ConnXTestAPIWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnXTestAPIWeb.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationSetting _settings;

        public PaymentController(IOptions<ApplicationSetting> settings)
        {

            _settings = settings.Value;
        }
        public IActionResult Index()
        {
            //temp
            ViewBag.WebAPIUrl = _settings.WebAPIUrl;
            return View();
        }
    }
}
