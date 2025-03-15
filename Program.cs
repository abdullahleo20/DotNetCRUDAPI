using GamesProject.Endpoints;
using GamesProject.Data;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();

app.MapGameEndpoints();
app.MapGenreEndpoints();
await app.MigrateDBAsync();
app.Run();
