using System;
using GamesProject.Data;
using GamesProject.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GamesProject.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenreEndpoints (this WebApplication app){
        var group = app.MapGroup("genres");
        group.MapGet("/", async (GameStoreContext dbContext)=>
        await dbContext.Genre
        .Select(genre => genre.toDto())
        .AsNoTracking()
        .ToListAsync());

        return group;
    }

}
