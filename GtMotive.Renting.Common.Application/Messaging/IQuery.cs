using GtMotive.Renting.Common.Domain;
using MediatR;

namespace GtMotive.Renting.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;