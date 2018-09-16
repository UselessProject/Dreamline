using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dreamlines.Dtos;
using Dreamlines.Web;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Dreamlines.Tests.Integrations {

    public class SalesUnitIntegrationTests : 
        IClassFixture<DreamlinesAppFactory<Startup, DreamlinesTestDbInitializer>> {

        public SalesUnitIntegrationTests(DreamlinesAppFactory<Startup, DreamlinesTestDbInitializer> factory) {
            Factory = factory;
        }

        protected DreamlinesAppFactory<Startup, DreamlinesTestDbInitializer> Factory { get; }

        [Fact]
        public async Task GetSummaryOfSalesUnit() {
            // arrange
            var query = new SalesUnitQuery {
                Skip = 0,
                Limit = 100,
                FromDate = DateTime.UtcNow.AddDays(-3),
                ToDate = DateTime.UtcNow
            };

            // act
            var summary = await GetSalesUnitSummaryAsync(query);
           
            // assert
            summary.Skip.Should().Be(0);
            summary.Limit.Should().Be(100);
            summary.Total.Should().Be(2);
            summary.Result.Should().BeEquivalentTo(new[] {
                new SalesUnitSummary {
                    SalesUnitId = 1,
                    CountryName = "Germany",
                    CurrencySymbol = "€",
                    SalesUnitName = "dreamlines.de",
                    TotalBooking = 2,
                    TotalPrice = 3000
                },
                new SalesUnitSummary {
                    SalesUnitId = 4,
                    CountryName = "France",
                    CurrencySymbol = "€",
                    SalesUnitName = "dreamlines.fr",
                    TotalBooking = 1,
                    TotalPrice = 1500
                }
            });
        }
        
        [Fact]
        public async Task GetLimitedSummaryOfSalesUnit() {
            // arrange
            var query = new SalesUnitQuery {
                Skip = 0,
                Limit = 1,
                FromDate = DateTime.UtcNow.AddDays(-3),
                ToDate = DateTime.UtcNow
            };

            // act
            var summary = await GetSalesUnitSummaryAsync(query);
           
            // assert
            summary.Skip.Should().Be(0);
            summary.Limit.Should().Be(1);
            summary.Total.Should().Be(2);
            summary.Result.Should().BeEquivalentTo(new[] {
                new SalesUnitSummary {
                    SalesUnitId = 1,
                    CountryName = "Germany",
                    CurrencySymbol = "€",
                    SalesUnitName = "dreamlines.de",
                    TotalBooking = 2,
                    TotalPrice = 3000
                }
            });
        }
        
        [Fact]
        public async Task SkipFirstSummaryOfSalesUnit() {
            // arrange
            var query = new SalesUnitQuery {
                Skip = 1,
                Limit = 100,
                FromDate = DateTime.UtcNow.AddDays(-3),
                ToDate = DateTime.UtcNow
            };

            // act
            var summary = await GetSalesUnitSummaryAsync(query);
           
            // assert
            summary.Skip.Should().Be(1);
            summary.Limit.Should().Be(100);
            summary.Total.Should().Be(2);
            summary.Result.Should().BeEquivalentTo(new[] {
                new SalesUnitSummary {
                    SalesUnitId = 4,
                    CountryName = "France",
                    CurrencySymbol = "€",
                    SalesUnitName = "dreamlines.fr",
                    TotalBooking = 1,
                    TotalPrice = 1500
                }
            });
        }
        
        [Fact]
        public async Task GetSummaryOfSpecificSalesUnit() {
            // arrange
            var query = new SalesUnitQuery {
                Skip = 0,
                Limit = 100,
                FromDate = DateTime.UtcNow.AddDays(-3),
                ToDate = DateTime.UtcNow,
                SalesUnitId = 1
            };

            // act
            var summary = await GetSalesUnitSummaryAsync(query);
           
            // assert
            summary.Skip.Should().Be(0);
            summary.Limit.Should().Be(100);
            summary.Total.Should().Be(1);
            summary.Result.Should().BeEquivalentTo(new[] {
                new SalesUnitSummary {
                    SalesUnitId = 1,
                    CountryName = "Germany",
                    CurrencySymbol = "€",
                    SalesUnitName = "dreamlines.de",
                    TotalBooking = 2,
                    TotalPrice = 3000
                }
            });
        }
        
        #region [Helpers]

        protected async Task<PaginatedResult<SalesUnitSummary>> GetSalesUnitSummaryAsync(SalesUnitQuery query) {
            var httpClient = Factory.CreateClient();
            
            var response = await httpClient.PostAsync(
                "/api/salesunit/search",
                new StringContent(
                    JsonConvert.SerializeObject(query),
                    Encoding.UTF8,
                    "application/json"
                )
            );

            return await response.Content.ReadAsAsync<PaginatedResult<SalesUnitSummary>>();
        }
        
        #endregion
        
    }

}