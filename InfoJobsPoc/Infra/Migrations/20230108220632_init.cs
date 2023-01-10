using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoJobsPoc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidates",
                columns: table => new
                {
                    IdCandidate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidates", x => x.IdCandidate);
                });

            migrationBuilder.CreateTable(
                name: "candidateexperiences",
                columns: table => new
                {
                    IdCandidateExperience = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Job = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: false),
                    Salary = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCandidate = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdCandidateExperience", x => x.IdCandidateExperience)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_candidateexperiences_candidates_IdCandidate",
                        column: x => x.IdCandidate,
                        principalTable: "candidates",
                        principalColumn: "IdCandidate",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "candidates",
                columns: new[] { "IdCandidate", "Birthdate", "Email", "InsertDate", "ModifyDate", "Name", "Surname" },
                values: new object[] { 1, new DateTime(1994, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "loribao@hotmail.com", new DateTime(2023, 1, 8, 19, 6, 32, 77, DateTimeKind.Local).AddTicks(7651), null, "loribao", "sanjinez" });

            migrationBuilder.InsertData(
                table: "candidateexperiences",
                columns: new[] { "IdCandidateExperience", "BeginDate", "Company", "Description", "EndDate", "IdCandidate", "InsertDate", "Job", "ModifyDate", "Salary" },
                values: new object[] { 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "InfoJobs - Pandapé", "Estagiario não remunerado!", null, 1, new DateTime(2023, 1, 8, 19, 6, 32, 77, DateTimeKind.Local).AddTicks(7736), "Estagiario", null, 10000.59m });

            migrationBuilder.CreateIndex(
                name: "IX_candidateexperiences_IdCandidate",
                table: "candidateexperiences",
                column: "IdCandidate");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_Email",
                table: "candidates",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidateexperiences");

            migrationBuilder.DropTable(
                name: "candidates");
        }
    }
}
