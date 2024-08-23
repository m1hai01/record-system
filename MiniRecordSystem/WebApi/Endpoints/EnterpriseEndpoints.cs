using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{

    public static class EnterpriseEndpoints
    {
        public static void MapEnterpriseEndpoints(this IEndpointRouteBuilder routes)
        {
            
            routes.MapGet("/api/enterprises", async ([FromServices]EnterpriseService service) =>
            {
                return await service.GetEnterprisesAsync();
            });

            routes.MapGet("/api/enterprises/{idno}", async ([FromServices] EnterpriseService service, string idno) =>
            {
                var enterprise = await service.GetEnterpriseByIdAsync(idno);
                return enterprise is not null ? Results.Ok(enterprise) : Results.NotFound();
            });

            routes.MapPost("/api/enterprises", async ([FromServices] EnterpriseService service, [FromBody] Enterprise enterprise) =>
            {
                await service.AddEnterpriseAsync(enterprise);
                return Results.Created($"/api/enterprises/{enterprise.IDNO}", enterprise);
            });

            routes.MapPut("/api/enterprises/{idno}", async ([FromServices] EnterpriseService service, string idno, Enterprise enterprise) =>
            {
                if (idno != enterprise.IDNO) return Results.BadRequest();
                await service.UpdateEnterpriseAsync(enterprise);
                return Results.NoContent();
            });

            routes.MapDelete("/api/enterprises/{idno}", async ([FromServices] EnterpriseService service, string idno) =>
            {
                await service.DeleteEnterpriseAsync(idno);
                return Results.NoContent();
            });
        }
    }
}
