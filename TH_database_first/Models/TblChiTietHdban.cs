using System;
using System.Collections.Generic;

namespace TH_database_first.Models;

public partial class TblChiTietHdban
{
    public string MaHdban { get; set; } = null!;

    public string MaHang { get; set; } = null!;

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public double? GiamGia { get; set; }

    public virtual TblHang MaHangNavigation { get; set; } = null!;

    public virtual TblHdban MaHdbanNavigation { get; set; } = null!;
}
