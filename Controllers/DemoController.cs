using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobiWifiApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobiWifiApp.Controllers
{
    public class DemoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            List<Person> list = new List<Person>();
            Person m1 = new Person(1,"Doduyhuy");
            Person m2 = new Person(2, "DoduyNam");
            Person m3 = new Person(3, "DoduyHung");
            list.Add(m1);
            list.Add(m2);
            list.Add(m3);
            return View(list);
        }

       
    }
}
