using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luyen_code_first_1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NdcSan_Pham_NdcLoai_San_Pham_ndcLoai_San_PhamnvcId",
                table: "NdcSan_Pham");

            migrationBuilder.DropIndex(
                name: "IX_NdcSan_Pham_ndcLoai_San_PhamnvcId",
                table: "NdcSan_Pham");

            migrationBuilder.DropColumn(
                name: "ndcLoai_San_PhamnvcId",
                table: "NdcSan_Pham");

            migrationBuilder.RenameColumn(
                name: "nvcMaLoai",
                table: "NdcLoai_San_Pham",
                newName: "ndcMaLoai");

            migrationBuilder.RenameColumn(
                name: "nvcId",
                table: "NdcLoai_San_Pham",
                newName: "ndcId");

            migrationBuilder.CreateIndex(
                name: "IX_NdcSan_Pham_ndcMaLoai",
                table: "NdcSan_Pham",
                column: "ndcMaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_NdcSan_Pham_NdcLoai_San_Pham_ndcMaLoai",
                table: "NdcSan_Pham",
                column: "ndcMaLoai",
                principalTable: "NdcLoai_San_Pham",
                principalColumn: "ndcId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NdcSan_Pham_NdcLoai_San_Pham_ndcMaLoai",
                table: "NdcSan_Pham");

            migrationBuilder.DropIndex(
                name: "IX_NdcSan_Pham_ndcMaLoai",
                table: "NdcSan_Pham");

            migrationBuilder.RenameColumn(
                name: "ndcMaLoai",
                table: "NdcLoai_San_Pham",
                newName: "nvcMaLoai");

            migrationBuilder.RenameColumn(
                name: "ndcId",
                table: "NdcLoai_San_Pham",
                newName: "nvcId");

            migrationBuilder.AddColumn<long>(
                name: "ndcLoai_San_PhamnvcId",
                table: "NdcSan_Pham",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_NdcSan_Pham_ndcLoai_San_PhamnvcId",
                table: "NdcSan_Pham",
                column: "ndcLoai_San_PhamnvcId");

            migrationBuilder.AddForeignKey(
                name: "FK_NdcSan_Pham_NdcLoai_San_Pham_ndcLoai_San_PhamnvcId",
                table: "NdcSan_Pham",
                column: "ndcLoai_San_PhamnvcId",
                principalTable: "NdcLoai_San_Pham",
                principalColumn: "nvcId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
