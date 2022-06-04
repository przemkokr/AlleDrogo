using Microsoft.EntityFrameworkCore.Migrations;

namespace AlleDrogo.Persistance.Migrations
{
    public partial class added_winner_to_auction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WinnerId",
                table: "Auctions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_WinnerId",
                table: "Auctions",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_AspNetUsers_WinnerId",
                table: "Auctions",
                column: "WinnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_AspNetUsers_WinnerId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_WinnerId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Auctions");
        }
    }
}
