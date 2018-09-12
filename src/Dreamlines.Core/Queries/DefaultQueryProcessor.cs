using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Dreamlines.Dtos;
using Dreamlines.Models;
using Dreamlines.Utils;

namespace Dreamlines.Data {
    
    public class DefaultQueryProcessor: IQueryProcessor {

        public DefaultQueryProcessor(IServiceProvider serviceProvider) {
            AssertArguments.NotNull(serviceProvider, nameof(serviceProvider));
            ServiceProvider = serviceProvider;
        }
        
        protected IServiceProvider ServiceProvider { get; }


        [DebuggerStepThrough]
        public virtual async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query) {
            AssertArguments.NotNull(query, nameof(query));
            
            // finding the query handler by using query type. we will
            // throw argument exception when no handler registered for
            // specified query type.
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            // TODO: using service provider to resolve query handler dependencies.
            var handler = ServiceProvider.GetService(handlerType) as IQueryHandler<TResult>;
            AssertArguments.IsTrue(
               handler != null,
               $"'{handlerType.Name}' is not a valid query handler type.",
               "query"
            );
            return await handler.ExecuteAsync(query);
        }

    }
    
}