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
    public class PatientDetailsController : Controller
    {
        private readonly ORGContext _context;

        public PatientDetailsController(ORGContext context)
        {
            _context = context;
        }

        // GET: PatientDetails
        public async Task<IActionResult> Index()
        {
            var oRGContext = _context.PatientDetails.Include(p => p.SelectedCgNavigation);
            return View(await oRGContext.ToListAsync());
        }

        // GET: PatientDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetail = await _context.PatientDetails
                .Include(p => p.SelectedCgNavigation)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (patientDetail == null)
            {
                return NotFound();
            }

            return View(patientDetail);
        }

        // GET: PatientDetails/Create
        public IActionResult Create()
        {
            ViewData["SelectedCg"] = new SelectList(_context.CareGivers, "Cid", "Cid");
            return View();
        }

        // POST: PatientDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pid,Fname,Mname,Lname,PAddress,TAddress,SelectedCg")] PatientDetail patientDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SelectedCg"] = new SelectList(_context.CareGivers, "Cid", "Cid", patientDetail.SelectedCg);
            return View(patientDetail);
        }

        // GET: PatientDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetail = await _context.PatientDetails.FindAsync(id);
            if (patientDetail == null)
            {
                return NotFound();
            }
            ViewData["SelectedCg"] = new SelectList(_context.CareGivers, "Cid", "Cid", patientDetail.SelectedCg);
            return View(patientDetail);
        }

        // POST: PatientDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Pid,Fname,Mname,Lname,PAddress,TAddress,SelectedCg")] PatientDetail patientDetail)
        {
            if (id != patientDetail.Pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientDetailExists(patientDetail.Pid))
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
            ViewData["SelectedCg"] = new SelectList(_context.CareGivers, "Cid", "Cid", patientDetail.SelectedCg);
            return View(patientDetail);
        }

        // GET: PatientDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetail = await _context.PatientDetails
                .Include(p => p.SelectedCgNavigation)
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (patientDetail == null)
            {
                return NotFound();
            }

            return View(patientDetail);
        }

        // POST: PatientDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var patientDetail = await _context.PatientDetails.FindAsync(id);
            _context.PatientDetails.Remove(patientDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientDetailExists(string id)
        {
            return _context.PatientDetails.Any(e => e.Pid == id);
        }
    }
}
