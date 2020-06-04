using DickinsonBros.Stopwatch.Abstractions;
using DickinsonBros.Stopwatch.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DickinsonBros.Stopwatch.Tests.Extensions
{
    [TestClass]
    public class IServiceCollectionExtensionsTests
    {
        [TestMethod]
        public void AddStopwatchService_Should_Succeed()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.AddStopwatchService();

            // Assert

            Assert.IsTrue(serviceCollection.Any(serviceDefinition => serviceDefinition.ServiceType == typeof(IStopwatchService) &&
                                           serviceDefinition.ImplementationType == typeof(StopwatchService) &&
                                           serviceDefinition.Lifetime == ServiceLifetime.Transient));
        }
    }
}
