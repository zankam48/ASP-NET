using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public record class UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(25)] string Genre, 
    [Range(1, 100)] decimal Price,  
    DateOnly ReleaseDate
); 
