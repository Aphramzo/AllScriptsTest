using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Microsoft.AspNetCore.Authorization;

namespace AllScriptsTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string clientId = "27bbad6d-5f76-474a-8c5e-baf68eb6b10c";
            string secret = "DC94CFCE6213";
            string scope = "patient/*.read";
            string parameters = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope={2}", clientId, secret, scope);

            var client = new RestClient("https://tw171.open.allscripts.com/authorization/connect/token");

            var request = new RestRequest(Method.POST); request.AddHeader("cache-control", "no-cache");

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", parameters, ParameterType.RequestBody);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [Authorize]
        public IActionResult Restricted()
        {
            return View();
        }
    }
}
