using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvite.Models;

namespace PartyInvite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
     public IActionResult Index()
    {
      List<string> ipList = new List<string>();

      if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
      {
        System.Console.WriteLine("Current IP Addresses:");
        string hostname = System.Net.Dns.GetHostName();
        System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(hostname);
        foreach (System.Net.IPAddress address in host.AddressList)
        {
          System.Console.WriteLine($"\t{address}");
          ipList.Add($"\t{address}");
        }
      }
      else
      {
        System.Console.WriteLine("No Network Connection");
        ipList.Add("No Network Connection");
      }
      return View(ipList);
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
