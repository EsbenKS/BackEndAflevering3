using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AfleveringUge8.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    TranslationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Danish = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Swedish = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Norwegian = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    English = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    German = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Spanish = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Italian = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Croatian = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.TranslationID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations");
        }
    }
}
