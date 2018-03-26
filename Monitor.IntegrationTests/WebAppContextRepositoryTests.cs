using Microsoft.EntityFrameworkCore;
using Monitor.Models;
using Monitor.Repository;
using System;
using Xunit;

namespace Monitor.IntegrationTests
{
    public class WebAppContextRepositoryTests
    {
        [Fact]
        public void CanAddAndGetWebSite()
        {
            // Arrange
            IWebAppContextRepository context = GetInMemoryWebAppContextRepository();
            Site site = new Site()
            {
                Id = 800,
                Name = "http://websitefortests.com",
                RefreshTime = 10000

            };
            // Act
            Site savedSite = context.AddSite(site);
            Site getByNameSite = context.GetSiteByName(savedSite.Name);

            // Assert
            Assert.NotNull(getByNameSite);
            Assert.Equal(getByNameSite.Name, savedSite.Name);
            Assert.Equal(getByNameSite.RefreshTime, savedSite.RefreshTime);          
        }

        private IWebAppContextRepository GetInMemoryWebAppContextRepository()
        {
            DbContextOptions<WebAppContext> options;
            var builder = new DbContextOptionsBuilder<WebAppContext>();
            #pragma warning disable CS0618 // Тип или член устарел
            builder.UseInMemoryDatabase();
            #pragma warning restore CS0618 // Тип или член устарел
            options = builder.Options;
            WebAppContext personDataContext = new WebAppContext(options);
            personDataContext.Database.EnsureDeleted();
            personDataContext.Database.EnsureCreated();
            return new WebAppContextRepository(personDataContext);
        }
    }
   
}
