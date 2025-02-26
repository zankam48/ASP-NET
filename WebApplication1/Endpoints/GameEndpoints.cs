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
    public static WebApplication MapGamesEndpoints(this WebApplication app){
        
    }
}
