using Dreamlines.Data;
using Dreamlines.Dtos;
using Dreamlines.Utils;

namespace Microsoft.Extensions.DependencyInjection {
    
    public static class ServiceCollectionExtensions {

        public static IServiceCollection AddQuery<TQuery, TResult, TQueryHandler>(this IServiceCollection source)
            where TQuery: IQuery<TResult>
            where TQueryHandler: class, IQueryHandler<TQuery, TResult> {
            AssertArguments.NotNull(source, nameof(source));
            return source.AddScoped<IQueryHandler<TQuery, TResult>, TQueryHandler>();
        }

    }
    
}