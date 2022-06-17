﻿using ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext

    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
        {

        }

        public DbSet <Genre> Genres { get; set; }
        public DbSet <Movie> Movies { get; set; }
        public DbSet <MovieGenre> MoviesGenres { get; set; }
        public DbSet <Trailer> Trailers { get; set; }
        public DbSet <Crew> Crews { get; set; }
        public DbSet <Cast> Casts { get; set; }




        //virtual method
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMoive);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);

        }

  
        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenre");
            builder.HasKey(x => new { x.MovieId, x.GenreId });
        }
        private void ConfigureMoive(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
