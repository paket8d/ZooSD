using Moq;
using Xunit;
using EntitiesClassLibrary;
using ZooSD;
namespace TestingClassLibrary
{
    public class ZooTests
    {
        [Fact]
        public void AddAnimal_HealthyAnimal_IsAdded()
        {
            // Arrange
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<IAlive>())).Returns(true);
            var zoo = new Zoo(mockClinic.Object);
            var rabbit = new Rabbit(); // Rabbit реализует IAlive, IInventory

            // Act
            zoo.AddAnimal(rabbit);

            // Assert
            Assert.Single(zoo.GetAllAnimals());
            Assert.Equal(1, rabbit.Number);
        }

        [Fact]
        public void AddAnimal_UnhealthyAnimal_IsNotAdded()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<IAlive>())).Returns(false);
            var zoo = new Zoo(mockClinic.Object);
            var tiger = new Tiger();

            zoo.AddAnimal(tiger);

            Assert.Empty(zoo.GetAllAnimals());
        }

        [Fact]
        public void GetTotalFood_ReturnsSumOfFood()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<IAlive>())).Returns(true);
            var zoo = new Zoo(mockClinic.Object);

            zoo.AddAnimal(new Rabbit()); // Food = 2
            zoo.AddAnimal(new Tiger());  // Food = 10

            Assert.Equal(12, zoo.GetTotalFood());
        }

        [Fact]
        public void GetContactableAnimals_ReturnsOnlyFriendlyHerbivores()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<IAlive>())).Returns(true);
            var zoo = new Zoo(mockClinic.Object);

            zoo.AddAnimal(new Rabbit()); // Kindness = 8 → подходит
            zoo.AddAnimal(new Tiger());  // Predator → не IContactable

            var contactable = zoo.GetContactableAnimals().ToList();

            Assert.Single(contactable);
            Assert.IsType<Rabbit>(contactable[0]);
        }
    }
}
