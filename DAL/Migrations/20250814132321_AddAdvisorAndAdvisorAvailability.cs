using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAdvisorAndAdvisorAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advisors",
                columns: table => new
                {
                    AdvisorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalSpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => x.AdvisorId);
                    table.ForeignKey(
                        name: "FK_Advisors_MedicalSpecialties_MedicalSpecialtyId",
                        column: x => x.MedicalSpecialtyId,
                        principalTable: "MedicalSpecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "advisorAvailabilities",
                columns: table => new
                {
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advisorAvailabilities", x => x.AvailabilityId);
                    table.ForeignKey(
                        name: "FK_advisorAvailabilities_Advisors_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_advisorAvailabilities_AdvisorId",
                table: "advisorAvailabilities",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_MedicalSpecialtyId",
                table: "Advisors",
                column: "MedicalSpecialtyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advisorAvailabilities");

            migrationBuilder.DropTable(
                name: "Advisors");

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 15, 14, 10, 29, 143, DateTimeKind.Local).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2025, 6, 29, 14, 10, 29, 143, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "CustomerReviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewDate",
                value: new DateTime(2025, 7, 8, 14, 10, 29, 143, DateTimeKind.Local).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2025, 5, 29, 14, 10, 29, 143, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2025, 6, 29, 14, 10, 29, 143, DateTimeKind.Local).AddTicks(3640));
        }
    }
}
