using Moq;
using NUnit.Framework;
using SmartHive.Providers.Contracts;
using System.Security.Principal;

namespace SmartHive.Authentication.Tests.HttpContextAuthenticationProviderTests
{
    [TestFixture]
    public class GetCurrentUserId_Should
    {
        [Test]
        public void _Call_HttpContextProviderCurrentIdentity()
        {
            //Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedIdentity = new Mock<IIdentity>();

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(provider => provider.CurrentIdentity).Returns(mockedIdentity.Object);

            var httpContextAuthProvider = new Providers.HttpContextAuthenticationProvider(mockedHttpContextProvider.Object,
                mockedDateTimeProvider.Object);

            //Act
            var result = httpContextAuthProvider.CurrentUserId;

            //Assert
            mockedHttpContextProvider.Verify(provider => provider.CurrentIdentity, Times.Once);
        }
    }
}
