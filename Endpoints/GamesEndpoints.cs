using System;
using GamesProject.Data;
using GamesProject.dtos;
using GamesProject.Entities;
using GamesProject.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GamesProject.Endpoints;

public static class GamesEndpoints
{
    const string getGameEndpointName = "GetGame";
public static RouteGroupBuilder MapGameEndpoints (this WebApplication app){
var group = app.MapGroup("games");

group.MapGet("/", async (GameStoreContext dbContext) => 
    await dbContext.Games
    .Include(game => game.Genre)
    .Select(game => game.ToDto())
    .AsNoTracking()
    .ToListAsync());

group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => {
    Game? game = await dbContext.Games.FindAsync(id);
    return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
}).WithName(getGameEndpointName);

group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) => {

    Game game = newGame.ToEntity();

    dbContext.Games.Add(game);
    await dbContext.SaveChangesAsync();

    return Results.CreatedAtRoute(getGameEndpointName, new {id = game.ID}, game.ToGameDetailsDto());
}).WithParameterValidation();

group.MapPut("/{id}", async (int id, UpdateGameDto updateGame, GameStoreContext dbContext) =>{
    var existingGame = await dbContext.Games.FindAsync(id);

    if (existingGame is null){
        return Results.NotFound();
    }

    dbContext.Entry(existingGame)
    .CurrentValues
    .SetValues(updateGame.ToEntity(id));
    await dbContext.SaveChangesAsync();

    return Results.NoContent();
});

group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>{
    await dbContext.Games.Where(game => game.ID == id).ExecuteDeleteAsync();
    return Results.NoContent();
});

return group;
}

}
