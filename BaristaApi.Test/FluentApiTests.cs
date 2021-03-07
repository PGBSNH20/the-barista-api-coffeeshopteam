using System;
using Xunit;

namespace BaristaApi.Tests
{
    public class FluentApiTests
    {
        [Fact]
        public void When_Adding_Water_And_Beans_Expect_Espresso()
        {
            var espresso = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).GrindBeans().AddWater(30).BrewCoffee().ToBeverage();
            Assert.IsType<Espresso>(espresso);
        }

        [Fact]
        public void When_Adding_Water_And_Beans_Expect_Latte()
        {
            var latte = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(15).GrindBeans().BrewCoffee().AddMilk().ToBeverage();
            Assert.IsType<Latte>(latte);

        }

        [Fact]
        public void When_Adding_Milk_And_Milk_Foam_And_Beans_Expect_Cappuccino()
        {
            var cappuccino = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).GrindBeans().BrewCoffee().AddMilk().AddMilkFoam().ToBeverage();
            Assert.IsType<Cappuccino>(cappuccino);
        }

        [Fact]
        public void When_Adding_Water_And_Beans_Expect_Americano()
        {
            var americano = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).GrindBeans().BrewCoffee().AddsWaterAsIngredient().ToBeverage();
            Assert.IsType<Americano>(americano);
        }

        [Fact]
        public void When_Adding_Water_And_Beans_and_Milk_Foam_Expect_Macchiato()
        {
            var macchiato = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).GrindBeans().BrewCoffee().AddMilkFoam().ToBeverage();
            Assert.IsType<Macchiato>(macchiato);
        }

        [Fact]
        public void AssumeNoWaterException()
        {
            Action action = () => new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).GrindBeans().BrewCoffee().AddMilkFoam().ToBeverage();
            Exception exception = Assert.Throws<Exception>(action);
            Assert.Equal("Error: missing water", exception.Message);
        }

        [Fact]
        public void When_AddingWaterAndBeansandChocolateSyrupandMilk_Expect_Mocha()
        {
            var mocha = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).GrindBeans().AddWater(25).BrewCoffee().AddChocolateSyrup().AddMilk().ToBeverage();
            Assert.IsType<Mocha>(mocha);
        }

        [Fact]
        public void When_Adding_Water_And_Beans_And_ChocolateSyrup_Expect_CustomBeverage()
        {
            var customBeverage = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).GrindBeans().AddWater(25).BrewCoffee().AddChocolateSyrup().ToBeverage();
            Assert.IsType<CustomBeverage>(customBeverage);
        }
        
        [Fact]
        public void TestingException_NoBean()
        {
            // Expecting fail due to no beans
            var beverage = new Espresso().AddWater(25).GrindBeans().BrewCoffee().AddMilkFoam().ToBeverage();
            Assert.IsType<Espresso>(beverage);
        }

        [Fact]
        public void TestingValidate()

        {
            //Pseudo code
            // Act
            var espresso = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).GrindBeans().AddWater(30).BrewCoffee().Validate(e => e.WaterAmount < 15).ToBeverage();
            // Assert
            Assert.IsType<Espresso>(espresso);
        }
    }
}
