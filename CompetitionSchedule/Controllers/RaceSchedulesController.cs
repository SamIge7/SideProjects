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
    public class RaceSchedulesController : Controller
    {
        private readonly RaceScheduleContext _context;

        public RaceSchedulesController(RaceScheduleContext context)
        {
            _context = context;
        }

        // GET: RaceSchedules
        public async Task<IActionResult> Index()
        {
            return View(await _context.RaceSchedules.ToListAsync());
        }

        // GET: RaceSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceSchedule = await _context.RaceSchedules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceSchedule == null)
            {
                return NotFound();
            }

            return View(raceSchedule);
        }

        // GET: RaceSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RaceSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventName,CompetitionDistances,CompetitionDate,Location")] RaceSchedule raceSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raceSchedule);
        }

        // GET: RaceSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceSchedule = await _context.RaceSchedules.FindAsync(id);
            if (raceSchedule == null)
            {
                return NotFound();
            }
            return View(raceSchedule);
        }

        // POST: RaceSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventName,CompetitionDistances,CompetitionDate,Location")] RaceSchedule raceSchedule)
        {
            if (id != raceSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceScheduleExists(raceSchedule.Id))
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
            return View(raceSchedule);
        }

        // GET: RaceSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceSchedule = await _context.RaceSchedules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceSchedule == null)
            {
                return NotFound();
            }

            return View(raceSchedule);
        }

        // POST: RaceSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceSchedule = await _context.RaceSchedules.FindAsync(id);
            _context.RaceSchedules.Remove(raceSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceScheduleExists(int id)
        {
            return _context.RaceSchedules.Any(e => e.Id == id);
        }
    }
}
