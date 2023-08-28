using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankTransactionsApi.Migrations
{
    /// <inheritdoc />
    public partial class Deneme4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInfos",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CustomerAge = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfos", x => x.CustomerId);
                    table.CheckConstraint("CK_CustomerInfos_Type", "[Type] IN ('Normal', 'Senior', 'Corporate')");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInfos");
        }
    }
}
