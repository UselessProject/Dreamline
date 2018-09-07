using Dreamlines.Web.Data;
using Dreamlines.Web.Services;

namespace Dreamlines.Web.Tests.Services {

    public abstract class BaseBookingServiceTests {

        protected abstract IBookingService CreateService(IBookingRepository repository);



    }

}
