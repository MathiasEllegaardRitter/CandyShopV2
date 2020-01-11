using Microsoft.EntityFrameworkCore.Migrations;

namespace CandyShopV2.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candies_categories_CatagoryId",
                table: "Candies");

            migrationBuilder.AlterColumn<int>(
                name: "CatagoryId",
                table: "Candies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CatagoryId", "CategoryDescription", "CategoryName" },
                values: new object[] { 1, "The worst candy", "Chocolate candy" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CatagoryId", "CategoryDescription", "CategoryName" },
                values: new object[] { 3, "This is the one for candys with P.H levels below 6", "Sweet" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CatagoryId", "CategoryDescription", "CategoryName" },
                values: new object[] { 2, "This is the one for candys with P.H levels above 6", "Sore" });

            migrationBuilder.InsertData(
                table: "Candies",
                columns: new[] { "CandyId", "CatagoryId", "Descrition", "ImageThumbNail", "ImageUrl", "IsOnSale", "IsOnStock", "Name", "Price" },
                values: new object[] { 3, 1, "Very beary", "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\gummyCandy2.jpg", "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\thumbnails\\gummyCandy2-small.jpg", true, true, "Gummy bears", 5f });

            migrationBuilder.InsertData(
                table: "Candies",
                columns: new[] { "CandyId", "CatagoryId", "Descrition", "ImageThumbNail", "ImageUrl", "IsOnSale", "IsOnStock", "Name", "Price" },
                values: new object[] { 1, 3, "Very sweet", "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\thumbnails\\FruitCandy-small.jpg", "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\FruitCandy.jpg", true, true, "Sweet candy", 20f });

            migrationBuilder.InsertData(
                table: "Candies",
                columns: new[] { "CandyId", "CatagoryId", "Descrition", "ImageThumbNail", "ImageUrl", "IsOnSale", "IsOnStock", "Name", "Price" },
                values: new object[] { 2, 2, "Very sour", "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\thumbnails\\halloweenCandy-small.jpg", "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\halloweenCandy.jpg", true, true, "Sour", 50f });

            migrationBuilder.AddForeignKey(
                name: "FK_Candies_categories_CatagoryId",
                table: "Candies",
                column: "CatagoryId",
                principalTable: "categories",
                principalColumn: "CatagoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candies_categories_CatagoryId",
                table: "Candies");

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "CatagoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "CatagoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "CatagoryId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CatagoryId",
                table: "Candies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Candies_categories_CatagoryId",
                table: "Candies",
                column: "CatagoryId",
                principalTable: "categories",
                principalColumn: "CatagoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
