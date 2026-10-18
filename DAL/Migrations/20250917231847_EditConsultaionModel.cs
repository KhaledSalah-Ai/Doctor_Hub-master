using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditConsultaionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasDigestiveIssues",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "HasNeurologicalIssues",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "HasRespiratoryIssues",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "HasUrinaryOrReproductiveIssues",
                table: "Consultations");

            migrationBuilder.AddColumn<string>(
                name: "MedicalSymptoms",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 9, 4, 2, 18, 45, 487, DateTimeKind.Local).AddTicks(5313));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 8, 18, 2, 18, 45, 487, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 8, 28, 2, 18, 45, 487, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2025, 7, 18, 2, 18, 45, 487, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2025, 8, 18, 2, 18, 45, 487, DateTimeKind.Local).AddTicks(5416));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalSymptoms",
                table: "Consultations");

            migrationBuilder.AddColumn<bool>(
                name: "HasDigestiveIssues",
                table: "Consultations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasNeurologicalIssues",
                table: "Consultations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasRespiratoryIssues",
                table: "Consultations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasUrinaryOrReproductiveIssues",
                table: "Consultations",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 9, 1, 0, 21, 1, 976, DateTimeKind.Local).AddTicks(975));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 8, 15, 0, 21, 1, 976, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 8, 25, 0, 21, 1, 976, DateTimeKind.Local).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2025, 7, 15, 0, 21, 1, 976, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2025, 8, 15, 0, 21, 1, 976, DateTimeKind.Local).AddTicks(1087));
        }
    }
}
