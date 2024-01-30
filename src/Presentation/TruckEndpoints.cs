using Application.Truck.Create;
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

            truck.MapGet("", () => Results.Ok());
            truck.MapPost("", (ISender sender, [FromBody]CreateTruckCommand command) => Results.Ok(sender.Send(command)));
            truck.MapPut("", () => Results.Ok());
            truck.MapPatch("", () => Results.Ok());
            truck.MapDelete("", () => Results.Ok());
        }
    }
}
