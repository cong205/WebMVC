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
    public class NdcSan_PhamController : Controller
    {
        private readonly LuyencodefirstContext _context;

        public NdcSan_PhamController(LuyencodefirstContext context)
        {
            _context = context;
        }

        // GET: NdcSan_Pham
        public async Task<IActionResult> Index()
        {
            var luyencodefirstContext = _context.ndcSan_Phams.Include(n => n.ndcLoai_San_Pham);
            return View("ndcIndex", await luyencodefirstContext.ToListAsync());
        }

        // GET: NdcSan_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcSan_Pham = await _context.ndcSan_Phams
                .Include(n => n.ndcLoai_San_Pham)
                .FirstOrDefaultAsync(m => m.ndcId == id);
            if (ndcSan_Pham == null)
            {
                return NotFound();
            }

            return View("ndcDetails", ndcSan_Pham);
        }

        // GET: NdcSan_Pham/Create
        public IActionResult Create()
        {
            ViewData["ndcMaLoai"] = new SelectList(_context.ndcLoai_San_Phams, "ndcId", "ndcTenLoai");
            return View("ndcCreate");
        }

        // POST: NdcSan_Pham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ndcId,ndcMaSanPham,ndcTenSanPham,ndcHinhAnh,ndcSoLuong,ndcDonGia,ndcMaLoai,ndcTrangThai")] NdcSan_Pham ndcSan_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ndcSan_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ndcMaLoai"] = new SelectList(_context.ndcLoai_San_Phams, "ndcId", "ndcTenLoai", ndcSan_Pham.ndcMaLoai);
            return View("ndcCreate", ndcSan_Pham);
        }

        // GET: NdcSan_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcSan_Pham = await _context.ndcSan_Phams.FindAsync(id);
            if (ndcSan_Pham == null)
            {
                return NotFound();
            }
            ViewData["ndcMaLoai"] = new SelectList(_context.ndcLoai_San_Phams, "ndcId", "ndcTenLoai", ndcSan_Pham.ndcMaLoai);
            return View("ndcEdit", ndcSan_Pham);
        }

        // POST: NdcSan_Pham/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ndcId,ndcMaSanPham,ndcTenSanPham,ndcHinhAnh,ndcSoLuong,ndcDonGia,ndcMaLoai,ndcTrangThai")] NdcSan_Pham ndcSan_Pham)
        {
            if (id != ndcSan_Pham.ndcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ndcSan_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NdcSan_PhamExists(ndcSan_Pham.ndcId))
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
            ViewData["ndcMaLoai"] = new SelectList(_context.ndcLoai_San_Phams, "ndcId", "ndcTenLoai", ndcSan_Pham.ndcMaLoai);
            return View("ndcEdit", ndcSan_Pham);
        }

        // GET: NdcSan_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcSan_Pham = await _context.ndcSan_Phams
                .Include(n => n.ndcLoai_San_Pham)
                .FirstOrDefaultAsync(m => m.ndcId == id);
            if (ndcSan_Pham == null)
            {
                return NotFound();
            }

            return View("ndcDelete", ndcSan_Pham);
        }

        // POST: NdcSan_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ndcSan_Pham = await _context.ndcSan_Phams.FindAsync(id);
            if (ndcSan_Pham != null)
            {
                _context.ndcSan_Phams.Remove(ndcSan_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NdcSan_PhamExists(long id)
        {
            return _context.ndcSan_Phams.Any(e => e.ndcId == id);
        }
    }
}
