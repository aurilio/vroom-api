using MediatR;
using Microsoft.AspNetCore.Http;
using Vroom.Shareable.Exceptions;
using Vroom.Shareable.Requests.Bike;

namespace Vroom.Domain.Handlers;

public class CreateBikeHandler : IRequestHandler<CreateBikeRequest, IResult>
{
    public async Task<IResult> Handle(CreateBikeRequest request, CancellationToken cancellationToken)
    {
        // Aqui entra a lógica de negócio para o cadastro da moto.
        // Por exemplo, salvar a moto no banco de dados.

        if (request.BikeDTO == null)
        {
            return Results.BadRequest(new DomainException("Dados inválidos"));
        }

        // Se a operação for bem-sucedida, retornar 201 Created
        return Results.Created($"/motos/{request.BikeDTO.Identifier}", request.BikeDTO);
    }
}
