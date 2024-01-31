using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(8)", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "INT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentPortfolio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentPortfolio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentPortfolio_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AveragePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    InvestmentPortfolioId = table.Column<int>(type: "int", nullable: false),
                    AssetId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentPosition_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestmentPosition_Asset_AssetId1",
                        column: x => x.AssetId1,
                        principalTable: "Asset",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvestmentPosition_InvestmentPortfolio_InvestmentPortfolioId",
                        column: x => x.InvestmentPortfolioId,
                        principalTable: "InvestmentPortfolio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_UserId",
                table: "BankAccount",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPortfolio_UserId",
                table: "InvestmentPortfolio",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPosition_AssetId",
                table: "InvestmentPosition",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPosition_AssetId1",
                table: "InvestmentPosition",
                column: "AssetId1");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentPosition_InvestmentPortfolioId",
                table: "InvestmentPosition",
                column: "InvestmentPortfolioId");

            migrationBuilder.Sql(@"
                INSERT INTO dbo.Asset (Symbol, Name, Price)
                VALUES
                ('AAPL', 'Apple Inc.', 150.00),
                ('GOOGL', 'Alphabet Inc.', 2500.00),
                ('MSFT', 'Microsoft Corporation', 300.00),
                ('AMZN', 'Amazon.com Inc.', 3500.00);
                
                INSERT INTO [User] (Name, Email, Password, Permission, Status, CreatedOn, LastModifiedOn, IsDeleted)
                VALUES
                ('David Henrique', 'david@gmail.com', '123456', 1, 1, GETDATE(), GETDATE(), 0),
                ('João Paulo', 'joao@gmail.com', '654321', 2, 1, GETDATE(), GETDATE(), 0),
                ('Maria Alice', 'maria@gmail.com', '123456', 3, 1, GETDATE(), GETDATE(), 0),
                ('Ana Paula', 'ana@gmail.com', '123456', 3, 1, GETDATE(), GETDATE(), 0),
                ('Heitor', 'heitor@gmail.com', '123456', 2, 0, GETDATE(), GETDATE(), 1),
                ('Gabriel', 'gabriel@gmail.com', '123456', 2, 0, GETDATE(), GETDATE(), 1);
                
                INSERT INTO [BankAccount] (Balance, CreatedOn, LastModifiedOn, UserId)
                VALUES
                (100000.00, GETDATE(), GETDATE(), 1),
                (50000.00, GETDATE(), GETDATE(), 2),
                (5.00, GETDATE(), GETDATE(), 3),
                (-100.00, GETDATE(), GETDATE(), 4);
                
                INSERT INTO InvestmentPortfolio (UserId)
                VALUES
                (1),
                (2),
                (3),
                (4),
                (5);
                
                INSERT INTO InvestmentPosition (AssetId, Quantity, AveragePrice, CreatedOn, LastModifiedOn, InvestmentPortfolioId)
                VALUES
                (2, 20, 2000.00, GETDATE(), GETDATE(), 4),
                (4, 2, 3200.00, GETDATE(), GETDATE(), 4),
                (3, 2, 200.00, GETDATE(), GETDATE(), 3),
                (1, 30, 100.00, GETDATE(), GETDATE(), 3),
                (2, 10, 2300.00, GETDATE(), GETDATE(), 2),
                (1, 100, 50.00, GETDATE(), GETDATE(), 1),
                (3, 50, 175.00, GETDATE(), GETDATE(), 1),
                (4, 75, 3000.00, GETDATE(), GETDATE(), 1);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "InvestmentPosition");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "InvestmentPortfolio");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
