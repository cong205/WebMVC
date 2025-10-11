using System;
using System.Collections.Generic;

namespace TH_database_first.Models;

public partial class TblChatlieu
{
    public string MaChatlieu { get; set; } = null!;

    public string TenChatlieu { get; set; } = null!;

    public virtual ICollection<TblHang> TblHangs { get; set; } = new List<TblHang>();
}
