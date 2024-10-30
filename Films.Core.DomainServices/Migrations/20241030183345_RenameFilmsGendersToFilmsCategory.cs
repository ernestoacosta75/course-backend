using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Films.Core.DomainServices.Migrations
{
    /// <inheritdoc />
    public partial class RenameFilmsGendersToFilmsCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Rename the existing table in the database
            migrationBuilder.RenameTable(
                name: "FilmsGenders",       // Current name in the database
                newName: "FilmsCategories"  // New desired name
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the table name change in case of rollback
            migrationBuilder.RenameTable(
                name: "FilmsCategories",    // New name
                newName: "FilmsGenders"     // Original name in the database
            );
        }
    }
}
