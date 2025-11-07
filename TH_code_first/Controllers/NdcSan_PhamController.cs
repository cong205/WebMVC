using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TH_code_first.Models;

namespace TH_code_first.Controllers
{
    public class NdcSan_PhamController : Controller
    {
        private readonly TH_code_firstContext _context;

        public NdcSan_PhamController(TH_code_firstContext context)
        {
            _context = context;
        }

        // GET: NdcSan_Pham
        public async Task<IActionResult> ndcIndex()
        {
            return View(await _context.ndcSan_Phams.ToListAsync());
        }

        // GET: NdcSan_Pham/Details/5
        public async Task<IActionResult> ndcDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcSan_Pham = await _context.ndcSan_Phams
                .FirstOrDefaultAsync(m => m.ndcID == id);
            if (ndcSan_Pham == null)
            {
                return NotFound();
            }

            return View(ndcSan_Pham);
        }

        // GET: NdcSan_Pham/Create
        public IActionResult ndcCreate()
        {
            ViewBag.ndcLoaiSanPhamList = new SelectList(_context.ndcLoai_San_Phams, "ndcID", "ndcTenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ndcCreate([Bind("ndcID,ndcMaSanPham,ndcTenSanPham,ndcHinhAnh,ndcSoLuong,ndcDonGia,ndcTrangThai,ndcLoaiSanPhamID")] NdcSan_Pham ndcSan_Pham)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage);
                Console.WriteLine(string.Join(" | ", errors)); // hoặc xem trong Output
            }
            
            if (ModelState.IsValid)
            {
                var loai = _context.ndcLoai_San_Phams
                   .FirstOrDefault(l => l.ndcID == ndcSan_Pham.ndcMaLoai);

                _context.Add(ndcSan_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ndcIndex));

            }

            ViewBag.ndcLoaiSanPhamList = new SelectList(_context.ndcLoai_San_Phams, "ndcID", "ndcTenLoai");
            return View(ndcSan_Pham);
        }


        // GET: NdcSan_Pham/Edit/5
        public async Task<IActionResult> ndcEdit(int? id)
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
            return View(ndcSan_Pham);
        }

        // POST: NdcSan_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ndcEdit(int id, [Bind("ndcID,ndcMaSanPham,ndcTenSanPham,ndcHinhAnh,ndcSoLuong,ndcDonGia,ndcMaLoai,ndcTrangThai,ndcLoaiSanPhamID")] NdcSan_Pham ndcSan_Pham)
        {
            if (id != ndcSan_Pham.ndcID)
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
                    if (!NdcSan_PhamExists(ndcSan_Pham.ndcID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ndcIndex));
            }
            return View(ndcSan_Pham);
        }

        // GET: NdcSan_Pham/Delete/5
        public async Task<IActionResult> ndcDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ndcSan_Pham = await _context.ndcSan_Phams
                .FirstOrDefaultAsync(m => m.ndcID == id);
            if (ndcSan_Pham == null)
            {
                return NotFound();
            }

            return View(ndcSan_Pham);
        }

        // POST: NdcSan_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ndcSan_Pham = await _context.ndcSan_Phams.FindAsync(id);
            if (ndcSan_Pham != null)
            {
                _context.ndcSan_Phams.Remove(ndcSan_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ndcIndex));
        }

        private bool NdcSan_PhamExists(int id)
        {
            return _context.ndcSan_Phams.Any(e => e.ndcID == id);
        }
    }
}
