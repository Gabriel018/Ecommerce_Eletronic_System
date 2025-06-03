using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EletronicSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionacampoFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Produtos",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Produtos");
        }
    }
}
