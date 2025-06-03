using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EletronicSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovecampoFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Produtos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
