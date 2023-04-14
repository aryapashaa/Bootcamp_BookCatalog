using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookCatalog_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_languages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_languages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_publishers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_publishers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    country_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_cities_tb_m_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "tb_m_countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isbn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    release_year = table.Column<string>(type: "nchar(4)", nullable: false),
                    synopsis = table.Column<string>(type: "text", nullable: false),
                    page_number = table.Column<int>(type: "int", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    picture_url = table.Column<string>(type: "text", nullable: true),
                    tokopedia_url = table.Column<string>(type: "text", nullable: true),
                    shopee_url = table.Column<string>(type: "text", nullable: true),
                    lazada_url = table.Column<string>(type: "text", nullable: true),
                    rating = table.Column<decimal>(type: "decimal(2,1)", nullable: true),
                    publisher_id = table.Column<int>(type: "int", nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    language_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_books", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_books_tb_m_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "tb_m_authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_books_tb_m_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "tb_m_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_books_tb_m_publishers_publisher_id",
                        column: x => x.publisher_id,
                        principalTable: "tb_m_publishers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_addresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_addresses_tb_m_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "tb_m_cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_profiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_profiles_tb_m_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "tb_m_addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_profiles_id",
                        column: x => x.id,
                        principalTable: "tb_m_profiles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_accountroles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_accountroles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_accountroles_tb_m_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "tb_m_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_accountroles_tb_m_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tb_m_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_addresses_city_id",
                table: "tb_m_addresses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_books_author_id",
                table: "tb_m_books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_books_isbn",
                table: "tb_m_books",
                column: "isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_books_language_id",
                table: "tb_m_books",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_books_publisher_id",
                table: "tb_m_books",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_cities_country_id",
                table: "tb_m_cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_profiles_address_id",
                table: "tb_m_profiles",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_profiles_email",
                table: "tb_m_profiles",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_accountroles_account_id",
                table: "tb_tr_accountroles",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_accountroles_role_id",
                table: "tb_tr_accountroles",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_books");

            migrationBuilder.DropTable(
                name: "tb_tr_accountroles");

            migrationBuilder.DropTable(
                name: "tb_m_authors");

            migrationBuilder.DropTable(
                name: "tb_m_languages");

            migrationBuilder.DropTable(
                name: "tb_m_publishers");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_profiles");

            migrationBuilder.DropTable(
                name: "tb_m_addresses");

            migrationBuilder.DropTable(
                name: "tb_m_cities");

            migrationBuilder.DropTable(
                name: "tb_m_countries");
        }
    }
}
