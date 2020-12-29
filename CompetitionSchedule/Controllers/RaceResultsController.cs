using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompetitionSchedule.Data;
using CompetitionSchedule.Models;

namespace CompetitionSchedule.Controllers
{
    public class RaceResultsController : Controller
    {
        private readonly RaceResultContext _context;

        public RaceResultsController(RaceResultContext context)
        {
            _context = context;
        }

        // GET: RaceResults
        public async Task<IActionResult> Index()
        {
            return View(await _context.RaceResults.ToListAsync());
        }

        // GET: RaceResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceResult = await _context.RaceResults
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceResult == null)
            {
                return NotFound();
            }

            return View(raceResult);
        }

        // GET: RaceResults/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RaceResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventName,CompetitionDistance,CompetitionDate,Location,Time")] RaceResult raceResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raceResult);
        }

        // GET: RaceResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceResult = await _context.RaceResults.FindAsync(id);
            if (raceResult == null)
            {
                return NotFound();
            }
            return View(raceResult);
        }

        // POST: RaceResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventName,CompetitionDistance,CompetitionDate,Location,Time")] RaceResult raceResult)
        {
            if (id != raceResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceResultExists(raceResult.Id))
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
            return View(raceResult);
        }

        // GET: RaceResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceResult = await _context.RaceResults
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceResult == null)
            {
                return NotFound();
            }

            return View(raceResult);
        }

        // POST: RaceResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceResult = await _context.RaceResults.FindAsync(id);
            _context.RaceResults.Remove(raceResult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceResultExists(int id)
        {
            return _context.RaceResults.Any(e => e.Id == id);
        }
    }
}
