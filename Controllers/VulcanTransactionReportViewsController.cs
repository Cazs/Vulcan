using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vulcan.DAL;
using Vulcan.Models;

namespace Vulcan.Controllers
{
    public class VulcanTransactionReportViewsController : Controller
    {
        private readonly VulcanTransactionReportViewContext _context;

        public VulcanTransactionReportViewsController(VulcanTransactionReportViewContext context)
        {
            _context = context;
        }

        // GET: VulcanTransactionReportViews
        public async Task<IActionResult> Index()
        {
            ViewData["TransactionReportViews"] = _context.VulcanTransactionReportView != null ?
                          View(await _context.VulcanTransactionReportView.ToListAsync()) :
                          Problem("Entity set 'VulcanTransactionReportViewContext.VulcanTransactionReportView'  is null.");
            return View();
        }

        // GET: VulcanTransactionReportViews/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.VulcanTransactionReportView == null)
            {
                return NotFound();
            }

            var vulcanTransactionReportView = await _context.VulcanTransactionReportView
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vulcanTransactionReportView == null)
            {
                return NotFound();
            }

            return View(vulcanTransactionReportView);
        }

        // GET: VulcanTransactionReportViews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VulcanTransactionReportViews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BranchCode,AccountType,Status,TotalCount,TotalAmount")] VulcanTransactionReportView vulcanTransactionReportView)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vulcanTransactionReportView);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vulcanTransactionReportView);
        }

        // GET: VulcanTransactionReportViews/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.VulcanTransactionReportView == null)
            {
                return NotFound();
            }

            var vulcanTransactionReportView = await _context.VulcanTransactionReportView.FindAsync(id);
            if (vulcanTransactionReportView == null)
            {
                return NotFound();
            }
            return View(vulcanTransactionReportView);
        }

        // POST: VulcanTransactionReportViews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,BranchCode,AccountType,Status,TotalCount,TotalAmount")] VulcanTransactionReportView vulcanTransactionReportView)
        {
            if (id != vulcanTransactionReportView.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vulcanTransactionReportView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VulcanTransactionReportViewExists(vulcanTransactionReportView.Id))
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
            return View(vulcanTransactionReportView);
        }

        // GET: VulcanTransactionReportViews/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.VulcanTransactionReportView == null)
            {
                return NotFound();
            }

            var vulcanTransactionReportView = await _context.VulcanTransactionReportView
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vulcanTransactionReportView == null)
            {
                return NotFound();
            }

            return View(vulcanTransactionReportView);
        }

        // POST: VulcanTransactionReportViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.VulcanTransactionReportView == null)
            {
                return Problem("Entity set 'VulcanTransactionReportViewContext.VulcanTransactionReportView'  is null.");
            }
            var vulcanTransactionReportView = await _context.VulcanTransactionReportView.FindAsync(id);
            if (vulcanTransactionReportView != null)
            {
                _context.VulcanTransactionReportView.Remove(vulcanTransactionReportView);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VulcanTransactionReportViewExists(long id)
        {
          return (_context.VulcanTransactionReportView?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
