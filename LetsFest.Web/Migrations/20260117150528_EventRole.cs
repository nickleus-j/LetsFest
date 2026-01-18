using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace LetsFest.Web.Migrations
{
    /// <inheritdoc />
    public partial class EventRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Initiator",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOn",
                table: "Event",
                newName: "ProposedStartDateTime");

            migrationBuilder.AddColumn<string>(
                name: "InitiatorId",
                table: "Event",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProposedEndDateTime",
                table: "Event",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventRole",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    inUse = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRole", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventRole");

            migrationBuilder.DropColumn(
                name: "InitiatorId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ProposedEndDateTime",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "ProposedStartDateTime",
                table: "Event",
                newName: "LastModifiedOn");

            migrationBuilder.AddColumn<long>(
                name: "Initiator",
                table: "Event",
                type: "bigint",
                nullable: true);
        }
    }
}
