using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Films.Core.DomainServices.Migrations
{
    /// <inheritdoc />
    public partial class RenameGenderToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Categories",    // The new table name to revert from
                newName: "Genders"     // Original table name
            );
        }
    }
}
