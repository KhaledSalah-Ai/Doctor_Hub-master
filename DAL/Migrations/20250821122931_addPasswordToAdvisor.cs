using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addPasswordToAdvisor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Advisors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Advisors",
                keyColumn: "AdvisorId",
                keyValue: 1,
                column: "Password",
                value: "12345@Aa");

            migrationBuilder.UpdateData(
                table: "Advisors",
                keyColumn: "AdvisorId",
                keyValue: 2,
                column: "Password",
                value: "12345@Aa");

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 8, 7, 15, 29, 30, 85, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 21, 15, 29, 30, 85, DateTimeKind.Local).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 31, 15, 29, 30, 85, DateTimeKind.Local).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2025, 6, 21, 15, 29, 30, 85, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2025, 7, 21, 15, 29, 30, 85, DateTimeKind.Local).AddTicks(3675));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Advisors");

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 8, 4, 1, 1, 17, 979, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 18, 1, 1, 17, 979, DateTimeKind.Local).AddTicks(1250));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 28, 1, 1, 17, 979, DateTimeKind.Local).AddTicks(1258));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2025, 6, 18, 1, 1, 17, 979, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2025, 7, 18, 1, 1, 17, 979, DateTimeKind.Local).AddTicks(1301));
        }
    }
}
