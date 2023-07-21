using amsterdam.Models;
using amsterdam.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace amsterdam.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index() 
        {
            var website = new Website() { Name = "Amsterdam", Description="Travel Site"};
            var admin = new List<Admin>()
            {
                new Admin(){Name="Sinem Taşdemir",Phone="05367382742",Email="sinem@gmail.com"},
                new Admin(){Name="Hazal Tuğrul",Phone="05556738276",Email="hazal@gmail.com"},
                new Admin(){Name="Ayşenur Yılmaz",Phone="05306737642",Email="ayşenur@gmail.com"}
            };
            var viewmodel = new WebsiteAdmin();
            viewmodel.website = website;
            viewmodel.admin = admin;
            return View(viewmodel);
        }
    }
}
