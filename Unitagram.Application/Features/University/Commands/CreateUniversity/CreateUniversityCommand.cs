using MediatR;

namespace Unitagram.Application.Features.University.Commands.CreateUniversity;

public record CreateUniversityCommand(
    string Domain = "",
    string Province = "",
    string Name = ""
) : IRequest<Unit>
{
    public Domain.University ToUniversity()
    {
        return new Domain.University()
        {
            Domain = Domain,
            Province = Province,
            Name = Name,
        };
    }
}