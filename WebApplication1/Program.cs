using WebApplication1.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// GET /games

app.MapGamesEndpoints();
app.Run();
