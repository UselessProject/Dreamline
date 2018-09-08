using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Dreamlines.Utils;

namespace Dreamlines.Data {
    
    public class DefaultQueryProcess: IQueryProcessor {

        private readonly Dictionary<Type, Type> _handlers = new Dictionary<Type, Type>();

        public virtual IQueryProcessor AddHandler<TQuery, THandler>() {            
            _handlers.Add(typeof(TQuery), typeof(THandler));
            return this;
        }

        [DebuggerStepThrough]
        public virtual async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query) {
            AssertArguments.NotNull(query, nameof(query));
            
            var queryType = query.GetType();
            // finding the query handler by using query type. we will
            // throw argument exception when no handler registered for
            // specified query type.
            AssertArguments.IsTrue(
                _handlers.TryGetValue(queryType, out var handlerType),
                $"No handler found for query of type '{queryType.Name}'.",
                nameof(query)
            );
            // creating a new instance of query handler and executing
            // the query asynchronously.
            var handler = Activator.CreateInstance(handlerType) as IQueryHandler<TResult>;
            AssertArguments.IsTrue(
                handler != null,
                $"'{handlerType.Name}' is not a valid query handler type.",
                "query"
            );
            return await handler.ExecuteAsync(query);
        }

    }
    
}