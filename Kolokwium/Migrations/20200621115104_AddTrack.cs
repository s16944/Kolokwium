using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class AddTrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MusicLabels_IdMusicLabel",
                table: "Albums");

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    IdTrack = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(maxLength: 20, nullable: false),
                    Duration = table.Column<float>(nullable: false),
                    IdMusicAlbum = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.IdTrack);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_IdMusicAlbum",
                        column: x => x.IdMusicAlbum,
                        principalTable: "Albums",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_IdMusicAlbum",
                table: "Tracks",
                column: "IdMusicAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_MusicLabels_IdMusicLabel",
                table: "Albums",
                column: "IdMusicLabel",
                principalTable: "MusicLabels",
                principalColumn: "IdMusicLabel",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MusicLabels_IdMusicLabel",
                table: "Albums");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_MusicLabels_IdMusicLabel",
                table: "Albums",
                column: "IdMusicLabel",
                principalTable: "MusicLabels",
                principalColumn: "IdMusicLabel",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
