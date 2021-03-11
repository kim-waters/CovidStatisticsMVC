using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCovidStatistics.Data;
using MvcCovidStatistics.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Microsoft.AspNetCore.Authorization;

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
		public async Task<IActionResult> Index(string sortOrder)
		{
			ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
			ViewBag.VacSortParm = sortOrder == "vaccinated_desc" ? "vaccinated" : "vaccinated_desc";
			ViewBag.DeathSortParm = sortOrder == "deaths_desc" ? "deaths" : "deaths_desc";
			ViewBag.RecoverySortParm = sortOrder == "recovery_desc" ? "recovery" : "recovery_desc";
			ViewBag.CasesSortParm = sortOrder == "cases_desc" ? "cases" : "cases_desc";

			var dayRecord = from d in _context.DayRecords
							select d;

			dayRecord = sortOrder switch
			{
				"date_desc" => dayRecord.OrderByDescending(d => d.Date),
				"vaccinated" => dayRecord.OrderBy(d => d.NumVaccinated),
				"vaccinated_desc" => dayRecord.OrderByDescending(d => d.NumVaccinated),
				"deaths" => dayRecord.OrderBy(d => d.NumDeaths),
				"deaths_desc" => dayRecord.OrderByDescending(d => d.NumDeaths),
				"recovery" => dayRecord.OrderBy(d => d.NumRecovered),
				"recovery_desc" => dayRecord.OrderByDescending(d => d.NumRecovered),
				"cases" => dayRecord.OrderBy(d => d.NewCases),
				"cases_desc" => dayRecord.OrderByDescending(d => d.NewCases),
				_ => dayRecord.OrderBy(d => d.Date),
			};
			return View(await dayRecord.ToListAsync());
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
		[Authorize]
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
		[Authorize]
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
		[Authorize]
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
		[Authorize]
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
		[Authorize]
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

