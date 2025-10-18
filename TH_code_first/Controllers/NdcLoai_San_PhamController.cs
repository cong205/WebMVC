using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TH_code_first.Models;

namespace TH_code_first.Controllers
{
    public class NdcLoai_San_PhamController : Controller
    {
        private readonly TH_code_firstContext _context;

        public NdcLoai_San_PhamController(TH_code_firstContext context)
        {
            _context = context;
        }

        // ==================== INDEX ====================
        public async Task<IActionResult> ndcIndex()
        {
            var dsLoai = await _context.ndcLoai_San_Phams.ToListAsync();
            return View("ndcIndex", dsLoai);
        }

        // ==================== DETAILS ====================
        [ActionName("ndcDetails")]
        public async Task<IActionResult> ndcDetails(int? id)
        {
            if (id == null)
                return NotFound();

            var loai = await _context.ndcLoai_San_Phams.FirstOrDefaultAsync(m => m.ndcID == id);
            if (loai == null)
                return NotFound();

            return View("ndcDetails", loai);
        }

        // ==================== CREATE ====================
        public IActionResult ndcCreate()
        {
            return View("ndcCreate");
        }

        [HttpPost, ActionName("ndcCreate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ndcCreateConfirmed([Bind("ndcID,ndcMaLoai,ndcTenLoai,ndcTrangThai")] NdcLoai_San_Pham loai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ndcIndex));
            }

            return View("ndcCreate", loai);
        }

        // ==================== EDIT ====================
        public async Task<IActionResult> ndcEdit(int? id)
        {
            if (id == null)
                return NotFound();

            var loai = await _context.ndcLoai_San_Phams.FindAsync(id);
            if (loai == null)
                return NotFound();

            return View("ndcEdit", loai);
        }

        [HttpPost,ActionName("ndcEdit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ndcEdit(int id, [Bind("ndcID,ndcMaLoai,ndcTenLoai,ndcTrangThai")] NdcLoai_San_Pham loai)
        {
            if (id != loai.ndcID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ndcLoai_San_Phams.Any(e => e.ndcID == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(ndcIndex));
            }
            return View("ndcEdit", loai);
        }

        // ==================== DELETE ====================
        public async Task<IActionResult> ndcDelete(int? id)
        {
            if (id == null)
                return NotFound();

            var loai = await _context.ndcLoai_San_Phams
                .FirstOrDefaultAsync(m => m.ndcID == id);

            if (loai == null)
                return NotFound();

            return View("ndcDelete", loai);
        }

        [HttpPost, ActionName("ndcDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ndcDelete(int id)
        {
            var loai = await _context.ndcLoai_San_Phams.FindAsync(id);
            if (loai != null)
            {
                _context.ndcLoai_San_Phams.Remove(loai);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ndcIndex));
        }
    }
}
