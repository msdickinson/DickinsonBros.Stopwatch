using DickinsonBros.Stopwatch.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DickinsonBros.Stopwatch.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddStopwatchService(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddTransient<IStopwatchService, StopwatchService>();

            return serviceCollection;
        }
    }
}
