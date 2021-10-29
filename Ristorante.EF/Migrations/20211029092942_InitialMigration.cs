using Microsoft.EntityFrameworkCore.Migrations;

namespace Ristorante.EF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 15, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Ruolo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Piatti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descrizione = table.Column<string>(maxLength: 500, nullable: false),
                    Tipologia = table.Column<string>(nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piatti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piatti_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Menu di Capodanno" },
                    { 2, "Cena Domenicale" },
                    { 3, "Pranzo Pasquale" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Ruolo", "Username" },
                values: new object[,]
                {
                    { 1, "12345", 0, "MRossi" },
                    { 2, "54321", 1, "LBianchi" }
                });

            migrationBuilder.InsertData(
                table: "Piatti",
                columns: new[] { "Id", "Descrizione", "MenuId", "Nome", "Prezzo", "Tipologia" },
                values: new object[,]
                {
                    { 1, "Spaghetti, Uovo, Guanciale etc", 1, "Pasta Carbonara", 6m, "Primo" },
                    { 6, "Tonno, Pomodorini, Olio etc", 1, "Tonno e pomodorini", 16m, "Secondo" },
                    { 7, "Patatine Fritte", 1, "Patate Fritte", 5m, "Contorno" },
                    { 12, "Sorbetto al limone", 1, "Sorbetto", 4m, "Dolce" },
                    { 2, "Pasta Sfoglia, Besciamella, Pomododoro etc", 2, "Lasagne al Forno", 10m, "Primo" },
                    { 5, "Pollo arrosto, Patate arrosto, Rosmarino etc", 2, "Pollo Arrosto", 15m, "Secondo" },
                    { 8, "Patate Arrosto", 2, "Patate Arrosto", 6m, "Contorno" },
                    { 11, "Cheesecake ai frutti di bosco", 2, "Cheesecake", 6m, "Dolce" },
                    { 3, "Orecchiette, Funghi Porcini, Noci etc", 3, "Orecchiette Funghi e Noci", 7m, "Primo" },
                    { 4, "Costata di Agnello, Patate arrosto etc", 3, "Agnello con Patate", 17m, "Secondo" },
                    { 9, "Salame, Prosciutto Cotto, Prosciutto Crudo etc", 3, "Tagliere", 7m, "Contorno" },
                    { 10, "Tiramisu al caffe", 3, "Tiramisu", 5m, "Dolce" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piatti_MenuId",
                table: "Piatti",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piatti");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
