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
    public class BookingDetailsController : Controller
    {
        private readonly ORGContext _context;

        public BookingDetailsController(ORGContext context)
        {
            _context = context;
        }

        // GET: BookingDetails
        public async Task<IActionResult> Index()
        {
            var oRGContext = _context.BookingDetails.Include(b => b.CareGiver).Include(b => b.Patient);
            return View(await oRGContext.ToListAsync());
        }

        // GET: BookingDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingDetail = await _context.BookingDetails
                .Include(b => b.CareGiver)
                .Include(b => b.Patient)
                .FirstOrDefaultAsync(m => m.BookingReferenceId == id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            return View(bookingDetail);
        }

        // GET: BookingDetails/Create
        public IActionResult Create()
        {
            ViewData["CareGiverId"] = new SelectList(_context.CareGivers, "Cid", "Cid");
            ViewData["PatientId"] = new SelectList(_context.PatientDetails, "Pid", "Pid");
            return View();
        }

        // POST: BookingDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingReferenceId,PatientId,CareGiverId,BookingDate,BookingTime,Address,ServicesReq,TotalCharges")] BookingDetail bookingDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CareGiverId"] = new SelectList(_context.CareGivers, "Cid", "Cid", bookingDetail.CareGiverId);
            ViewData["PatientId"] = new SelectList(_context.PatientDetails, "Pid", "Pid", bookingDetail.PatientId);
            return View(bookingDetail);
        }

        // GET: BookingDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingDetail = await _context.BookingDetails.FindAsync(id);
            if (bookingDetail == null)
            {
                return NotFound();
            }
            ViewData["CareGiverId"] = new SelectList(_context.CareGivers, "Cid", "Cid", bookingDetail.CareGiverId);
            ViewData["PatientId"] = new SelectList(_context.PatientDetails, "Pid", "Pid", bookingDetail.PatientId);
            return View(bookingDetail);
        }

        // POST: BookingDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BookingReferenceId,PatientId,CareGiverId,BookingDate,BookingTime,Address,ServicesReq,TotalCharges")] BookingDetail bookingDetail)
        {
            if (id != bookingDetail.BookingReferenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingDetailExists(bookingDetail.BookingReferenceId))
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
            ViewData["CareGiverId"] = new SelectList(_context.CareGivers, "Cid", "Cid", bookingDetail.CareGiverId);
            ViewData["PatientId"] = new SelectList(_context.PatientDetails, "Pid", "Pid", bookingDetail.PatientId);
            return View(bookingDetail);
        }

        // GET: BookingDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingDetail = await _context.BookingDetails
                .Include(b => b.CareGiver)
                .Include(b => b.Patient)
                .FirstOrDefaultAsync(m => m.BookingReferenceId == id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            return View(bookingDetail);
        }

        // POST: BookingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bookingDetail = await _context.BookingDetails.FindAsync(id);
            _context.BookingDetails.Remove(bookingDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingDetailExists(string id)
        {
            return _context.BookingDetails.Any(e => e.BookingReferenceId == id);
        }
    }
}
