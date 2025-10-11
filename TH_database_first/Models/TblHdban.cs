using System;
using System.Collections.Generic;

namespace TH_database_first.Models;

public partial class TblHdban
{
    public string MaHdban { get; set; } = null!;

    public string MaNhanvien { get; set; } = null!;

    public DateOnly? NgayBan { get; set; }

    public string MaKhach { get; set; } = null!;

    public decimal? TongTien { get; set; }

    public virtual TblKhach MaKhachNavigation { get; set; } = null!;

    public virtual TblNhanvien MaNhanvienNavigation { get; set; } = null!;

    public virtual ICollection<TblChiTietHdban> TblChiTietHdbans { get; set; } = new List<TblChiTietHdban>();
}
