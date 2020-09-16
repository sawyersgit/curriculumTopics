using System;
using Xunit;
using Xunit.Abstractions;
using RPS_Game_Refactored;

namespace Rps_Game_Refactored.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            //not needed

            // Act
            Choice result = RpsGameMethods.GetRandomChoice();

            //Assert
            Assert.IsType<Choice>(result);
        }



    }
}
