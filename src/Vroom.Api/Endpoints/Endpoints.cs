using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vroom.Shareable.DTOs;
using Vroom.Shareable.Exceptions;
using Vroom.Shareable.Requests.Bike;
using Vroom.Shareable.Requests.DeliveryPerson;
using Vroom.Shareable.Requests.Rental;
using Vroom.Shareable.Responses.Bike;
using Vroom.Shareable.Responses.Rental;

namespace Vroom.Api.Endpoints;

public static class Endpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/motos", CreateBikeAsync)
           .WithSummary("Cadastrar uma nova moto")
           .WithTags("motos")
           .Accepts<BikeDTO>("application/json")
           .Produces(StatusCodes.Status201Created)
           .Produces<ValidationErrorResponse>(StatusCodes.Status400BadRequest);

        app.MapGet("/motos", GetBikesByPlateAsync)
           .WithSummary("Consultar motos existentes")
           .WithTags("motos")
           .Produces<List<BikeDTO>>(StatusCodes.Status200OK);

        app.MapPut("/motos/{id}/placa", UpdateBikeAsync)
           .WithSummary("Modificar a placa de uma moto")
           .WithTags("motos")
           .Produces(StatusCodes.Status200OK)
           .Produces<ValidationErrorResponse>(StatusCodes.Status400BadRequest);

        app.MapGet("/motos/{id}", GetBikeByIdAsync)
           .WithSummary("Consultar motos existentes por id")
           .WithTags("motos")
           .Produces<BikeDTO>(StatusCodes.Status200OK)
           .Produces<ValidationErrorResponse>(StatusCodes.Status400BadRequest)
           .Produces<ValidationErrorResponse>(StatusCodes.Status404NotFound);

        app.MapDelete("/motos/{id}", DeleteAsync)
           .WithSummary("Remover uma moto")
           .WithTags("motos")
           .Produces(StatusCodes.Status200OK)
           .Produces<ValidationErrorResponse>(StatusCodes.Status400BadRequest);

        app.MapPost("/entregadores", CreateDeliveryPersonAsync)
           .WithSummary("Cadastrar entregador")
           .WithTags("entregadores")
           .Accepts<DeliveryPersonDTO>("application/json")
           .Produces(StatusCodes.Status201Created)
           .Produces<ValidationErrorResponse>(StatusCodes.Status400BadRequest);

        app.MapPost("/entregadores/{id}/cnh", UpdateLicensePlateAsync)
           .WithSummary("Enviar foto da CNH")
           .WithTags("entregadores")
           .Produces(StatusCodes.Status201Created)
           .Produces<ValidationErrorResponse>(StatusCodes.Status400BadRequest);

        app.MapPost("/locacao", RentalBikeAsync)
           .WithSummary("Alugar uma moto")
           .WithTags("locacao")
           .Accepts<RentalDTO>("application/json")
           .Produces(StatusCodes.Status201Created)
           .Produces<ValidationErrorResponse>(StatusCodes.Status400BadRequest);

        app.MapGet("/locacao/{id}", GetRentalByIdAsync)
           .WithSummary("Consultar locação por id")
           .WithTags("locacao")
           .Produces<RentalDTO>(StatusCodes.Status200OK)
           .Produces<ValidationErrorResponse>(StatusCodes.Status400BadRequest)
           .Produces<ValidationErrorResponse>(StatusCodes.Status404NotFound);

        app.MapPut("/locacao/{id}/devolucao", EarlyReturnAsunc)
           .WithSummary("Informar data de devolução e calcular valor")
           .WithTags("locacao")
           .Produces(StatusCodes.Status200OK)
           .Produces<ValidationErrorResponse>(StatusCodes.Status400BadRequest);
    }

    private static async Task<IResult> CreateBikeAsync([FromServices] IMediator mediator, BikeDTO bikeDTO)
    {
        return await mediator.Send(new CreateBikeRequest() { BikeDTO = bikeDTO });
    }

    private static async Task<GetAllBikeResponse> GetBikesByPlateAsync(
        [FromServices] IMediator mediator)
    {
        return await mediator.Send(new GetAllBikesRequest());
    }

    private static async Task<UpdateBikeResponse> UpdateBikeAsync([FromServices] IMediator mediator, [FromRoute] Guid id, [FromBody] PlateDTO plateDTO)
    {
        return await mediator.Send(new UpdateBikeRequest() { BikeId = id, Plate = plateDTO });
    }

    private static async Task<GetBikeResponse> GetBikeByIdAsync([FromServices] IMediator mediator, [FromRoute] Guid id)
    {
        return await mediator.Send(new GetBikeRequest() { BikeId = id });
    }

    private static async Task<DeleteBikeResponse> DeleteAsync([FromServices] IMediator mediator, [FromRoute] Guid id)
    {
        return await mediator.Send(new DeleteBikeRequest() { BikeId = id });
    }

    private static async Task<IResult> CreateDeliveryPersonAsync([FromServices] IMediator mediator, DeliveryPersonDTO deliveryPersonDTO)
    {
        return await mediator.Send(new CreateDeliveryPersonRequest() { DeliveryPersonDTO = deliveryPersonDTO });
    }

    private static async Task<IResult> UpdateLicensePlateAsync([FromServices] IMediator mediator, Guid Id,  string licensePlate)
    {
        return await mediator.Send(new UpdateLicensePlateRequest() { DeliveryPersonId = Id, LicensePlate = licensePlate });
    }

    private static async Task<IResult> RentalBikeAsync([FromServices] IMediator mediator, RentalDTO rentalDTO)
    {
        return await mediator.Send(new RentalRequest() { RentalDTO = rentalDTO });
    }

    private static async Task<GetRentalResponse> GetRentalByIdAsync([FromServices] IMediator mediator, [FromRoute] Guid id)
    {
        return await mediator.Send(new GetRentalRequest() { RentalId = id });
    }

    private static async Task<IResult> EarlyReturnAsunc([FromServices] IMediator mediator, [FromBody] Guid id, DateTime returnDate)
    {
        return await mediator.Send(new UpdateRentalRequest() { RentalId = id, ReturnDate = returnDate });
    }
}