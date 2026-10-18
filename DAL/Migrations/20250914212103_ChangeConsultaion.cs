using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConsultaion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allergies",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "ChronicDiseases",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "CurrentMedications",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "FamilyDiseases",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "InfectiousDiseases",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "LastVaccinationDate",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "MentalHealthIssues",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "PastSurgeries",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "PreviousTestsResults",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "PsychiatricMedications",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "RecommendedTreatment",
                table: "Consultations");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "MedicalSpecialties",
                newName: "PriceUSD");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceIQD",
                table: "MedicalSpecialties",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsIraqi",
                table: "Consultations",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "PriceIQD",
                value: 30m);

            migrationBuilder.UpdateData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PriceIQD", "PriceUSD" },
                values: new object[] { 40m, 40m });

            migrationBuilder.UpdateData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PriceIQD", "PriceUSD" },
                values: new object[] { 30m, 30m });

            migrationBuilder.UpdateData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "PriceIQD",
                value: null);

            migrationBuilder.UpdateData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "PriceIQD",
                value: null);

            migrationBuilder.UpdateData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "PriceIQD",
                value: null);

            migrationBuilder.UpdateData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "PriceIQD",
                value: null);

            migrationBuilder.UpdateData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "PriceIQD",
                value: null);

            migrationBuilder.UpdateData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "PriceIQD",
                value: null);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceIQD",
                table: "MedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "IsIraqi",
                table: "Consultations");

            migrationBuilder.RenameColumn(
                name: "PriceUSD",
                table: "MedicalSpecialties",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "Allergies",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChronicDiseases",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentMedications",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyDiseases",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfectiousDiseases",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastVaccinationDate",
                table: "Consultations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MentalHealthIssues",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PastSurgeries",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousTestsResults",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PsychiatricMedications",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecommendedTreatment",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

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
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "MedicalSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 40m);

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
    }
}
