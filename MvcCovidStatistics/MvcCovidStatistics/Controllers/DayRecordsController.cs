using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCovidStatistics.Data;
using MvcCovidStatistics.Models;

using System.Data;

namespace MvcCovidStatistics.Controllers
{
    public class DayRecordsController : Controller
    {
        private readonly CovidDbContext _context;

        public DayRecordsController(CovidDbContext context)
        {
            _context = context;
        }


        // GET: DayRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.DayRecords.ToListAsync());
        }

        // GET: DayRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayRecord = await _context.DayRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayRecord == null)
            {
                return NotFound();
            }

            return View(dayRecord);
        }

        // GET: DayRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DayRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,NumVaccinated,NumDeaths,NumRecovered,NewCases")] DayRecord dayRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dayRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dayRecord);
        }

        // GET: DayRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayRecord = await _context.DayRecords.FindAsync(id);
            if (dayRecord == null)
            {
                return NotFound();
            }
            return View(dayRecord);
        }

        // POST: DayRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,NumVaccinated,NumDeaths,NumRecovered,NewCases")] DayRecord dayRecord)
        {
            if (id != dayRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dayRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DayRecordExists(dayRecord.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dayRecord);
        }

        // GET: DayRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayRecord = await _context.DayRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayRecord == null)
            {
                return NotFound();
            }

            return View(dayRecord);
        }

        // POST: DayRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dayRecord = await _context.DayRecords.FindAsync(id);
            _context.DayRecords.Remove(dayRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DayRecordExists(int id)
        {
            return _context.DayRecords.Any(e => e.Id == id);
        }
    }
}
