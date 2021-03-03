using Xunit;

namespace BaristaApi.Tests
{
    public class FluentApiTests
    {
        [Fact]
        public void When_AddingWaterAndBeans_Expect_Espresso(){
            //Pseudo code
            
            // Act
            var beverage = new Espresso().AddBeans(new Bean() { AmmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(15).ToBeverage();
            // Assert
            Assert.IsType<Espresso>(beverage);
           
        }
   
    
        [Fact]
        public void When_AddingWaterAndBeans_Expect_Latte()
        {
            //Pseudo code

            // Act
            var latte = new Espresso().AddBeans(new Bean() { AmmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(15).AddMilk().ToBeverage();
            // Assert
            Assert.IsType<Latte>(latte);

        }

        [Fact]
        public void When_AddingMilkAndMilkFoamAndBeans_Expect_Cappuccino()
        {
            // Act
            var cappuccino = new Espresso().AddBeans(new Bean() { AmmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).AddMilk().AddMilkFoam().ToBeverage();
            // Assert
            Assert.IsType<Cappuccino>(cappuccino);
        }

        [Fact]
        public void When_AddingWaterAndBeans_Expect_Americano()
        {
            // Act
            var americano = new Espresso().AddBeans(new Bean() { AmmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(25).AddWater().ToBeverage();
            // Assert
            Assert.IsType<Americano>(americano);
        }

    }
}