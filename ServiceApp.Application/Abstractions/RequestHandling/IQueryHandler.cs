using MediatR;
using ServiceApp.Domain.Abstractions;

namespace ServiceApp.Application.Abstractions.RequestHandling;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{
}
