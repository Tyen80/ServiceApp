﻿using MediatR;
using ServiceApp.Domain.Abstractions;

namespace ServiceApp.Application.Abstractions.RequestHandling;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse>
{
}
