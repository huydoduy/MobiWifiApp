using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobiWifiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MobiWifiApp.Controllers
{
    public class HomeController : Controller
    {
        private cmxContext _context;
        public HomeController(cmxContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReportByDay(int month,int year)
        {
            var result = _context.CmxObservationsLite 
               .Where(x => x.Seenyear == year && x.Seenmonth == month)
                .GroupBy(x => x.Seenday)

                .Select(x => new Report(x.Select(i =>i.Clientmac).Distinct().Count()  ,x.Key  ));
                
            return View(result.ToList());
        }
        [HttpGet]
        public IActionResult ReportByDay()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ReportByHourt(int month,int year)
        {
            var result1 = _context.CmxObservationsLite  //.Take(10000)
               .Where(x => x.Seenyear == year && x.Seenmonth == month)
               .GroupBy(x => new { x.Seenhour, x.Seenday })

          .Select(x => new Report(x.Select(i => i.Clientmac).Distinct().Count(), x.Key.Seenhour)).
          
          ToList();

            var result = result1.GroupBy(i => i.Hours)
                .Select(x => new Report ((int)x.Average(i =>i.Count),x.Key ))
                .ToList();

         
            return Json(result.ToList());
        }
        [HttpGet]
        public IActionResult ReportByHourt()
        {

            return View();
        }


        [HttpPost]
        public JsonResult CountPerson(int month,int year)
        {

            var result = _context.CmxObservationsLite  //.Take(10000)
               .Where(x => x.Seenyear == year && x.Seenmonth == month &&x.Ssid !=null) 
               .GroupBy(x => new {x.Clientmac,x.Seenday }).Select(x =>x.Key.Clientmac ).ToList();

            var result2 = result.GroupBy(x => x).Select(x =>x.Count());
            var result3 = result2.GroupBy(x => x).OrderBy(x =>x.Key).Select(x => new CountPerson(x.Count(), x.Key));


            return Json(result3.ToList());
        }

        [HttpGet]
        public IActionResult CountPerson()
        {
            return View();
        }

        [HttpPost]
        public JsonResult report(int month, int year)
        {
           
            var result = _context.CmxObservationsLite.Take(10000)  //.Take(10000)
                .Where(x => x.Seenyear == year && x.Seenmonth == month)
                .GroupBy(x => x.Seenhour)

                .OrderBy(x => x.Key)
                .Select(x => new Report(x.Count(), x.Key));

            return Json(result.ToList());
        }
        [HttpGet]
        public IActionResult report()
        {
            return View();
        }


    }
}