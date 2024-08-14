using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_CommerceProduct.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class relationshipBetweenProductandProductQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductQuantities_ProductId",
                table: "ProductQuantities");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2146a7d8-866b-4c4f-90d3-60bad08b0986"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ea933f8-cedb-4293-b1a0-7a00929d70cf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("82b1b1aa-5ed3-4f68-983b-1ea828f82409"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c488870f-2930-4830-bf3b-c62b78cacfda"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a238da9e-efc5-4222-9d57-4e1fd4780e8d"), "Electronics" },
                    { new Guid("ad697fd3-34fe-42df-b030-3447f9f3f97b"), "Clothing" },
                    { new Guid("c5895e21-1b2d-4e4f-a527-03bb00b529f7"), "FoodAndBeverages" },
                    { new Guid("f3d8e365-4f91-460a-8ea7-0574190ec25d"), "Books" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_ProductId",
                table: "ProductQuantities",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductQuantities_ProductId",
                table: "ProductQuantities");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a238da9e-efc5-4222-9d57-4e1fd4780e8d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ad697fd3-34fe-42df-b030-3447f9f3f97b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c5895e21-1b2d-4e4f-a527-03bb00b529f7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f3d8e365-4f91-460a-8ea7-0574190ec25d"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2146a7d8-866b-4c4f-90d3-60bad08b0986"), "Clothing" },
                    { new Guid("6ea933f8-cedb-4293-b1a0-7a00929d70cf"), "Books" },
                    { new Guid("82b1b1aa-5ed3-4f68-983b-1ea828f82409"), "FoodAndBeverages" },
                    { new Guid("c488870f-2930-4830-bf3b-c62b78cacfda"), "Electronics" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_ProductId",
                table: "ProductQuantities",
                column: "ProductId");
        }
    }
}
