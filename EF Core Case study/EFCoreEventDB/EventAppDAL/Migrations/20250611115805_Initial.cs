using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAppDAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EventCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => x.EventId);
                    table.CheckConstraint("CK_EventDetails_Status", "[Status] IN ('Active', 'In-Active')");
                });

            migrationBuilder.CreateTable(
                name: "SpeakersDetails",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeakerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakersDetails", x => x.SpeakerId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    EmailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.EmailId);
                    table.CheckConstraint("CK_UserInfo_Role", "[Role] IN ('Admin', 'Participant')");
                });

            migrationBuilder.CreateTable(
                name: "SessionInfos",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    SessionTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpeakerId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionInfos", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_SessionInfos_EventDetails_EventId",
                        column: x => x.EventId,
                        principalTable: "EventDetails",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionInfos_SpeakersDetails_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "SpeakersDetails",
                        principalColumn: "SpeakerId");
                });

            migrationBuilder.CreateTable(
                name: "ParticipantEventDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantEmailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    IsAttended = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantEventDetails", x => x.Id);
                    table.CheckConstraint("CK_ParticipantEventDetails_IsAttended", "[IsAttended] IN ('Yes', 'No')");
                    table.ForeignKey(
                        name: "FK_ParticipantEventDetails_EventDetails_EventId",
                        column: x => x.EventId,
                        principalTable: "EventDetails",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantEventDetails_UserInfos_ParticipantEmailId",
                        column: x => x.ParticipantEmailId,
                        principalTable: "UserInfos",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantEventDetails_EventId",
                table: "ParticipantEventDetails",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantEventDetails_ParticipantEmailId",
                table: "ParticipantEventDetails",
                column: "ParticipantEmailId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfos_EventId",
                table: "SessionInfos",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfos_SpeakerId",
                table: "SessionInfos",
                column: "SpeakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantEventDetails");

            migrationBuilder.DropTable(
                name: "SessionInfos");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "EventDetails");

            migrationBuilder.DropTable(
                name: "SpeakersDetails");
        }
    }
}
