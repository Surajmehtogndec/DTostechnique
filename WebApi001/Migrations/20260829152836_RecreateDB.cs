using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi001.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Biography = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.AuthorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MembershipNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MembershipType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "'Student'", collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "curdate()"),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "'Active'", collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MemberId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PublisherId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ISBN = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorId = table.Column<int>(type: "int(11)", nullable: false),
                    CategoryId = table.Column<int>(type: "int(11)", nullable: false),
                    PublisherId = table.Column<int>(type: "int(11)", nullable: true),
                    PublicationYear = table.Column<int>(type: "int(11)", nullable: true),
                    TotalCopies = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
                    AvailableCopies = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "AuthorId");
                    table.ForeignKey(
                        name: "FK_Books_Categories",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Books_Publishers",
                        column: x => x.PublisherId,
                        principalTable: "publishers",
                        principalColumn: "PublisherId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "bookissues",
                columns: table => new
                {
                    IssueId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(type: "int(11)", nullable: false),
                    MemberId = table.Column<int>(type: "int(11)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "'Issued'", collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IssueId);
                    table.ForeignKey(
                        name: "FK_BookIssues_Books",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_BookIssues_Members",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "MemberId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "bookreturns",
                columns: table => new
                {
                    ReturnId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IssueId = table.Column<int>(type: "int(11)", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    Condition = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remarks = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ReturnId);
                    table.ForeignKey(
                        name: "FK_BookReturns_BookIssues",
                        column: x => x.IssueId,
                        principalTable: "bookissues",
                        principalColumn: "IssueId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "fines",
                columns: table => new
                {
                    FineId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IssueId = table.Column<int>(type: "int(11)", nullable: false),
                    FineAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "'Pending'", collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.FineId);
                    table.ForeignKey(
                        name: "FK_Fines_BookIssues",
                        column: x => x.IssueId,
                        principalTable: "bookissues",
                        principalColumn: "IssueId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "FK_BookIssues_Books",
                table: "bookissues",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "FK_BookIssues_Members",
                table: "bookissues",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "UQ_BookReturns_IssueId",
                table: "bookreturns",
                column: "IssueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Books_Authors",
                table: "books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "FK_Books_Categories",
                table: "books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "FK_Books_Publishers",
                table: "books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "UQ_Books_ISBN",
                table: "books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Fines_BookIssues",
                table: "fines",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "UQ_Members_Email",
                table: "members",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Members_MembershipNumber",
                table: "members",
                column: "MembershipNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookreturns");

            migrationBuilder.DropTable(
                name: "fines");

            migrationBuilder.DropTable(
                name: "bookissues");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
