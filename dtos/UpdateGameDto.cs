namespace GamesProject.dtos;

public record class UpdateGameDto(
string Name,
int GenreId,
decimal Price,
DateOnly ReleaseDate);

