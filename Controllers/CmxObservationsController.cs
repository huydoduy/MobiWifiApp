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
            var cmxContext = _context.CmxObservationsLite.Take(100);
            return View(await cmxContext.ToListAsync());
        }

        // GET: CmxObservations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmxObservations = await _context.CmxObservationsLite
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cmxObservations == null)
            {
                return NotFound();
            }

            return View(cmxObservations);
        }
      
      
        private bool CmxObservationsExists(long id)
        {
            return _context.CmxObservationsLite.Any(e => e.Id == id);
        }
    }
}
