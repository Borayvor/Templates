namespace MyMvcProjectTemplate.Tests.IntegrationTests
{
    using System.Linq;
    using Data;
    using NUnit.Framework;

    [TestFixture]
    public class DummyContextTest
    {
        [Test]
        public void TestMethod()
        {
            // Arrange
            ApplicationDbContext context = new ApplicationDbContext();

            // Act
            int usersCount = context.Users.Count();

            // Assert
            Assert.AreEqual(1, usersCount);
        }
    }
}
