using System;
using GamesProject.dtos;
using GamesProject.Entities;

namespace GamesProject.Mapping;

public static class GenreMapping
{
    public static GenresDto toDto (this Genre genre){
        return new GenresDto(genre.ID, genre.Name);
    }

}
