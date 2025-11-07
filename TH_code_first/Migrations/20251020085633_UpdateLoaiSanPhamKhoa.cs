using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH_code_first.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoaiSanPhamKhoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ndcSan_Phams_ndcLoai_San_Phams_ndcLoai_San_PhamndcID",
                table: "ndcSan_Phams");

            migrationBuilder.DropIndex(
                name: "IX_ndcSan_Phams_ndcLoai_San_PhamndcID",
                table: "ndcSan_Phams");

            migrationBuilder.DropColumn(
                name: "ndcLoaiSanPhamID",
                table: "ndcSan_Phams");

            migrationBuilder.DropColumn(
                name: "ndcLoai_San_PhamndcID",
                table: "ndcSan_Phams");

            migrationBuilder.AlterColumn<int>(
                name: "ndcMaLoai",
                table: "ndcSan_Phams",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_ndcSan_Phams_ndcMaLoai",
                table: "ndcSan_Phams",
                column: "ndcMaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_ndcSan_Phams_ndcLoai_San_Phams_ndcMaLoai",
                table: "ndcSan_Phams",
                column: "ndcMaLoai",
                principalTable: "ndcLoai_San_Phams",
                principalColumn: "ndcID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ndcSan_Phams_ndcLoai_San_Phams_ndcMaLoai",
                table: "ndcSan_Phams");

            migrationBuilder.DropIndex(
                name: "IX_ndcSan_Phams_ndcMaLoai",
                table: "ndcSan_Phams");

            migrationBuilder.AlterColumn<string>(
                name: "ndcMaLoai",
                table: "ndcSan_Phams",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ndcLoaiSanPhamID",
                table: "ndcSan_Phams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ndcLoai_San_PhamndcID",
                table: "ndcSan_Phams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ndcSan_Phams_ndcLoai_San_PhamndcID",
                table: "ndcSan_Phams",
                column: "ndcLoai_San_PhamndcID");

            migrationBuilder.AddForeignKey(
                name: "FK_ndcSan_Phams_ndcLoai_San_Phams_ndcLoai_San_PhamndcID",
                table: "ndcSan_Phams",
                column: "ndcLoai_San_PhamndcID",
                principalTable: "ndcLoai_San_Phams",
                principalColumn: "ndcID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
