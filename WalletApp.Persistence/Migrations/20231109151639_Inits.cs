using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalletApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Inits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IconUrl = table.Column<string>(type: "text", nullable: false),
                    IsPending = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorizedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_AuthorizedUserId",
                        column: x => x.AuthorizedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527"), "test@gmail.com", "Test", "55fbbb9de6c380e13013f7f7621cfafdc939fe87c1b0af1cc425aa18f3744dec" },
                    { new Guid("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae"), "friend@gmail.com", "Friend", "55fbbb9de6c380e13013f7f7621cfafdc939fe87c1b0af1cc425aa18f3744dec" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "AuthorizedUserId", "CreatedAt", "Description", "IconUrl", "IsPending", "Name", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("a2c8222f-e19d-401e-94df-f9ddeae2fd24"), 500m, new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527"), new DateTime(2023, 10, 9, 4, 2, 3, 0, DateTimeKind.Utc), "From ATM Los Angeles", "https://cdn-icons-png.flaticon.com/512/6059/6059866.png", false, "ATM Los Angeles", 1, new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527") },
                    { new Guid("b40f6bfa-5bca-43ba-92e0-75a003c90b19"), 43.61m, new Guid("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae"), new DateTime(2023, 11, 9, 4, 5, 6, 0, DateTimeKind.Utc), "Card Number Used", "https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png?202103091141", false, "Apple", 2, new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527") },
                    { new Guid("ba8ac6fc-e17d-4616-9fd7-e42caadcd3cf"), 21.61m, new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527"), new DateTime(2023, 11, 9, 1, 2, 3, 0, DateTimeKind.Utc), "Round Rock, Tc", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThmMLqHvT1CtfTxVLZB3Uhg3GyH7loVRDQFg&usqp=CAU", false, "IKEA", 2, new Guid("addc6bbe-85ee-4a4e-b3da-22789b650527") },
                    { new Guid("fe0f415c-064f-4591-b45d-328380bfa076"), 1000m, new Guid("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae"), new DateTime(2023, 11, 9, 8, 7, 6, 0, DateTimeKind.Utc), "Some payment", "https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png?202103091141", false, "Payment", 1, new Guid("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AuthorizedUserId",
                table: "Transactions",
                column: "AuthorizedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
