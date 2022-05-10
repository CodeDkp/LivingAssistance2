#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LivingAssistance2.Models;
using LivingAssistance2.Servicee;

namespace LivingAssistance2.Controllers
{
    public class UserDetailsController : Controller
    {
        private readonly ORGContext _context;
        private readonly IEmailService _emailService;

        public UserDetailsController(ORGContext context,IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: UserDetails
        public async Task<IActionResult> Index()
        {
            var oRGContext = _context.UserDetails.Include(u => u.UserType);
            return View(await oRGContext.ToListAsync());
        }

        // GET: UserDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = await _context.UserDetails
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(m => m.Username == id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return View(userDetail);
        }

        // GET: UserDetails/Create
        public IActionResult Create()
        {
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "UserTypeId", "UserTypeId");
            return View();
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fname,Mname,Lname,Username,Password,UserTypeId,Email")] UserDetail userDetail)
        {
            //Email
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmail = new List<string> { "tanya10sharma10@gmail.com" }
            };
            await _emailService.SendTestEmail(options);

            if (ModelState.IsValid)
            {
                _context.Add(userDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "UserTypeId", "UserTypeId", userDetail.UserTypeId);
            return View(userDetail);
        }

        // GET: UserDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = await _context.UserDetails.FindAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "UserTypeId", "UserTypeId", userDetail.UserTypeId);
            return View(userDetail);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Fname,Mname,Lname,Username,Password,UserTypeId,Email")] UserDetail userDetail)
        {
            if (id != userDetail.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDetailExists(userDetail.Username))
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
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "UserTypeId", "UserTypeId", userDetail.UserTypeId);
            return View(userDetail);
        }

        // GET: UserDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = await _context.UserDetails
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(m => m.Username == id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return View(userDetail);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userDetail = await _context.UserDetails.FindAsync(id);
            _context.UserDetails.Remove(userDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDetailExists(string id)
        {
            return _context.UserDetails.Any(e => e.Username == id);
        }
    }
}
