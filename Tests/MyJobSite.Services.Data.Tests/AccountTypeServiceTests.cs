namespace MyJobSite.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using MyJobSite.Data;
    using MyJobSite.Data.Common.Repositories;
    using MyJobSite.Data.Models;
    using MyJobSite.Data.Repositories;
    using Xunit;

    public class AccountTypeServiceTests
    {
        [Fact]
        public void GetAccountTypeControllerTest()
        {
            var mockRepository = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            mockRepository.Setup(x => x.All()).Returns(this.GetApplicationUserData());

            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);

            var service = new AccountTypeService(userManager.Object, mockRepository.Object);

            var accountType = service.GetAccountTypeController("1");

            Assert.Equal("Candidate", accountType);
        }

        [Fact]
        public async Task MarkProfileAsDeletedTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<ApplicationUser>(new ApplicationDbContext(options.Options));

            foreach (var item in this.GetApplicationUserData())
            {
                await repository.AddAsync(item);
                await repository.SaveChangesAsync();
            }

            var store = new Mock<IUserStore<ApplicationUser>>();

            var userManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);

            var service = new AccountTypeService(userManager.Object, repository);

            await service.MarkProfileAsDeleted("1");

            var user = repository.AllWithDeleted().Where(x => x.Id == "1").FirstOrDefault();

            Assert.True(user.IsDeleted);
        }

        private IQueryable<ApplicationUser> GetApplicationUserData()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "1",
                    AccountType = "Candidate",
                    IsDeleted = false,
                },
                new ApplicationUser
                {
                    Id = "2",
                    AccountType = "Company",
                    IsDeleted = false,
                },
                new ApplicationUser
                {
                    Id = "3",
                    AccountType = "Candidate",
                    IsDeleted = false,
                },
            }.AsQueryable();
        }
    }
}
