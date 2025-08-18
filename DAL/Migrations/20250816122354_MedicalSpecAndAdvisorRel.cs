using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class MedicalSpecAndAdvisorRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Advisors_MedicalSpecialtyId",
                table: "Advisors");

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 8, 2, 15, 23, 52, 715, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 16, 15, 23, 52, 715, DateTimeKind.Local).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 26, 15, 23, 52, 715, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2025, 6, 16, 15, 23, 52, 715, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2025, 7, 16, 15, 23, 52, 715, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_MedicalSpecialtyId",
                table: "Advisors",
                column: "MedicalSpecialtyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Advisors_MedicalSpecialtyId",
                table: "Advisors");

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 31, 16, 23, 20, 400, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 14, 16, 23, 20, 400, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 24, 16, 23, 20, 400, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2025, 6, 14, 16, 23, 20, 400, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2025, 7, 14, 16, 23, 20, 400, DateTimeKind.Local).AddTicks(283));

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_MedicalSpecialtyId",
                table: "Advisors",
                column: "MedicalSpecialtyId");
        }
    }
}
