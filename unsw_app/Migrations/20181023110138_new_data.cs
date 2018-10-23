using Microsoft.EntityFrameworkCore.Migrations;

namespace unsw_app.Migrations
{
    public partial class new_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "Occupation",
                value: "kitchen");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Occupation", "PatientName" },
                values: new object[,]
                {
                    { 2, "living room", "patient_2" },
                    { 3, "bath room", "patient_3" },
                    { 4, "kitchen", "patient_4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "Occupation",
                value: null);
        }
    }
}
