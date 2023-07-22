using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject_MVC_G4.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Garnitures",
                columns: table => new
                {
                    GarnitureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarnitureName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garnitures", x => x.GarnitureID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmallPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MiddlePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BigPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuID);
                });

            migrationBuilder.CreateTable(
                name: "UserMenus",
                columns: table => new
                {
                    UserMenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMenus", x => x.UserMenuID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    UserMassage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GarnitureProduct",
                columns: table => new
                {
                    GarnituresGarnitureID = table.Column<int>(type: "int", nullable: false),
                    ProductsProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarnitureProduct", x => new { x.GarnituresGarnitureID, x.ProductsProductID });
                    table.ForeignKey(
                        name: "FK_GarnitureProduct_Garnitures_GarnituresGarnitureID",
                        column: x => x.GarnituresGarnitureID,
                        principalTable: "Garnitures",
                        principalColumn: "GarnitureID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarnitureProduct_Products_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuProduct",
                columns: table => new
                {
                    MenusMenuID = table.Column<int>(type: "int", nullable: false),
                    ProductsProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuProduct", x => new { x.MenusMenuID, x.ProductsProductID });
                    table.ForeignKey(
                        name: "FK_MenuProduct_Menus_MenusMenuID",
                        column: x => x.MenusMenuID,
                        principalTable: "Menus",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuProduct_Products_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsUserMenus",
                columns: table => new
                {
                    ProductUserMenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UserMenuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsUserMenus", x => x.ProductUserMenuID);
                    table.ForeignKey(
                        name: "FK_ProductsUserMenus_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsUserMenus_UserMenus_UserMenuID",
                        column: x => x.UserMenuID,
                        principalTable: "UserMenus",
                        principalColumn: "UserMenuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserMenuID = table.Column<int>(type: "int", nullable: true),
                    ProductsID = table.Column<int>(type: "int", nullable: true),
                    MenuID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "MenuID");
                    table.ForeignKey(
                        name: "FK_Carts_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Carts_UserMenus_UserMenuID",
                        column: x => x.UserMenuID,
                        principalTable: "UserMenus",
                        principalColumn: "UserMenuID");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "27da7840-3487-4727-a353-ed4642ff1537", "Admin", "ADMIN" },
                    { 2, "3af26a4b-9658-4230-a59d-cd1d83d65feb", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Burger" },
                    { 2, "Potatoes" },
                    { 3, "Sauce" },
                    { 4, "Beverage" },
                    { 5, "Extra" }
                });

            migrationBuilder.InsertData(
                table: "Garnitures",
                columns: new[] { "GarnitureID", "GarnitureName" },
                values: new object[,]
                {
                    { 1, "Tomatoes" },
                    { 2, "Ketchup" },
                    { 3, "Mayonnaise" },
                    { 4, "Barbeque" },
                    { 5, "Lettuce" },
                    { 6, "Onion" },
                    { 7, "Cheese" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuID", "BigPrice", "CoverImage", "MenuName", "MiddlePrice", "SmallPrice" },
                values: new object[,]
                {
                    { 1, 230m, "1BigKingMenu.png", "BigKing Menu", 210m, 190m },
                    { 2, 200m, "2BigTastyMenu.png", "BigTasty Menu", 180m, 160m },
                    { 3, 210m, "3WhooperMenu.png", "Whooper Menu", 190m, 170m },
                    { 4, 190m, "4ClassicMenu.png", "Classic Menu", 170m, 150m },
                    { 5, 230m, "5DoubleQuarterMenu.png", "Double Quarter Menu", 210m, 190m },
                    { 6, 210m, "6CheeseBurgerMenu.png", "Cheese Burger Menu", 190m, 170m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "CoverImage", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 3, "3Barbeque.png", 10m, "Barbeque" },
                    { 2, 1, "1BigKing.png", 150m, "BigKing" },
                    { 3, 1, "2BigTasty.png", 120m, "BigTasty" },
                    { 4, 1, "3Whooper.png", 130m, "Whooper" },
                    { 5, 1, "4Classic.png", 110m, "Classic" },
                    { 6, 1, "5DoubleQuarter.png", 150m, "Double Quarter" },
                    { 7, 1, "6CheeseBurger.png", 130m, "Cheese Burger" },
                    { 8, 5, "1Nugget.png", 40m, "Nugget" },
                    { 9, 5, "2OnionRing.png", 40m, "Onion Ring" },
                    { 10, 5, "3Schnitzel.png", 40m, "Schnitzel" },
                    { 11, 2, "1FrenchFries.png", 30m, "French Fries" },
                    { 12, 2, "2Scalloped.png", 30m, "Scalloped" },
                    { 13, 4, "1CocaCola.png", 30m, "CocaCola" },
                    { 14, 4, "2Fanta.png", 30m, "Fanta" },
                    { 15, 4, "3Sprite.png", 30m, "Sprite" },
                    { 16, 4, "4Beer.png", 30m, "Beer" },
                    { 17, 3, "1Mayonnaise.png", 10m, "Mayonnaise" },
                    { 18, 3, "2Ketchup.png", 10m, "Ketchup" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AppUserID",
                table: "Addresses",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AppUserID",
                table: "Carts",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_MenuID",
                table: "Carts",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OrderID",
                table: "Carts",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductsID",
                table: "Carts",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserMenuID",
                table: "Carts",
                column: "UserMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_GarnitureProduct_ProductsProductID",
                table: "GarnitureProduct",
                column: "ProductsProductID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuProduct_ProductsProductID",
                table: "MenuProduct",
                column: "ProductsProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressID",
                table: "Orders",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsUserMenus_ProductID",
                table: "ProductsUserMenus",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsUserMenus_UserMenuID",
                table: "ProductsUserMenus",
                column: "UserMenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "GarnitureProduct");

            migrationBuilder.DropTable(
                name: "MenuProduct");

            migrationBuilder.DropTable(
                name: "ProductsUserMenus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Garnitures");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserMenus");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
