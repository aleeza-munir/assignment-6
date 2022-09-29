using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Assignment6.Models
{
    public class MovieCharactersDBContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public MovieCharactersDBContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=N-NO-01-01-7896\\SQLEXPRESS;Initial Catalog=MovieCharacterDB;Integrated Security=True;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Character>().HasData(new Character { Id = 1, FullName = "Hulk", Alias = "Strongest Avenger", Gender = "M", Picture = "https://th.bing.com/th/id/R.e9fc32d24fa6fde909bebf55074d7333?rik=%2bqVK3hYxz7Zl4w&pid=ImgRaw&r=0" });
            modelBuilder.Entity<Character>().HasData(new Character { Id = 2, FullName = "Captain America", Alias = "Cap", Gender = "M", Picture = "https://hdcraft.club/wp-content/uploads/2019/11/captain-america-full-hd-34.jpg" });
            modelBuilder.Entity<Character>().HasData(new Character { Id = 3, FullName = "Iron Man", Alias = "IM", Gender = "M", Picture = "https://preview.redd.it/ly5rmonemmo01.jpg?auto=webp&s=6ac462d6711833d0fce33d7699b1752271fe08b1" });

            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 1, MovieTitle = "Avengers Age of Ultron",  Genre = "Action", ReleaseYear = 2010, Director = "Russo Brothers", Picture = "https://tse2.mm.bing.net/th/id/OIP.gv3p5fY2oDpk8bFvXAPJEQHaEo?pid=ImgDet&rs=1", Trailer = "https://www.youtube.com/watch?v=U2fO094Kk58",  FranchiseId = 1 });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 2, MovieTitle = "Avengers Endgame", Genre = "Comedy", ReleaseYear = 2018, Director = "Russo Brothers", Picture = "https://tse4.mm.bing.net/th/id/OIP.1C8EomfdMj6xlDtR6WK5OQHaEK?pid=ImgDet&rs=1", Trailer = "https://www.youtube.com/watch?v=hA6hldpSTF8",  FranchiseId = 1 });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 3, MovieTitle = "Lord of The Rings 1", Genre = "Sci-Fi", ReleaseYear = 2012, Director = "Some Lord", Picture = "https://tse2.mm.bing.net/th/id/OIP.aB0SWxNACEUz_lVtBFroyQHaEo?pid=ImgDet&rs=1", Trailer = "https://www.youtube.com/watch?v=uYnQDsaxHZU",  FranchiseId = 1 });

            modelBuilder.Entity<Franchise>().HasData(new Franchise() { Id = 1, Name = "Marvel Cinematic Universe", Description = "Marvel Comics turned into movies"});
            modelBuilder.Entity<Franchise>().HasData(new Franchise() { Id = 2, Name = "Lord of The Rings", Description = "Some Lords of Some Rings"});
            
            // Seed m2m coach-certification. Need to define m2m and access linking table
            modelBuilder.Entity<Movie>()
                .HasMany(p => p.Characters)
                .WithMany(m => m.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCharacters",
                    r => r.HasOne<Character>().WithMany().HasForeignKey("CharactersId"),
                    l => l.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                    je =>
                    {
                        je.HasKey("MoviesId", "CharactersId");
                        je.HasData(
                            new { MoviesId = 1, CharactersId = 1 },
                            new { MoviesId = 1, CharactersId = 2 },
                            new { MoviesId = 2, CharactersId = 1},
                            new { MoviesId = 2, CharactersId = 3},
                            new { MoviesId = 3, CharactersId = 3}

                        );
                    });
        }


    }
}
