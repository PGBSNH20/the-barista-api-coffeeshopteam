using System;
using Xunit;

namespace BaristaApi.Tests
{
    public class FluentApiTests
    {
        [Fact]
        public void When_Adding_Water_And_Beans_Expect_Espresso(){

            //Pseudo code
            // Act
            var espresso = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).GrindBeans().AddWater(30).BrewCoffee().ToBeverage();
            // Assert
            Assert.IsType<Espresso>(espresso);
        }

        [Fact]
        public void When_Adding_Water_And_Beans_Expect_Latte()
        {
            //Pseudo code
            // Act
            var latte = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(15).GrindBeans().BrewCoffee().AddMilk().ToBeverage();
            // Assert
            Assert.IsType<Latte>(latte);

        }

        [Fact]
        public void When_Adding_Milk_And_Milk_Foam_And_Beans_Expect_Cappuccino()
        {
            // Act
            var cappuccino = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).GrindBeans().BrewCoffee().AddMilk().AddMilkFoam().ToBeverage();
            // Assert
            Assert.IsType<Cappuccino>(cappuccino);
        }

        [Fact]
        public void When_Adding_Water_And_Beans_Expect_Americano()
        {
            // Act
            var americano = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).GrindBeans().BrewCoffee().AddWater().ToBeverage();
            // Assert
            Assert.IsType<Americano>(americano);
        }

        [Fact]
        public void When_Adding_Water_And_Beans_and_Milk_Foam_Expect_Macchiato()
        {
            // Act

            var macchiato = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).GrindBeans().BrewCoffee().AddMilkFoam().ToBeverage();
            // Assert
            Assert.IsType<Macchiato>(macchiato);
        }

        [Fact]

        public void AssumeNoWaterException()
        {
            // () => is an anonymous function/lamnda expression, where its telling it not to use it until the Action has been called, in this case Line 65
            Action action = () => new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).GrindBeans().BrewCoffee().AddMilkFoam().ToBeverage();

            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Error: missing water", exception.Message);
        }
   
        [Fact]
        public void When_AddingWaterAndBeansandChocolateSyrupandMilk_Expect_Mocha()
        {
            // Act
            var mocha = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).GrindBeans().AddWater(25).BrewCoffee().AddChocolateSyrup().AddMilk().ToBeverage();
            // Assert
            Assert.IsType<Mocha>(mocha);
        }

        [Fact]
        public void TestingException_NoBean()

        {
            // Expecting fail due to no beans
            // Act
            var beverage = new Espresso().AddWater(25).GrindBeans().BrewCoffee().AddMilkFoam().ToBeverage();
            // Assert
            Assert.IsType<Espresso>(beverage);
        }
    }
}