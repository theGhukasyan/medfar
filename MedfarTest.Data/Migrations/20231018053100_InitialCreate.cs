using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedfarTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SearchableSummaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummaryDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummaryExtendedDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearchSoundex1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearchSoundex2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch10 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch11 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch12 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchableSummarySearch13 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Considerations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPatient = table.Column<bool>(type: "bit", nullable: false),
                    LoginId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArchivalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchivedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTask = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    IsGroupTask = table.Column<bool>(type: "bit", nullable: true),
                    DocumentPatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeTaskLookupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PriorityLookupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FromContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LookupTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LookupTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LookupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LookupPosition = table.Column<int>(type: "int", nullable: true),
                    LookupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnValueID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FrValueID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnLocalizedValueID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FrLocalizedValueID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LookupTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "IndividualMessages");

            migrationBuilder.DropTable(
                name: "Lookups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
