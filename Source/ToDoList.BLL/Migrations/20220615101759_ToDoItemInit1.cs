using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.BLL.Migrations
{
    public partial class ToDoItemInit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDoItemData");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "ToDoItemData",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ToDoDescription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoDescription", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItemData_DescriptionId",
                table: "ToDoItemData",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItemData_ToDoDescription_DescriptionId",
                table: "ToDoItemData",
                column: "DescriptionId",
                principalTable: "ToDoDescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItemData_ToDoDescription_DescriptionId",
                table: "ToDoItemData");

            migrationBuilder.DropTable(
                name: "ToDoDescription");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItemData_DescriptionId",
                table: "ToDoItemData");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "ToDoItemData");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDoItemData",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
