using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMvcDepartman.Migrations
{
    /// <inheritdoc />
    public partial class deneme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminler",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kullanici = table.Column<string>(type: "Varchar(20)", nullable: true),
                    Sifre = table.Column<string>(type: "Varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminler", x => x.AdminID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminler");
        }
    }
}
