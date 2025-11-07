using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luyen_code_first_1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NdcLoai_San_Pham",
                columns: table => new
                {
                    nvcId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvcMaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ndcTenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ndcTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NdcLoai_San_Pham", x => x.nvcId);
                });

            migrationBuilder.CreateTable(
                name: "NdcSan_Pham",
                columns: table => new
                {
                    ndcId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ndcMaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ndcTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ndcHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ndcSoLuong = table.Column<int>(type: "int", nullable: false),
                    ndcDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ndcMaLoai = table.Column<long>(type: "bigint", nullable: false),
                    ndcTrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ndcLoai_San_PhamnvcId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NdcSan_Pham", x => x.ndcId);
                    table.ForeignKey(
                        name: "FK_NdcSan_Pham_NdcLoai_San_Pham_ndcLoai_San_PhamnvcId",
                        column: x => x.ndcLoai_San_PhamnvcId,
                        principalTable: "NdcLoai_San_Pham",
                        principalColumn: "nvcId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NdcSan_Pham_ndcLoai_San_PhamnvcId",
                table: "NdcSan_Pham",
                column: "ndcLoai_San_PhamnvcId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NdcSan_Pham");

            migrationBuilder.DropTable(
                name: "NdcLoai_San_Pham");
        }
    }
}
