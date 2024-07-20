using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroRabbit.Transfer.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTransferModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FromAccountId",
                table: "TransferLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToAccountId",
                table: "TransferLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TransferAmount",
                table: "TransferLogs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromAccountId",
                table: "TransferLogs");

            migrationBuilder.DropColumn(
                name: "ToAccountId",
                table: "TransferLogs");

            migrationBuilder.DropColumn(
                name: "TransferAmount",
                table: "TransferLogs");
        }
    }
}
