using GtMotive.Renting.Common.Domain;
using MediatR;

namespace GtMotive.Renting.Common.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;