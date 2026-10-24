using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;

namespace WebApplication1.Endpoints;

public static class GenresEndpoints
{
    public static void MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");

        // GET /genres

        group.MapGet("/", async (GameStoreContext dbContext) =>
        await dbContext.Genres
                        .Select(genre => new GenreDto(genre.Id, genre.Name))
                        .AsNoTracking()
                        .ToListAsync()
        );
    }
}
