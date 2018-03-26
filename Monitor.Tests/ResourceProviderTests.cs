using Monitor.Services;
using Xunit;

namespace Monitor.Tests
{
    public class ResourceProviderTests
    {
        [Fact]
        public void CanGetResource()
        {        
            // Act
            var result = ResourceProvider.GetResource("Home");
            // Assert
            Assert.Equal("Домой", result);
        }
    }
}
