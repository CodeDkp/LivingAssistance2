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
    public class CareGiversController : Controller
    {
        private readonly ORGContext _context;

        public CareGiversController(ORGContext context)
        {
            _context = context;
        }

        // GET: CareGivers
        public async Task<IActionResult> Index()
        {
            var oRGContext = _context.CareGivers.Include(c => c.VfstatusNavigation);
            return View(await oRGContext.ToListAsync());
        }

        // GET: CareGivers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careGiver = await _context.CareGivers
                .Include(c => c.VfstatusNavigation)
                .FirstOrDefaultAsync(m => m.Cid == id);
            if (careGiver == null)
            {
                return NotFound();
            }

            return View(careGiver);
        }

        // GET: CareGivers/Create
        public IActionResult Create()
        {
            ViewData["Vfstatus"] = new SelectList(_context.VerificationStates, "VerificationId", "VerificationId");
            return View();
        }

        // POST: CareGivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cid,Fname,Mname,Lname,Uid,IsIndividual,Address,Vfstatus,Experiance")] CareGiver careGiver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careGiver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Vfstatus"] = new SelectList(_context.VerificationStates, "VerificationId", "VerificationId", careGiver.Vfstatus);
            return View(careGiver);
        }

        // GET: CareGivers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careGiver = await _context.CareGivers.FindAsync(id);
            if (careGiver == null)
            {
                return NotFound();
            }
            ViewData["Vfstatus"] = new SelectList(_context.VerificationStates, "VerificationId", "VerificationId", careGiver.Vfstatus);
            return View(careGiver);
        }

        // POST: CareGivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cid,Fname,Mname,Lname,Uid,IsIndividual,Address,Vfstatus,Experiance")] CareGiver careGiver)
        {
            if (id != careGiver.Cid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careGiver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareGiverExists(careGiver.Cid))
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
            ViewData["Vfstatus"] = new SelectList(_context.VerificationStates, "VerificationId", "VerificationId", careGiver.Vfstatus);
            return View(careGiver);
        }

        // GET: CareGivers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careGiver = await _context.CareGivers
                .Include(c => c.VfstatusNavigation)
                .FirstOrDefaultAsync(m => m.Cid == id);
            if (careGiver == null)
            {
                return NotFound();
            }

            return View(careGiver);
        }

        // POST: CareGivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var careGiver = await _context.CareGivers.FindAsync(id);
            _context.CareGivers.Remove(careGiver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareGiverExists(string id)
        {
            return _context.CareGivers.Any(e => e.Cid == id);
        }
    }
}
