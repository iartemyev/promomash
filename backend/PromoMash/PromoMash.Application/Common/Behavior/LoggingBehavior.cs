using MediatR;
using Serilog;

namespace PromoMash.Application.Common.Behavior;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var requestName = typeof(TRequest).Name;
        
        Log.Information("Request '{Name}' begin", requestName);
        
        var response = await next();

        return response;
    }
}