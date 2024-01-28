using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Presentation
{
    public static class TruckEndpoints
    {
        public static void MapTruckEndpoints(this IEndpointRouteBuilder app)
        {
            var truck = app.MapGroup("api/truck");

            truck.MapPost("", () => Results.Ok());
            truck.MapGet("", () => Results.Ok());
            truck.MapPut("", () => Results.Ok());
            truck.MapDelete("", () => Results.Ok());
        }
    }
}
