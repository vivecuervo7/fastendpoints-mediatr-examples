using Example_Mediator.Domain;
using MediatR;

namespace Example_Mediator.Application.Queries;

public record GetUserQuery(int Id) : IRequest<User>;
