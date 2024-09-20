using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class GeladeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ITEM",
                columns: table => new
                {
                    ID_ITEM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO_ITEM = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    UNIDADE = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CLASSIFICACAO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ANDAR = table.Column<int>(type: "int", nullable: false),
                    CONTAINER = table.Column<int>(type: "int", nullable: true),
                    POSICAO = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ITEM", x => x.ID_ITEM)
                        .Annotation("SqlServer:Clustered", false);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITEM");
        }
    }
}
