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
    public class VerificationStatesController : Controller
    {
        private readonly ORGContext _context;

        public VerificationStatesController(ORGContext context)
        {
            _context = context;
        }

        // GET: VerificationStates
        public async Task<IActionResult> Index()
        {
            return View(await _context.VerificationStates.ToListAsync());
        }

        // GET: VerificationStates/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verificationState = await _context.VerificationStates
                .FirstOrDefaultAsync(m => m.VerificationId == id);
            if (verificationState == null)
            {
                return NotFound();
            }

            return View(verificationState);
        }

        // GET: VerificationStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VerificationStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VerificationId,State")] VerificationState verificationState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verificationState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verificationState);
        }

        // GET: VerificationStates/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verificationState = await _context.VerificationStates.FindAsync(id);
            if (verificationState == null)
            {
                return NotFound();
            }
            return View(verificationState);
        }

        // POST: VerificationStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VerificationId,State")] VerificationState verificationState)
        {
            if (id != verificationState.VerificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verificationState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerificationStateExists(verificationState.VerificationId))
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
            return View(verificationState);
        }

        // GET: VerificationStates/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verificationState = await _context.VerificationStates
                .FirstOrDefaultAsync(m => m.VerificationId == id);
            if (verificationState == null)
            {
                return NotFound();
            }

            return View(verificationState);
        }

        // POST: VerificationStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var verificationState = await _context.VerificationStates.FindAsync(id);
            _context.VerificationStates.Remove(verificationState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VerificationStateExists(string id)
        {
            return _context.VerificationStates.Any(e => e.VerificationId == id);
        }
    }
}
