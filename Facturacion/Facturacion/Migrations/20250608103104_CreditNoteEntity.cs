using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturacion.Migrations
{
    public partial class CreditNoteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Motive = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditNotes_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_BillId",
                table: "CreditNotes",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_Document_BillId",
                table: "CreditNotes",
                columns: new[] { "Document", "BillId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditNotes");
        }
    }
}
