
using WebApplication1.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
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

// GET /games
app.MapGet("games", () => games);

// GET /games/{id}
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
.WithName(GetGameEndpointName);

// POST /games
app.MapPost("games", (CreateGameDto newGame) => {
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});

app.Run();
