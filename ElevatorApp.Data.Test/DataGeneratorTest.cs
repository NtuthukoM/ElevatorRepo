using ElevatorApp.Data.Concrete;
using ElevatorApp.Data.Interfaces;

namespace ElevatorApp.Data.Test
{
    public class DataGeneratorTest
    {
        [Fact]
        public void GetElevatorsReturnsNonEmptyList()
        {
            IDataGenerator dataGenerator = new DataGenerator();
            var elevators = dataGenerator.GetElevators();
            Assert.NotEmpty(elevators);             
        }

        [Fact]
        public void GetElevatorsAllElevatorsHaveNonZeroMaxLoad()
        {
            IDataGenerator dataGenerator = new DataGenerator();
            var elevators = dataGenerator.GetElevators();
            var nonZero = elevators.Any(x => x.MaxLoad < 1);
            Assert.False(nonZero);
        }
    }
}