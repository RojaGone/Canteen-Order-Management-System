using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using canteen_management_system.Models;

namespace MVCcore.Controllers
{
    public class FeedbackMastersController : Controller
    {
        private readonly canteen_manege_systemContext _context;

        public FeedbackMastersController(canteen_manege_systemContext context)
        {
            _context = context;
        }

        // GET: FeedbackMasters
        public async Task<IActionResult> Index()
        {
            var canteen_manege_systemContext = _context.FeedbackMaster.Include(f => f.User);
            return View(await canteen_manege_systemContext.ToListAsync());
        }

        // GET: FeedbackMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackMaster = await _context.FeedbackMaster
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (feedbackMaster == null)
            {
                return NotFound();
            }

            return View(feedbackMaster);
        }

        // GET: FeedbackMasters/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.UserMaster, "UserId", "FirstName");
            return View();
        }

        // POST: FeedbackMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackId,UserId,Feedback,CreateDatetime,UpdateDatetime,IsActive,IsDelete")] FeedbackMaster feedbackMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedbackMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.UserMaster, "UserId", "FirstName", feedbackMaster.UserId);
            return View(feedbackMaster);
        }

        // GET: FeedbackMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackMaster = await _context.FeedbackMaster.FindAsync(id);
            if (feedbackMaster == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.UserMaster, "UserId", "FirstName", feedbackMaster.UserId);
            return View(feedbackMaster);
        }

        // POST: FeedbackMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackId,UserId,Feedback,CreateDatetime,UpdateDatetime,IsActive,IsDelete")] FeedbackMaster feedbackMaster)
        {
            if (id != feedbackMaster.FeedbackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedbackMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackMasterExists(feedbackMaster.FeedbackId))
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
            ViewData["UserId"] = new SelectList(_context.UserMaster, "UserId", "FirstName", feedbackMaster.UserId);
            return View(feedbackMaster);
        }

        // GET: FeedbackMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackMaster = await _context.FeedbackMaster
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (feedbackMaster == null)
            {
                return NotFound();
            }

            return View(feedbackMaster);
        }

        // POST: FeedbackMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedbackMaster = await _context.FeedbackMaster.FindAsync(id);
            _context.FeedbackMaster.Remove(feedbackMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackMasterExists(int id)
        {
            return _context.FeedbackMaster.Any(e => e.FeedbackId == id);
        }
    }
}
