using System;
using GamesProject.dtos;
using GamesProject.Entities;

namespace GamesProject.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto dto) 
    {
        return new Game
        {
            Name = dto.Name,
            GenreID = dto.GenreId,
            Price = dto.Price,
            ReleaseDate = dto.ReleaseDate
        };
    }
    
    public static Game ToEntity(this UpdateGameDto dto, int id) 
    {
        return new Game
        {
            ID = id,
            Name = dto.Name,
            GenreID = dto.GenreId,
            Price = dto.Price,
            ReleaseDate = dto.ReleaseDate
        };
    }
    public static GameDto ToDto(this Game game)
    {
        return new
        (
        game.ID,
        game.Name,
        game.Genre!.Name,
        game.Price,
        game.ReleaseDate
        );
    }

    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new
        (
        game.ID,
        game.Name,
        game.GenreID,
        game.Price,
        game.ReleaseDate
        );
    }
}
