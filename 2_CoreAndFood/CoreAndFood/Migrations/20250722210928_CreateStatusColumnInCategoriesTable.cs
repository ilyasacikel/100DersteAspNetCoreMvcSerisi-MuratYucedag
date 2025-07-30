using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAndFood.Migrations
{
    /// <inheritdoc />
    public partial class CreateStatusColumnInCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. NULL kayıtları önceden güvenli değerle değiştir
            migrationBuilder.Sql(@"UPDATE Categories
                                   SET CategoryName = LEFT(ISNULL(CategoryName, 'GeçiciKategori'), 20)
                                   WHERE CategoryName IS NULL OR LEN(CategoryName) > 20;
                                   ");

            // 2. Kolonu güncelle
            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "GeçiciKategori", // Daha anlamlı bir default
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            // 3. Yeni kolon ekle
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
