﻿using MediatR;
using ServiceApp.Domain.Abstractions;

namespace ServiceApp.Application.Abstractions.RequestHandling;
public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}

