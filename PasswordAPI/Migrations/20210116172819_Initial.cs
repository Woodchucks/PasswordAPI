using Microsoft.EntityFrameworkCore.Migrations;

namespace PasswordAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordsDetails",
                columns: table => new
                {
                    PasswordDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordOwnerName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PasswordOwnersPhoneNr = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordsDetails", x => x.PasswordDetailsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordsDetails");
        }
    }
}
