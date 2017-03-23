using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobiWifiApp.Models;
using MobiWifiApp;

namespace MobiWifiApp.Controllers
{
    public class CmxObservationsController : Controller
    {
        private  cmxContext _context;

        public CmxObservationsController(cmxContext context)
        {
            _context = context;    
        }

        // GET: CmxObservations
        public async Task<IActionResult> Index()
        {
            var cmxContext = _context.CmxObservations.Include(c => c.Event).Take(30);
            return View(await cmxContext.ToListAsync());
        }

        // GET: CmxObservations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmxObservations = await _context.CmxObservations
                .Include(c => c.Event)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cmxObservations == null)
            {
                return NotFound();
            }

            return View(cmxObservations);
        }

        // GET: CmxObservations/Create
        public IActionResult Create()
        {
            ViewData["Eventid"] = new SelectList(_context.CmxEvents, "Id", "Type");
            return View();
        }

        // POST: CmxObservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Clientmac,Ipv4,Ipv6,Seentime,Ssid,Rssi,Manufacturer,Os,LocationLat,LocationLng,LocationUnc,Id,Eventid")] CmxObservations cmxObservations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cmxObservations);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Eventid"] = new SelectList(_context.CmxEvents, "Id", "Type", cmxObservations.Eventid);
            return View(cmxObservations);
        }

        // GET: CmxObservations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmxObservations = await _context.CmxObservations.SingleOrDefaultAsync(m => m.Id == id);
            if (cmxObservations == null)
            {
                return NotFound();
            }
            ViewData["Eventid"] = new SelectList(_context.CmxEvents, "Id", "Type", cmxObservations.Eventid);
            return View(cmxObservations);
        }

        // POST: CmxObservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Clientmac,Ipv4,Ipv6,Seentime,Ssid,Rssi,Manufacturer,Os,LocationLat,LocationLng,LocationUnc,Id,Eventid")] CmxObservations cmxObservations)
        {
            if (id != cmxObservations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cmxObservations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CmxObservationsExists(cmxObservations.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["Eventid"] = new SelectList(_context.CmxEvents, "Id", "Type", cmxObservations.Eventid);
            return View(cmxObservations);
        }

        // GET: CmxObservations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmxObservations = await _context.CmxObservations
                .Include(c => c.Event)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cmxObservations == null)
            {
                return NotFound();
            }

            return View(cmxObservations);
        }

        // POST: CmxObservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var cmxObservations = await _context.CmxObservations.SingleOrDefaultAsync(m => m.Id == id);
            _context.CmxObservations.Remove(cmxObservations);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> report(int months,int years)
        {

            List<int> Month = new List<int>();
            List<int> Year = new List<int>();



            var result = _context.CmxObservations  //.Take(10000)
                .Where(x => x.Seentime.Year == years && x.Seentime.Month == months )
                .GroupBy(x => x.Seentime.Hour)  
                
                .OrderBy(x => x.Key)    
                .Select(x => new Report(x.Count(), x.Key));
           
            for (int i = 1; i <= 12; i++)
            {
                Month.Add(i);
            }
            var minyear = _context.CmxObservations.Min(i => i.Seentime.Year);
            var maxyear = _context.CmxObservations.Max(i => i.Seentime.Year);

            for (int j = minyear; j <= maxyear; j++)
            {
                Year.Add(j);
            }


            ViewBag.monthss = new SelectList(Month);
            ViewBag.yearss = new SelectList(Year);


            return View(await result .ToListAsync());
        }
        private bool CmxObservationsExists(long id)
        {
            return _context.CmxObservations.Any(e => e.Id == id);
        }
    }
}
