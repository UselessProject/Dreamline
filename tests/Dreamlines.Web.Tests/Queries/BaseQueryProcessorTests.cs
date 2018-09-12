using System;
using System.Threading.Tasks;
using Dreamlines.Data;
using Dreamlines.Dtos;
using FluentAssertions;
using Xunit;
using Moq;

namespace Dreamlines.Web.Tests.Queries {

    public abstract class BaseQueryProcessorTests {

        protected abstract IQueryProcessor CreateProcessor(IServiceProvider serviceProvider);

        [Fact]
        public void ProcessAsyncShouldThrowErrorWhenQueryIsNull() {
            // arrange
            var serviceProvider = new Mock<IServiceProvider>();
            var processor = CreateProcessor(serviceProvider.Object);
            Func<Task<int>> action = () => processor.ProcessAsync<int>(null);

            // act & assert
            action
                .Should().Throw<ArgumentNullException>()
                .Which.ParamName.Should().Be("query");
        }

        [Fact]
        public void ProcessAsyncShouldThrowErrorWhenQueryHandlerNotRegistered() {
            // arrange
            var serviceProvider = new Mock<IServiceProvider>();
            var processor = CreateProcessor(serviceProvider.Object);
            Func<Task<int>> action = () => processor.ProcessAsync(new DummyQuery());

            // act & assert
            action
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("query");
        }

        [Fact]
        public void ProcessAsyncShouldThrowErrorWhenQueryHandlerIsNotValidQueryHandler() {
            // arrange
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(s => s.GetService(typeof(IQueryHandler<DummyQuery, int>)))
                .Returns(null);
            
            var processor = CreateProcessor(serviceProvider.Object);

            Func<Task<int>> action = () => processor.ProcessAsync(new DummyQuery());

            // act & assert
            action
                .Should().Throw<ArgumentException>()
                .Which.ParamName.Should().Be("query");
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(5, 3)]
        public async Task ProcessAsyncShouldReturnTheSum(int left, int right) {
            // arrange
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(s => s.GetService(typeof(IQueryHandler<SumQuery, int>)))
                .Returns(new SumQueryHandler());
            
            var processor = CreateProcessor(serviceProvider.Object);

            // act
            var result = await processor.ProcessAsync(new SumQuery {
                Left = left,
                Right = right
            });

            // assert
            result.Should().Be(left + right);
        }

        #region [Helper]

        class DummyQuery : IQuery<int> { }

        class InvalidQueryHandler { }

        class SumQuery : IQuery<int> {
            public int Right { get; set; }
            public int Left { get; set; }
        }

        private class SumQueryHandler : IQueryHandler<SumQuery, int> {

            public Task<int> ExecuteAsync(SumQuery query) {
                return Task.FromResult(query.Left + query.Right);
            }

            Task<int> IQueryHandler<int>.ExecuteAsync(IQuery<int> query) {
                return ExecuteAsync((SumQuery) query);
            }

        }

        #endregion

    }

}