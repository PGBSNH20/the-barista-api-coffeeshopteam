using Xunit;

namespace BaristaApi.Tests
{
    public class FluentApiTests
    {
        [Fact]
        public void When_Adding_Water_And_Beans_Expect_Espresso(){
            //Pseudo code
            
            // Act
            var beverage = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(15).ToBeverage();
            // Assert
            Assert.IsType<Espresso>(beverage);
           
        }
   
    
        [Fact]
        public void When_Adding_Water_And_Beans_Expect_Latte()
        {
            //Pseudo code

            // Act
            var latte = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(15).AddMilk().ToBeverage();
            // Assert
            Assert.IsType<Latte>(latte);

        }

        [Fact]
        public void When_Adding_Milk_And_Milk_Foam_And_Beans_Expect_Cappuccino()
        {
            // Act
            var cappuccino = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).AddMilk().AddMilkFoam().ToBeverage();
            // Assert
            Assert.IsType<Cappuccino>(cappuccino);
        }

        [Fact]
        public void When_Adding_Water_And_Beans_Expect_Americano()
        {
            // Act
            var americano = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).AddWater().ToBeverage();
            // Assert
            Assert.IsType<Americano>(americano);
        }
        [Fact]
        public void When_Adding_Water_And_Beans_and_Milk_Foam_Expect_Macchiato()
        {
            // Act
            var macchiato = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).AddMilkFoam().ToBeverage();
            // Assert
            Assert.IsType<Macchiato>(macchiato);
        }

        [Fact]
        public void Testing_Exception_NoBean()
        {
            // Expecting fail due to no beans
            // Act
            var beverage = new Espresso().AddWater(25).AddMilkFoam().GrindBeans().ToBeverage();
            // Assert
            Assert.IsType<Espresso>(beverage);
        }
    }
}