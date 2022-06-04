using Microsoft.EntityFrameworkCore.Migrations;

namespace AlleDrogo.Persistance.Migrations
{
    public partial class added_rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingPoints = table.Column<double>(type: "float", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: true),
                    EvaluatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EvaluatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_EvaluatedUserId",
                        column: x => x.EvaluatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AuctionId",
                table: "Ratings",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_EvaluatedUserId",
                table: "Ratings",
                column: "EvaluatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_EvaluatorId",
                table: "Ratings",
                column: "EvaluatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
