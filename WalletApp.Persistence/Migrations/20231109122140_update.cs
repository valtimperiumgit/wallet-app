using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_FromUserId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_ToUserId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                table: "Transactions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "Transactions",
                newName: "AuthorizedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ToUserId",
                table: "Transactions",
                newName: "IX_Transactions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_FromUserId",
                table: "Transactions",
                newName: "IX_Transactions_AuthorizedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_AuthorizedUserId",
                table: "Transactions",
                column: "AuthorizedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_AuthorizedUserId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transactions",
                newName: "ToUserId");

            migrationBuilder.RenameColumn(
                name: "AuthorizedUserId",
                table: "Transactions",
                newName: "FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                newName: "IX_Transactions_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AuthorizedUserId",
                table: "Transactions",
                newName: "IX_Transactions_FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_FromUserId",
                table: "Transactions",
                column: "FromUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_ToUserId",
                table: "Transactions",
                column: "ToUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
