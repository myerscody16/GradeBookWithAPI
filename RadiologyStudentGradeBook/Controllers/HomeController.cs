using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RadiologyStudentGradeBook.Models;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace RadiologyStudentGradeBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly SinaiGraceRadiologyStudentGradeBookContext _context;//calling to the DB Context
        private readonly IConfiguration _configuration; //used to find api key
        private readonly string APIKey; //used to set api key value
        public IActionResult Index()
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
//Put these inside the method that uses your api when ready, already in gitignore
//string envVar1 = _configuration.GetSection("MailjetAccountDetails")["EnvironmentVariable1"];
//string envVar2 = _configuration.GetSection("MailjetAccountDetails")["EnvironmentVariable2"];
