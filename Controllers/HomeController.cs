using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_Customer_Portal.Models;
using System;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        public Building getBuildingByCustomerId (long id)
        {
            string api_url = String.Format("https://localhost:7047/api/Building/GetBuildingByCustomerId?id=" + id);
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
            
                // Deserialize the JSON string into a Building object
                Building building = JsonConvert.DeserializeObject<Building>(result_api);

                // Output the ID of the building

                return building;
          


        }

      

        public IActionResult Index()
        {

            var customer_building = getBuildingByCustomerId(1);

            List<long> batteryIds = new List<long>(); // loop to retrieve all batteries ids 
            foreach (var battery in customer_building.Batteries)
            {
                batteryIds.Add(battery.Id);
            }

            List<long> columnIds = new List<long>();// loop to retrieve all columns ids
            foreach (var battery in customer_building.Batteries)
            {
                foreach (var column in battery.Columns)
                {
                    columnIds.Add(column.Id);
                    Console.WriteLine("test column id: " + columnIds);
                }
            }

            List<long> elevatorIds = new List<long>();
            foreach (var battery in customer_building.Batteries)
            {
                foreach (var column in battery.Columns)
                {
                    foreach (var elevator in column.Elevators)
                    {
                        elevatorIds.Add(elevator.Id);
                    }
                }
            }

            ViewBag.CustomerElevators = elevatorIds;
            ViewBag.CustomerColumns = columnIds;
            ViewBag.CustomerBatteries = batteryIds;
            ViewBag.CustomerId = getCustomerId();
            ViewBag.CustomerBuilding = customer_building.BuildingAddress;

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