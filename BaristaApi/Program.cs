using System;

namespace BaristaApi
{
    class Program
    {
        static void Main(string[] args)
        {          
            IBeverage espresso = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).GrindBeans().AddWater(30).BrewCoffee().ToBeverage();
            Console.WriteLine(espresso.GetType());

            IBeverage espresso2 =
                new Espresso()
                .AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta })
                .GrindBeans()
                .AddWater(30)
                .BrewCoffee()
                .AddMilk()
                .Validate(e => e.WaterAmount > 20)
                .ToBeverage();
            Console.WriteLine(espresso2.GetType());
        }
    }
}
