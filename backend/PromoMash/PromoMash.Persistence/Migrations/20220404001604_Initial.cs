using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromoMash.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<long>(type: "INTEGER", nullable: false),
                    UpdatedAt = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    CountryId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<long>(type: "INTEGER", nullable: false),
                    UpdatedAt = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "d9e67236ce74444d80907fa6180bc181", 1649031363819L, "Country-1", 1649031363819L });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "351d4995d4544d00a813437796fee253", 1649031363819L, "Country-2", 1649031363819L });
            
            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "0ac9f110a7574b8d8d1dcd2297a8670e", "d9e67236ce74444d80907fa6180bc181", 1649031363819L, "Province-1.1", 1649031363819L });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "0d727eb425994829b72c59c225ac62d1", "d9e67236ce74444d80907fa6180bc181", 1649031363819L, "Province-1.2", 1649031363819L });
            
            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "061413e3277240798f943f26dc360292", "351d4995d4544d00a813437796fee253", 1649031363819L, "Province-2.1", 1649031363819L });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "f3012cba81a54aff85d2422a39235f36", "351d4995d4544d00a813437796fee253", 1649031363819L, "Province-2.2", 1649031363819L });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Id",
                table: "Countries",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_Id",
                table: "Provinces",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
