using MediatR;
using Moq;

namespace InstantPOS.WebAPI.Tests.Controllers
{
    public abstract class BaseAPITest
    {
        public Mock<IMediator> BaseMediator;

        public BaseAPITest()
        {
            BaseMediator = new Mock<IMediator>();
        }
    }
}
