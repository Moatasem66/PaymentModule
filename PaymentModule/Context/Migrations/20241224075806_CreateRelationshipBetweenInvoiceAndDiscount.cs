using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentModule.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationshipBetweenInvoiceAndDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DiscountId",
                table: "Invoices",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Discounts_DiscountId",
                table: "Invoices",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Discounts_DiscountId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_DiscountId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Invoices");
        }
    }
}
