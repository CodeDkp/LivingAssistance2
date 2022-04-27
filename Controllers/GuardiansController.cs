#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LivingAssistance2.Models;

namespace LivingAssistance2.Controllers
{
    public class GuardiansController : Controller
    {
        private readonly ORGContext _context;

        public GuardiansController(ORGContext context)
        {
            _context = context;
        }

        // GET: Guardians
        public async Task<IActionResult> Index()
        {
            var oRGContext = _context.Guardians.Include(g => g.Patient);
            return View(await oRGContext.ToListAsync());
        }

        // GET: Guardians/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardian = await _context.Guardians
                .Include(g => g.Patient)
                .FirstOrDefaultAsync(m => m.Gid == id);
            if (guardian == null)
            {
                return NotFound();
            }

            return View(guardian);
        }

        // GET: Guardians/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.PatientDetails, "Pid", "Pid");
            return View();
        }

        // POST: Guardians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Gid,Fname,Mname,Lname,Address,PatientId,RelationWithPatient")] Guardian guardian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guardian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.PatientDetails, "Pid", "Pid", guardian.PatientId);
            return View(guardian);
        }

        // GET: Guardians/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardian = await _context.Guardians.FindAsync(id);
            if (guardian == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.PatientDetails, "Pid", "Pid", guardian.PatientId);
            return View(guardian);
        }

        // POST: Guardians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Gid,Fname,Mname,Lname,Address,PatientId,RelationWithPatient")] Guardian guardian)
        {
            if (id != guardian.Gid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guardian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuardianExists(guardian.Gid))
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
            ViewData["PatientId"] = new SelectList(_context.PatientDetails, "Pid", "Pid", guardian.PatientId);
            return View(guardian);
        }

        // GET: Guardians/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardian = await _context.Guardians
                .Include(g => g.Patient)
                .FirstOrDefaultAsync(m => m.Gid == id);
            if (guardian == null)
            {
                return NotFound();
            }

            return View(guardian);
        }

        // POST: Guardians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var guardian = await _context.Guardians.FindAsync(id);
            _context.Guardians.Remove(guardian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuardianExists(string id)
        {
            return _context.Guardians.Any(e => e.Gid == id);
        }
    }
}
