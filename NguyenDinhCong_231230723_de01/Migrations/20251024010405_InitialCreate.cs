using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ndc_231230723_de01.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NdcComputer",
                columns: table => new
                {
                    ndcComId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ndcComName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ndcComPrice = table.Column<long>(type: "bigint", maxLength: 30, nullable: false),
                    ndcComImage = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ndcComStatus = table.Column<bool>(type: "bit", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NdcComputer", x => x.ndcComId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NdcComputer");
        }
    }
}
