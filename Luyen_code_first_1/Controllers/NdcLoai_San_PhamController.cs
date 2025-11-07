using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Luyen_code_first_1.Models;

namespace Luyen_code_first_1.Controllers
{
    public class NdcLoai_San_PhamController : Controller
    {
        private readonly LuyencodefirstContext _context;

        public NdcLoai_San_PhamController(LuyencodefirstContext context)
        {
            _context = context;
        }

        // GET: NdcLoai_San_Pham
        public async Task<IActionResult> Index()
        {
            return View("ndcIndex", await _context.ndcLoai_San_Phams.ToListAsync());
        }

        // GET: NdcLoai_San_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcLoai_San_Pham = await _context.ndcLoai_San_Phams
                .FirstOrDefaultAsync(m => m.ndcId == id);
            if (ndcLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View("ndcDetails", ndcLoai_San_Pham);
        }

        // GET: NdcLoai_San_Pham/Create
        public IActionResult Create()
        {
            return View("ndcCreate");
        }

        // POST: NdcLoai_San_Pham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ndcId,ndcMaLoai,ndcTenLoai,ndcTrangThai")] NdcLoai_San_Pham ndcLoai_San_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ndcLoai_San_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("ndcCreate", ndcLoai_San_Pham);
        }

        // GET: NdcLoai_San_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcLoai_San_Pham = await _context.ndcLoai_San_Phams.FindAsync(id);
            if (ndcLoai_San_Pham == null)
            {
                return NotFound();
            }
            return View("ndcEdit", ndcLoai_San_Pham);
        }

        // POST: NdcLoai_San_Pham/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ndcId,ndcMaLoai,ndcTenLoai,ndcTrangThai")] NdcLoai_San_Pham ndcLoai_San_Pham)
        {
            if (id != ndcLoai_San_Pham.ndcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ndcLoai_San_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NdcLoai_San_PhamExists(ndcLoai_San_Pham.ndcId))
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
            return View("ndcEdit", ndcLoai_San_Pham);
        }

        // GET: NdcLoai_San_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcLoai_San_Pham = await _context.ndcLoai_San_Phams
                .FirstOrDefaultAsync(m => m.ndcId == id);
            if (ndcLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View("ndcDelete", ndcLoai_San_Pham);
        }

        // POST: NdcLoai_San_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ndcLoai_San_Pham = await _context.ndcLoai_San_Phams.FindAsync(id);
            if (ndcLoai_San_Pham != null)
            {
                _context.ndcLoai_San_Phams.Remove(ndcLoai_San_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NdcLoai_San_PhamExists(long id)
        {
            return _context.ndcLoai_San_Phams.Any(e => e.ndcId == id);
        }
    }
}
