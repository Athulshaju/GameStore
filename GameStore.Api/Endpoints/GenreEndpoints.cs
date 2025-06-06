using System;
using System.Threading.Tasks;
using GameStore.Api.Data;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");

        group.MapGet("/",async (GameStoreContext dbContext) =>
            await dbContext.Genre
            .Select(genre => genre.ToDto())
            .AsNoTracking()
            .ToListAsync());
        return group;
    }
}
