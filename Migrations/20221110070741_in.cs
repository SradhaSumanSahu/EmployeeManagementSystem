using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Register",
                table: "Register");

            migrationBuilder.RenameTable(
                name: "Register",
                newName: "registers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_registers",
                table: "registers",
                column: "UserID");

            migrationBuilder.CreateTable(
                name: "Signup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstame = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signup", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Signup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_registers",
                table: "registers");

            migrationBuilder.RenameTable(
                name: "registers",
                newName: "Register");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Register",
                table: "Register",
                column: "UserID");
        }
    }
}
