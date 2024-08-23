using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class IndividualEndpoints
    {
        public static void MapIndividualEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/individuals", async ([FromServices]IndividualService service) =>
            {
                return await service.GetIndividualsAsync();
            });

            routes.MapGet("/api/individuals/{idnp}", async ([FromServices] IndividualService service, string idnp) =>
            {
                var individual = await service.GetIndividualByIdAsync(idnp);
                return individual is not null ? Results.Ok(individual) : Results.NotFound();
            });

            routes.MapPost("/api/individuals", async ([FromServices] IndividualService service, [FromBody] Individual individual) =>
            {
                await service.AddIndividualAsync(individual);
                return Results.Created($"/api/individuals/{individual.IDNP}", individual);
            });

            routes.MapPut("/api/individuals/{idnp}", async ([FromServices] IndividualService service, string idnp, [FromBody] Individual individual) =>
            {
                if (idnp != individual.IDNP) return Results.BadRequest();
                await service.UpdateIndividualAsync(individual);
                return Results.NoContent();
            });

            routes.MapDelete("/api/individuals/{idnp}", async ([FromServices] IndividualService service, string idnp) =>
            {
                await service.DeleteIndividualAsync(idnp);
                return Results.NoContent();
            });
        }
    }
}
