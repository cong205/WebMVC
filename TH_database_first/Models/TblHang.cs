using System;
using System.Collections.Generic;

namespace TH_database_first.Models;

public partial class TblHang
{
    public string MaHang { get; set; } = null!;

    public string TenHang { get; set; } = null!;

    public string MaChatlieu { get; set; } = null!;

    public int? SoLuong { get; set; }

    public decimal? DonGiaNhap { get; set; }

    public decimal? DonGiaBan { get; set; }

    public string? Anh { get; set; }

    public string? GhiChu { get; set; }

    public virtual TblChatlieu MaChatlieuNavigation { get; set; } = null!;

    public virtual ICollection<TblChiTietHdban> TblChiTietHdbans { get; set; } = new List<TblChiTietHdban>();
}
