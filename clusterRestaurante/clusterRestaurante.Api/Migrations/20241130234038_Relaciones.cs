using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clusterRestaurante.Api.Migrations
{
    /// <inheritdoc />
    public partial class Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_EmployeeId",
                table: "Menus",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RestaurantId",
                table: "Employees",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MenuId",
                table: "Dishes",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Menus_MenuId",
                table: "Dishes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Restaurants_RestaurantId",
                table: "Employees",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Employees_EmployeeId",
                table: "Menus",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Menus_MenuId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Restaurants_RestaurantId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Employees_EmployeeId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_EmployeeId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RestaurantId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_MenuId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Dishes");
        }
    }
}
