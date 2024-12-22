using GtMotive.Renting.Common.Domain;
using MediatR;

namespace GtMotive.Renting.Common.Application.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;