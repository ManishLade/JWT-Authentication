using Microsoft.EntityFrameworkCore.Migrations;

namespace JWT_Authentication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name" },
                values: new object[] { 2, "Manager" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name" },
                values: new object[] { 3, "User" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 13, "Karen", "Female", "Kinney", "Karen@123", null, "karen.k@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 12, "Shane", "Male", "Ryan", "Shane@123", null, "shane.r@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 11, "Juliette", "Male", "Majot", "Juliette@123", null, "juliette.m@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 10, "Pierre", "Male", "Tristam", "Pierre@123", null, "pierre.t@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 9, "Charles", "Male", "Pierce", "Charles@123", null, "charles.p@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 8, "Eric", "Male", "Margolis", "Eric@123", null, "eric.m@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 6, "Ferguson", "Male", "Jenkins", "Ferguson@123", null, "ferguson.j@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 14, "Robert", "Male", "Lipsyte", "Robert@123", null, "robert.l@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 5, "Thomas", "Male", "Parisi", "Thomas@123", null, "thomas.p@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 4, "James", "Male", "Baldwin", "James@123", null, "james.b@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 3, "Juan", "Male", "Cole", "Juan@123", null, "juan.c@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 2, "Colin", "Male", "Kaepernick", "Colin@123", null, "colin.k@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 1, "Hosea", "Male", "Burton", "Hosea@123", null, "hosea.b@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 7, "Sonali", "Female", "Sharma", "Sonali@123", null, "sonali.s@jwt.com" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Firstname", "Gender", "Lastname", "Password", "Token", "Username" },
                values: new object[] { 15, "Leonard", "Male", "Junior", "Leonard@123", null, "leonard.j@jwt.com" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 3, 1, 3 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 4, 2, 4 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 5, 2, 5 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 6, 3, 6 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 7, 3, 7 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 8, 3, 8 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 9, 3, 9 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 10, 3, 10 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 11, 3, 11 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 12, 3, 12 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 13, 3, 13 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 14, 3, 14 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 15, 3, 15 });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
