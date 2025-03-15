using System;
using GamesProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesProject.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
: DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genre => Set<Genre>();

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { ID = 1, Name = "Action" },
            new Genre { ID = 2, Name = "Adventure" },
            new Genre { ID = 3, Name = "RPG" },
            new Genre { ID = 4, Name = "Simulation" },
            new Genre { ID= 5, Name = "Strategy" },
            new Genre { ID = 6, Name = "Sports" },
            new Genre { ID = 7, Name = "Puzzle" },
            new Genre { ID = 8, Name = "IDle" },
            new Genre { ID = 9, Name = "Casual" },
            new Genre { ID = 10, Name = "Horror" },
            new Genre { ID = 11, Name = "Survival" },
            new Genre { ID = 12, Name = "Shooter" },
            new Genre { ID = 13, Name = "MMO" },
            new Genre { ID = 14, Name = "Racing" },
            new Genre { ID = 15, Name = "Fighting" },
            new Genre { ID = 16, Name = "Music" },
            new Genre { ID = 17, Name = "Educational" },
            new Genre { ID = 18, Name = "Card" },
            new Genre { ID = 19, Name = "Board" },
            new Genre { ID = 20, Name = "Arcade" },
            new Genre { ID = 21, Name = "Platformer" },
            new Genre { ID = 22, Name = "Roguelike" },
            new Genre { ID = 23, Name = "Metroidvania" },
            new Genre { ID = 24, Name = "PvP" },
            new Genre { ID = 25, Name = "PvE" },
            new Genre { ID = 26, Name = "Co-op" },
            new Genre { ID = 27, Name = "Singleplayer" },
            new Genre { ID = 28, Name = "Multiplayer" },
            new Genre { ID = 29, Name = "Local Multiplayer" },
            new Genre { ID = 30, Name = "Online Multiplayer" },
            new Genre { ID = 31, Name = "Cross-platform Multiplayer" }
        );
    }
}
