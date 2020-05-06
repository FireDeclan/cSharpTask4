using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cSharpTask4.Models;

namespace cSharpTask4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        
        [HttpPost]
        public IActionResult Index(string firstValue, string secondValue)
        {
            double[] cleanValue = checkValue(firstValue, secondValue);
            if (cleanValue[0]==-1)
            {
                ViewBag.feedback = "Oops alphabet detected\nPlease check your input";
            }
            else if (cleanValue[0]==-2)
            {
                ViewBag.feedback = "Oops, you entered a negative number";
            }
            else
            {
                ViewBag.feedback = sqRoot(cleanValue[0],cleanValue[1]);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static double[] checkValue(string valueOne, string valueTwo)
        {
            double checkOne = 0;
            double checkTwo = 0;
            double[] checkedValues = new double[2];
            
            if(!(double.TryParse(valueOne, out checkOne)) || !(double.TryParse(valueTwo, out checkTwo)))
            {
                checkedValues[0] = -1;
                checkedValues[1] = -1;
                return checkedValues;
            }
            else if (checkOne<0||checkTwo<0)
            {
                checkedValues[0] = -2;
                checkedValues[1] = -2;
                return checkedValues;

            }
            else{
                checkedValues[0] = checkOne;
                checkedValues[1] = checkTwo;
                return checkedValues;
            }
        }

        public static string sqRoot(double firstValue, double secondValue)
        {
            float firstRoot = (float)Math.Sqrt(firstValue);
            float secondRoot = (float)Math.Sqrt(secondValue); 
            string responseOne = "The number "+firstValue+" with square root "+firstRoot+" has a higher square root than the number "+secondValue+" with square root "+secondRoot+".";
            string responseTwo = "The number "+secondValue+" with square root "+secondRoot+" has a higher square root than the number "+firstValue+" with square root "+firstRoot+".";
            string responseThree = "The numbers have the same squre roots. Enter different numbers. ";
            if (firstRoot > secondRoot)
            {
                return responseOne;
            }
            else if (firstRoot == secondRoot)
            {
                return responseThree;
            }
            else {
            return responseTwo;
            }
        }
    }

    
}
