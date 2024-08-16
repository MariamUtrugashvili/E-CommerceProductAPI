using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_CommerceProduct.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCategoryEnumToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("4fc68872-822f-45ee-a5a1-334a06c675b2"), "Electronics" },
                    { new Guid("8a26da82-b02c-43b6-a7c6-6c7b9fb43492"), "FoodAndBeverages" },
                    { new Guid("e01d53fd-2590-4bf6-8f03-d5ea75a6b700"), "Books" },
                    { new Guid("e889a37e-6882-472d-95be-4ecdc4206f1f"), "Clothing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4fc68872-822f-45ee-a5a1-334a06c675b2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8a26da82-b02c-43b6-a7c6-6c7b9fb43492"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e01d53fd-2590-4bf6-8f03-d5ea75a6b700"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e889a37e-6882-472d-95be-4ecdc4206f1f"));

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
    }
}
