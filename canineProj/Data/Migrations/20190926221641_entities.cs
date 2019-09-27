using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace canineProj.Data.Migrations
{
    public partial class entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    BreedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResultID = table.Column<int>(nullable: false),
                    Breed1 = table.Column<string>(nullable: true),
                    Breed1Percent = table.Column<double>(nullable: false),
                    Breed2 = table.Column<string>(nullable: true),
                    Breed2Percent = table.Column<double>(nullable: false),
                    Breed3 = table.Column<string>(nullable: true),
                    Breed3Percent = table.Column<double>(nullable: false),
                    Breed4 = table.Column<string>(nullable: true),
                    Breed4Percent = table.Column<double>(nullable: false),
                    Breed5 = table.Column<string>(nullable: true),
                    Breed5Percent = table.Column<double>(nullable: false),
                    Rkey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.BreedID);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Rkey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Shipped = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Line1 = table.Column<string>(nullable: false),
                    Line2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    CreditName = table.Column<string>(nullable: false),
                    CreditCard = table.Column<int>(nullable: false),
                    ExpDate = table.Column<int>(nullable: false),
                    CIV = table.Column<int>(nullable: false),
                    GiftWrap = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DogID = table.Column<int>(nullable: false),
                    BreedID = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    DrugSensitivity = table.Column<string>(nullable: true),
                    Eyes = table.Column<string>(nullable: true),
                    Heart = table.Column<string>(nullable: true),
                    Rkey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultID);
                });

            migrationBuilder.CreateTable(
                name: "CartLine",
                columns: table => new
                {
                    CartLineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLine", x => x.CartLineID);
                    table.ForeignKey(
                        name: "FK_CartLine_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartLine_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_OrderID",
                table: "CartLine",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_ProductID",
                table: "CartLine",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "CartLine");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
