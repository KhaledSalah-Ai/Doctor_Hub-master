using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedInitialAdvisorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Advisors",
                columns: new[] { "AdvisorId", "Email", "MedicalSpecialtyId", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "doctor.cardiology@example.com", 1, "د. أحمد المصري", "01001234567" },
                    { 2, "doctor.dermatology@example.com", 2, "د. فاطمة الزهراء", "01117654321" }
                });

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 8, 2, 16, 20, 32, 872, DateTimeKind.Local).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 16, 16, 20, 32, 872, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 26, 16, 20, 32, 872, DateTimeKind.Local).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2025, 6, 16, 16, 20, 32, 872, DateTimeKind.Local).AddTicks(3537));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2025, 7, 16, 16, 20, 32, 872, DateTimeKind.Local).AddTicks(3542));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Advisors",
                keyColumn: "AdvisorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Advisors",
                keyColumn: "AdvisorId",
                keyValue: 2);

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
        }
    }
}
