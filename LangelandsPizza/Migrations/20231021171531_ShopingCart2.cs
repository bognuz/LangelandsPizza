using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LangelandsPizza.Migrations
{
    /// <inheritdoc />
    public partial class ShopingCart2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopingCartID",
                table: "ShopingCartItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopingCartID",
                table: "ShopingCartItem");
        }
    }
}
