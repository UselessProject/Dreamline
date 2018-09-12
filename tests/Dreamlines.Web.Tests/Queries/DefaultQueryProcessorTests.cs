using System;
using Dreamlines.Data;

namespace Dreamlines.Web.Tests.Queries {

    public class DefaultQueryProcessorTests : BaseQueryProcessorTests {

        protected override IQueryProcessor CreateProcessor(IServiceProvider serviceProvider) => 
            new DefaultQueryProcessor(serviceProvider);

    }

}