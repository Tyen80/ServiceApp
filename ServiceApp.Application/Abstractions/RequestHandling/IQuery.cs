using MediatR;
using ServiceApp.Domain.Abstractions;

namespace ServiceApp.Application.Abstractions.RequestHandling;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
