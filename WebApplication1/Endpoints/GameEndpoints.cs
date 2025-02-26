using System;
using WebApplication1.Dtos;

namespace WebApplication1.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndpointName = "GetGame";

    // we'll never reconstructing the list from scratch so we just use readonly
    private static readonly List<GameDto> games = [
        new (
            1, "Genshin Impact", "Fighting", 0M, new DateOnly(2020,8,12)
        ),
        new (
            2, "Final Fantasy", "RPG", 30M, new DateOnly(2010,9,21)
        ),
        new (
            3, "GTA VII", "Open World", 60M, new DateOnly(2024,8,12)
        )
    ];

    // extension methods -> use "this"
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app){
        var group = app.MapGroup("games");
        group.MapGet("/", () => games);

        // GET /games/{id}
        group.MapGet("/{id}", (int id) => {
            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame) => {

            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
        })
        .WithParameterValidation();

        // PUT /games/{id}
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) => {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1) {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE /games/{id}
        group.MapDelete("/{id}", (int id) => {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
