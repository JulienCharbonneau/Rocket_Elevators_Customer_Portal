using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_Customer_Portal.Models;
using System.IO;


namespace Rocket_Elevators_Customer_Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string getCustomerId()
        {
            string api_url = String.Format("https://localhost:7047/api/Customer/GetCustomerIdByEmail?input_email=werner_flatley@schiller.com");
            WebRequest requestObject = WebRequest.Create(api_url);
            requestObject.Method = "GET";
            HttpWebResponse responseObject = null;
            responseObject = (HttpWebResponse)requestObject.GetResponse();

            string result_api = null;
            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                result_api = sr.ReadToEnd();
                sr.Close();
            }
            return result_api;
        }

        public string getBuildingByCustomerId (long id)
        {
            string api_url = String.Format("https://localhost:7047/api/Building/GetBuildingByCustomerId?id=1");
            WebRequest requestObject = WebRequest.Create(api_url);
            requestObject.Method = "GET";
            HttpWebResponse responseObject = null;
            responseObject = (HttpWebResponse)requestObject.GetResponse();

            string result_api = null;
            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                result_api = sr.ReadToEnd();
                sr.Close();
            }
            return result_api;
        }

        public IActionResult Index()
        {

           


            
            ViewBag.CustomerId = getCustomerId();
            ViewBag.CustomerBuilding = getBuildingByCustomerId(1);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}