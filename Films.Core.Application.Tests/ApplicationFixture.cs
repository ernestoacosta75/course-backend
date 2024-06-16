using Films.Core.DomainServices.DatabaseContext;
using Films.Core.DomainServices.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Films.Core.Application.Tests
{
    public class ApplicationFixture : IDisposable
    {
        protected Mock<IUnitOfWork> UnitOfWork { get; set; }
        protected Mock<FilmsDbContext> FilmsDbContextMock { get; set; }

        public ApplicationFixture()
        {
            FilmsDbContextMock = new Mock<FilmsDbContext>();
            UnitOfWork = new Mock<IUnitOfWork>(FilmsDbContextMock.Object);
        }
        public void Dispose()
        {
            
        }
    }
}
