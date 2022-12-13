using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpboolflix.Migrations
{
    /// <inheritdoc />
    public partial class CreateMoviesAndTvShowsTablesAndRemoveContentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorContent_Contents_ContentsId",
                table: "ActorContent");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryContent_Contents_ContentsId",
                table: "CategoryContent");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Contents_TvShowId",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contents",
                table: "Contents");

            migrationBuilder.RenameTable(
                name: "Contents",
                newName: "Content");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Content",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorContent_Content_ContentsId",
                table: "ActorContent",
                column: "ContentsId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryContent_Content_ContentsId",
                table: "CategoryContent",
                column: "ContentsId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Content_TvShowId",
                table: "Seasons",
                column: "TvShowId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorContent_Content_ContentsId",
                table: "ActorContent");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryContent_Content_ContentsId",
                table: "CategoryContent");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Content_TvShowId",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Content");

            migrationBuilder.RenameTable(
                name: "Content",
                newName: "Contents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contents",
                table: "Contents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorContent_Contents_ContentsId",
                table: "ActorContent",
                column: "ContentsId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryContent_Contents_ContentsId",
                table: "CategoryContent",
                column: "ContentsId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Contents_TvShowId",
                table: "Seasons",
                column: "TvShowId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
