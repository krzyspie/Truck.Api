using Application.Common;
using Application.Truck.Create;
using Application.Truck.Delete;
using Application.Truck.Get;
using Application.Truck.Update;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation
{
    public static class TruckEndpoints
    {
        public static void MapTruckEndpoints(this IEndpointRouteBuilder app)
        {
            var truck = app.MapGroup("api/truck");

            truck.MapGet("{id}", GetById)
                .Produces(200, typeof(TruckResponse));

            truck.MapGet("/search", Search)
                .Produces(200, typeof(IEnumerable<TruckResponse>));

            truck.MapPost("", Create)
                .Produces(201);

            truck.MapPut("", Update)
                .Produces(204);

            truck.MapPatch("", UpdateStatus)
                .Produces(204);

            truck.MapDelete("{id}", Delete)
                .Produces(204);

            async Task<IResult> GetById(ISender sender, int id)
            {
                var truck = await sender.Send(new GetTruckByIdQuery(id));

                return Results.Ok(truck);
            }

            async Task<IResult> Search(ISender sender, string filterBy, string filterValue, string sortBy, string sortDirection)
            {
                var truck = await sender.Send(new GetTrucksQuery(filterBy, filterValue, sortBy, sortDirection));

                return Results.Ok(truck);
            }

            async Task<IResult> Create(ISender sender, [FromBody] CreateTruckCommand command)
            {
                var id = await sender.Send(command);

                return Results.Created($"api/truck/{id}", id);
            }

            async Task<IResult> Update(ISender sender, [FromBody] UpdateTruckCommand command)
            {
                await sender.Send(command);

                return Results.NoContent();
            }

            async Task<IResult> UpdateStatus(ISender sender, [FromBody] UpdateTruckStatusCommand command)
            {
                await sender.Send(command);

                return Results.NoContent();
            }

            async Task<IResult> Delete(ISender sender, int id)
            {
                await sender.Send(new DeleteTruckCommand(id));

                return Results.NoContent();
            }
        }
    }
}
