using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobiWifiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> ReportByDay(int months,int years)
        {
            var result = _context.CmxObservationsLite  //.Take(10000)
               .Where(x => x.Seenyear == years && x.Seenmonth == months)
                .GroupBy(x => x.Seenday)

                .Select(x => new Report(x.Select(i =>i.Clientmac).Distinct().Count()  ,1   ));
                



            return View(await result.ToListAsync());
        }
        public IActionResult CountPerson()
        {



            var result = _context.CmxObservationsLite  //.Take(10000)
               .Where(x => x.Seenyear == 2017 && x.Seenmonth == 2 &&x.Ssid !=null) 
                .GroupBy(x => new {x.Clientmac,x.Seenday }).Select(x =>x.Key.Clientmac ).ToList();

            var result2 = result.GroupBy(x => x).Select(x =>x.Count());
            var result3 = result2.GroupBy(x => x).OrderBy(x =>x.Key).Select(x => new CountPerson(x.Count(), x.Key));


            return View(result3.ToList());
        }
    }
}