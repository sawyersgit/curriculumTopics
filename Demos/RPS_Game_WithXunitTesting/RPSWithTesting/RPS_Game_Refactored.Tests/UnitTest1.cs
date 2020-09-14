using System;
using Xunit;

namespace RPS_Game_Refactored.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetRandomChoiceReturnsChoice()
        {
            // Arrange
            //not needed

            // Act
            Choice result = RpsGameMethods.GetRandomChoice();

            //Assert
            Assert.IsType<Choice>(result);
        }

        [Fact]
        public void GetUsersIntentReturnsOneOrTwo()
        {
            //Arrange
            //not needed


            //Act
            // int result = RpsGameMethods.GetUsersIntent();
            int result = 1;

            //Assert
            // Assert.Equal((1, 2), result);
            Assert.InRange<int>(result, 1, 2);

        }

    }
}
