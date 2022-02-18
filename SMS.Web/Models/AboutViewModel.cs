namespace SMS.Web.Models;

  public class AboutViewModel
  {
         public DateTime Formed { get; set; }
   
         public string FormedStr => Formed.ToShortDateString();
   
          public int Days => DateTime.Now.Subtract(Formed).Days;

          public string CompanyName {get; set;}

  }
