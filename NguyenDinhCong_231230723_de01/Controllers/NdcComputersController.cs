using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ndc_231230723_de01.Models;

namespace ndc_231230723_de01.Controllers
{
    public class NdcComputersController : Controller
    {
        private readonly NdcComputerContext _context;

        public NdcComputersController(NdcComputerContext context)
        {
            _context = context;
        }

        // GET: NdcComputers
        public async Task<IActionResult> NdcIndex()
        {
            return View("NdcIndex",await _context.NdcComputers.ToListAsync());
        }

        // GET: NdcComputers/Details/5
        public async Task<IActionResult> NdcDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcComputer = await _context.NdcComputers
                .FirstOrDefaultAsync(m => m.ndcComId == id);
            if (ndcComputer == null)
            {
                return NotFound();
            }

            return View("NdcDetails", ndcComputer);
        }

        // GET: NdcComputers/Create
        public IActionResult NdcCreate()
        {
            return View("NdcCreate");
        }

        // POST: NdcComputers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NdcCreate([Bind("ndcComId,ndcComName,ndcComPrice,ndcComImage,ndcComStatus")] NdcComputer ndcComputer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ndcComputer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NdcIndex));
            }
            return View("NdcCreate", ndcComputer);
        }

        // GET: NdcComputers/Edit/5
        public async Task<IActionResult> NdcEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcComputer = await _context.NdcComputers.FindAsync(id);
            if (ndcComputer == null)
            {
                return NotFound();
            }
            return View("NdcEdit", ndcComputer);
        }

        // POST: NdcComputers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NdcEdit(int id, [Bind("ndcComId,ndcComName,ndcComPrice,ndcComImage,ndcComStatus")] NdcComputer ndcComputer)
        {
            if (id != ndcComputer.ndcComId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ndcComputer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NdcComputerExists(ndcComputer.ndcComId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NdcIndex));
            }
            return View("NdcEdit", ndcComputer);
        }

        // GET: NdcComputers/Delete/5
        public async Task<IActionResult> NdcDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcComputer = await _context.NdcComputers
                .FirstOrDefaultAsync(m => m.ndcComId == id);
            if (ndcComputer == null)
            {
                return NotFound();
            }

            return View("NdcDelete", ndcComputer);
        }

        // POST: NdcComputers/Delete/5
        [HttpPost, ActionName("NdcDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NdcDeleteConfirmed(int id)
        {
            var ndcComputer = await _context.NdcComputers.FindAsync(id);
            if (ndcComputer != null)
            {
                _context.NdcComputers.Remove(ndcComputer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NdcIndex));
        }

        private bool NdcComputerExists(int id)
        {
            return _context.NdcComputers.Any(e => e.ndcComId == id);
        }
    }
}
