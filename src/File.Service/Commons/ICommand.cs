using MediatR;

namespace File.Service.Commons;

#pragma warning disable CA1040 // Avoid empty interfaces
public interface ICommand<out TResponse> : IRequest<TResponse>
#pragma warning restore CA1040 // Avoid empty interfaces
{
}
