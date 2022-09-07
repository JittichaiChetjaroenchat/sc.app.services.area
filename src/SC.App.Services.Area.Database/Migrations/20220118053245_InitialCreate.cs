using Microsoft.EntityFrameworkCore.Migrations;

namespace SC.App.Services.Area.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    code = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "areas",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    region_id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    province = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    district = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sub_district = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    postal_code = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_capital = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_perimeter = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas", x => x.id);
                    table.ForeignKey(
                        name: "FK_areas_regions_region_id",
                        column: x => x.region_id,
                        principalTable: "regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "id", "code", "description", "index" },
                values: new object[,]
                {
                    { "7c309c8d-f3b7-a3c4-2822-a51922d1ceaa", "N", "North", 1 },
                    { "6c0633dc-9339-d5e0-0896-e533fd692ce0", "NE", "North East", 2 },
                    { "6ec0e961-a8a9-505a-88a4-99df6458d276", "W", "West", 3 },
                    { "37f8610d-ad0c-411d-2f80-b84d143e1257", "C", "Central", 4 },
                    { "0ca03e3a-35fc-2c33-edf6-e5e9a32e94da", "E", "East", 5 },
                    { "dc98bc5d-83c9-07a7-28bd-082d1a47546e", "S", "South", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_areas_province_district_sub_district_postal_code",
                table: "areas",
                columns: new[] { "province", "district", "sub_district", "postal_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_areas_region_id",
                table: "areas",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_regions_code",
                table: "regions",
                column: "code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "areas");

            migrationBuilder.DropTable(
                name: "regions");
        }
    }
}
