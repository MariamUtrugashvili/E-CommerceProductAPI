using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_CommerceProduct.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class changeUpdateAtColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProductQuantities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0474db0d-28e4-4527-b913-d95aa5cea633"), "Books" },
                    { new Guid("65de9e5c-09a5-4b93-b86a-8ec5feda6e5c"), "Clothing" },
                    { new Guid("bc409863-41af-4c64-ace2-8f61ddfbe17f"), "FoodAndBeverages" },
                    { new Guid("f3331a8f-ed82-4cbb-824d-db54ef5a4b7b"), "Electronics" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0474db0d-28e4-4527-b913-d95aa5cea633"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("65de9e5c-09a5-4b93-b86a-8ec5feda6e5c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bc409863-41af-4c64-ace2-8f61ddfbe17f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f3331a8f-ed82-4cbb-824d-db54ef5a4b7b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProductQuantities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
        }
    }
}
