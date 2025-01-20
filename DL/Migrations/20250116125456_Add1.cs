using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    /// <inheritdoc />
    public partial class Add1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Babies_babyId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Nurses_nurseId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "f",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "nurseId",
                table: "Appointments",
                newName: "NurseId");

            migrationBuilder.RenameColumn(
                name: "babyId",
                table: "Appointments",
                newName: "BabyId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_nurseId",
                table: "Appointments",
                newName: "IX_Appointments_NurseId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_babyId",
                table: "Appointments",
                newName: "IX_Appointments_BabyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Babies_BabyId",
                table: "Appointments",
                column: "BabyId",
                principalTable: "Babies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Nurses_NurseId",
                table: "Appointments",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Babies_BabyId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Nurses_NurseId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "NurseId",
                table: "Appointments",
                newName: "nurseId");

            migrationBuilder.RenameColumn(
                name: "BabyId",
                table: "Appointments",
                newName: "babyId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_NurseId",
                table: "Appointments",
                newName: "IX_Appointments_nurseId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_BabyId",
                table: "Appointments",
                newName: "IX_Appointments_babyId");

            migrationBuilder.AddColumn<int>(
                name: "f",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Babies_babyId",
                table: "Appointments",
                column: "babyId",
                principalTable: "Babies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Nurses_nurseId",
                table: "Appointments",
                column: "nurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
