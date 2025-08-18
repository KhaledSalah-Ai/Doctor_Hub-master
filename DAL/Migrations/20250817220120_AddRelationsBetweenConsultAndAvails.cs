using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationsBetweenConsultAndAvails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvisorAvailabilityId",
                table: "Consultations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_AdvisorAvailabilityId",
                table: "Consultations",
                column: "AdvisorAvailabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_advisorAvailabilities_AdvisorAvailabilityId",
                table: "Consultations",
                column: "AdvisorAvailabilityId",
                principalTable: "advisorAvailabilities",
                principalColumn: "AvailabilityId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_advisorAvailabilities_AdvisorAvailabilityId",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_AdvisorAvailabilityId",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "AdvisorAvailabilityId",
                table: "Consultations");

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
    }
}
