using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLibrary.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Directors (Name) Values ('Ingmar BERGMAN')");
            
            migrationBuilder
                .Sql("INSERT INTO Directors (Name) Values ('Robert BRESSON')");
            
            migrationBuilder
                .Sql("INSERT INTO Directors (Name) Values ('Luis BUNUEL')");
            
            
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, DirectorId) Values ('The Seventh Seal', (SELECT Id FROM Directors WHERE Name = 'Ingmar BERGMAN'))");
            
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, DirectorId) Values ('The Virgin Spring', (SELECT Id FROM Directors WHERE Name = 'Ingmar BERGMAN'))");
            
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, DirectorId) Values ('Hour Of The Wolf', (SELECT Id FROM Directors WHERE Name = 'Ingmar BERGMAN'))");
            
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, DirectorId) Values ('Pickpocket', (SELECT Id FROM Directors WHERE Name = 'Robert BRESSON'))");
            
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, DirectorId) Values ('A Man Escaped', (SELECT Id FROM Directors WHERE Name = 'Robert BRESSON'))");
            
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, DirectorId) Values ('Mouchette', (SELECT Id FROM Directors WHERE Name = 'Robert BRESSON'))");
            
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, DirectorId) Values ('Los Olvidados', (SELECT Id FROM Directors WHERE Name = 'Luis BUNUEL'))");
            
            migrationBuilder
                .Sql("INSERT INTO Movies (Name, DirectorId) Values ('Nazarin', (SELECT Id FROM Directors WHERE Name = 'Luis BUNUEL'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");

        }
    }
}
