using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_CommerceProduct.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("522d462f-3fed-4639-9690-3be13e747d2c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("755f82ae-ef1e-4118-a10d-1f3305133b81"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9847f57a-82d4-4d56-8871-ab2ea7a3e08b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a6655153-d515-4acd-a110-1dac88a38a84"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0287bb1c-24ec-4293-9d78-e31e95f9176c"), "Books" },
                    { new Guid("af23dca3-6851-4331-a1bd-65dd88f6eb34"), "FoodAndBeverages" },
                    { new Guid("af75b9b9-0dd5-4ccd-b7fb-13f0849a58ca"), "Electronics" },
                    { new Guid("ba66f07f-480e-44c3-92ac-352e383b0f41"), "Clothing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0287bb1c-24ec-4293-9d78-e31e95f9176c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af23dca3-6851-4331-a1bd-65dd88f6eb34"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af75b9b9-0dd5-4ccd-b7fb-13f0849a58ca"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ba66f07f-480e-44c3-92ac-352e383b0f41"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("522d462f-3fed-4639-9690-3be13e747d2c"), "Clothing" },
                    { new Guid("755f82ae-ef1e-4118-a10d-1f3305133b81"), "Electronics" },
                    { new Guid("9847f57a-82d4-4d56-8871-ab2ea7a3e08b"), "Books" },
                    { new Guid("a6655153-d515-4acd-a110-1dac88a38a84"), "FoodAndBeverages" }
                });
        }
    }
}
