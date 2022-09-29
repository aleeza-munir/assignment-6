using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment6.Migrations
{
    public partial class Created_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.CreateTable(
                name: "CoachCertification",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    CharactersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachCertification", x => new { x.MoviesId, x.CharactersId });
                    table.ForeignKey(
                        name: "FK_CoachCertification_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachCertification_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "Picture" },
                values: new object[,]
                {
                    { 1, "Strongest Avenger", "Hulk", "M", "https://th.bing.com/th/id/R.e9fc32d24fa6fde909bebf55074d7333?rik=%2bqVK3hYxz7Zl4w&pid=ImgRaw&r=0" },
                    { 2, "Cap", "Captain America", "M", "https://hdcraft.club/wp-content/uploads/2019/11/captain-america-full-hd-34.jpg" },
                    { 3, "IM", "Iron Man", "M", "https://preview.redd.it/ly5rmonemmo01.jpg?auto=webp&s=6ac462d6711833d0fce33d7699b1752271fe08b1" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Marvel Comics turned into movies", "Marvel Cinematic Universe" },
                    { 2, "Some Lords of Some Rings", "Lord of The Rings" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "MovieTitle", "Picture", "ReleaseYear", "Trailer" },
                values: new object[] { 1, "Russo Brothers", 1, "Action", "Avengers Age of Ultron", "https://tse2.mm.bing.net/th/id/OIP.gv3p5fY2oDpk8bFvXAPJEQHaEo?pid=ImgDet&rs=1", 2010, "https://www.youtube.com/watch?v=U2fO094Kk58" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "MovieTitle", "Picture", "ReleaseYear", "Trailer" },
                values: new object[] { 2, "Russo Brothers", 1, "Comedy", "Avengers Endgame", "https://tse4.mm.bing.net/th/id/OIP.1C8EomfdMj6xlDtR6WK5OQHaEK?pid=ImgDet&rs=1", 2018, "https://www.youtube.com/watch?v=hA6hldpSTF8" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "MovieTitle", "Picture", "ReleaseYear", "Trailer" },
                values: new object[] { 3, "Some Lord", 1, "Sci-Fi", "Lord of The Rings 1", "https://tse2.mm.bing.net/th/id/OIP.aB0SWxNACEUz_lVtBFroyQHaEo?pid=ImgDet&rs=1", 2012, "https://www.youtube.com/watch?v=uYnQDsaxHZU" });

            migrationBuilder.InsertData(
                table: "CoachCertification",
                columns: new[] { "CharactersId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachCertification_CharactersId",
                table: "CoachCertification",
                column: "CharactersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachCertification");

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharactersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MoviesId",
                table: "CharacterMovie",
                column: "MoviesId");
        }
    }
}
