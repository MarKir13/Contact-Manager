using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SpellingCorrectionInContactModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("246488f7-b035-4504-aae2-202030c5a98f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a09fd455-c465-456b-aa32-781c6035be18"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("df72dae6-8b68-42e8-9a7a-9c7cf92eacd3"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("1042f6ad-e484-4951-9bb5-fb44b8551ce9"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("770bbfa0-8923-4b6e-ab41-d93172e4e85e"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("b6019c07-f25b-4c96-97f9-a047402ae693"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("d865da6b-20ff-4b67-a7e5-622fc44a172c"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("fd6eb736-95f3-4d3c-966b-67372dacaea8"));

            migrationBuilder.RenameColumn(
                name: "PhoneNumer",
                table: "Contacts",
                newName: "PhoneNumber");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ad22cefc-5185-43f2-a147-a838aa9f4907"), "Prywatny" },
                    { new Guid("d385b074-81a1-4e54-b9be-2921c7a8de40"), "Służbowy" },
                    { new Guid("fb67afe7-812a-4f0f-9413-3d206cc565cb"), "Inny" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("089347c0-5c73-4820-bef3-66bb9bca516d"), "Klient" },
                    { new Guid("163b8122-6f13-4ace-ad50-9aa0e8a53f49"), "Szef" },
                    { new Guid("63de2ba3-13aa-4c5f-98b0-4aa1d0848105"), "Kadry" },
                    { new Guid("c007a9a3-9070-4eca-9cd5-9a0a91e42458"), "Księgowość" },
                    { new Guid("f9896737-c4ad-4771-b27a-feb984dda70b"), "Współpracownik" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ad22cefc-5185-43f2-a147-a838aa9f4907"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d385b074-81a1-4e54-b9be-2921c7a8de40"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fb67afe7-812a-4f0f-9413-3d206cc565cb"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("089347c0-5c73-4820-bef3-66bb9bca516d"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("163b8122-6f13-4ace-ad50-9aa0e8a53f49"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("63de2ba3-13aa-4c5f-98b0-4aa1d0848105"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("c007a9a3-9070-4eca-9cd5-9a0a91e42458"));

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("f9896737-c4ad-4771-b27a-feb984dda70b"));

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Contacts",
                newName: "PhoneNumer");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("246488f7-b035-4504-aae2-202030c5a98f"), "Służbowy" },
                    { new Guid("a09fd455-c465-456b-aa32-781c6035be18"), "Inny" },
                    { new Guid("df72dae6-8b68-42e8-9a7a-9c7cf92eacd3"), "Prywatny" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1042f6ad-e484-4951-9bb5-fb44b8551ce9"), "Księgowość" },
                    { new Guid("770bbfa0-8923-4b6e-ab41-d93172e4e85e"), "Kadry" },
                    { new Guid("b6019c07-f25b-4c96-97f9-a047402ae693"), "Współpracownik" },
                    { new Guid("d865da6b-20ff-4b67-a7e5-622fc44a172c"), "Szef" },
                    { new Guid("fd6eb736-95f3-4d3c-966b-67372dacaea8"), "Klient" }
                });
        }
    }
}
