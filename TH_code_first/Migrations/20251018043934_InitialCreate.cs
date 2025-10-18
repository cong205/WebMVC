using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH_code_first.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ndcLoai_San_Phams",
                columns: table => new
                {
                    ndcID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ndcMaLoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ndcTenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ndcTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ndcLoai_San_Phams", x => x.ndcID);
                });

            migrationBuilder.CreateTable(
                name: "ndcSan_Phams",
                columns: table => new
                {
                    ndcID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ndcMaSanPham = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ndcTenSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ndcHinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ndcSoLuong = table.Column<int>(type: "int", nullable: false),
                    ndcDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ndcMaLoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ndcTrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ndcLoaiSanPhamID = table.Column<int>(type: "int", nullable: false),
                    ndcLoai_San_PhamndcID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ndcSan_Phams", x => x.ndcID);
                    table.ForeignKey(
                        name: "FK_ndcSan_Phams_ndcLoai_San_Phams_ndcLoai_San_PhamndcID",
                        column: x => x.ndcLoai_San_PhamndcID,
                        principalTable: "ndcLoai_San_Phams",
                        principalColumn: "ndcID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ndcSan_Phams_ndcLoai_San_PhamndcID",
                table: "ndcSan_Phams",
                column: "ndcLoai_San_PhamndcID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ndcSan_Phams");

            migrationBuilder.DropTable(
                name: "ndcLoai_San_Phams");
        }
    }
}
