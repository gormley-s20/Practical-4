using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SMS.Web.Models;

namespace SMS.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(){
        
      DateTime date_Time = DateTime.Now;
      
      var longTime = date_Time.ToLongTimeString();

      var message = "Time Now";

      ViewBag.LongTime = longTime;
      ViewBag.Message = message;
 
      return View();

    }

    public IActionResult About(){
       
      
       // construct the view model
       var about = new AboutViewModel 
       {
       Formed = new DateTime (2020, 1, 1),
       CompanyName = "Googazon"
       };    
   // render the view
   return View(about);

    }

    

    public IActionResult Privacy()
    {
        return View();

    }
}


   
