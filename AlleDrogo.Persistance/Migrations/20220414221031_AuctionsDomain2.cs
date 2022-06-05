using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AlleDrogo.Persistance.Migrations
{
    public partial class AuctionsDomain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BiddingTime",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiddingTime",
                table: "Bids");
        }
    }
}
