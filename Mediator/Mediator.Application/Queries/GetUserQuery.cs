using Mediator.Domain;
using MediatR;

namespace Mediator.Application.Queries;

public record GetUserQuery(int Id) : IRequest<User>;
