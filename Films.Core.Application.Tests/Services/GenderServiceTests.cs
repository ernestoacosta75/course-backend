using Xunit;

namespace Films.Core.Application.Tests.Services
{
    public class GenderServiceTests : IClassFixture<ApplicationFixture>
    {
        private readonly ApplicationFixture _fixture;

        public GenderServiceTests(ApplicationFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void WhenAddGenderThenUnitOfWorkIsCalledOnce()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
