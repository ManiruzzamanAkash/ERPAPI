using Microsoft.EntityFrameworkCore.Migrations;

namespace APIFuelStation.Migrations
{
    public partial class UserTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 15, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Avatar = table.Column<string>(maxLength: 250, nullable: false),
                    Gender = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
