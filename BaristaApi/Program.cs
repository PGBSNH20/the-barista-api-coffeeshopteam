using System;

namespace BaristaApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //IBeverage latte = new Espresso().AddBeans(new Bean() { AmmountInG = 9, Sort = CoffeeSort.Robusta }).AddWater(0).GrindBeans().AddMilk().ToBeverage();
           // Console.WriteLine(latte.GetType());
          
            IBeverage espresso = new Espresso().AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta }).GrindBeans().AddWater(30).BrewCoffee().ToBeverage();
            Console.WriteLine(espresso.GetType());

            IBeverage espresso2 = 
                new Espresso()
                .AddBeans(new Bean() { AmountInG = 9, Sort = CoffeeSort.Robusta })
                .GrindBeans()
                .AddWater(30)
                .AddMilk()
                .ToBeverage()
                .AddWater();

            Console.WriteLine(espresso2.GetType());
            IBeverage americano = new Espresso().AddWater().ToBeverage();
            //Console.WriteLine(americano.GetType());

            /*
            IBeverage cappuccino = new Espresso().AddMilk().AddMilkFoam().ToBeverage();
            Console.WriteLine(cappuccino.GetType());
            IBeverage americano = new Espresso().AddWater().ToBeverage();
            Console.WriteLine(americano.GetType());
            IBeverage macchiato = new Espresso().AddMilkFoam().ToBeverage();
            Console.WriteLine(macchiato.GetType());
            IBeverage custom = new Espresso().AddMilkFoam().AddChocolateSyrup().ToBeverage();
            Console.WriteLine(custom.GetType()); */

            //IBeverage espresso = new Espresso().AddWater(20).AddBeans(b => b.AmountInG = 5 && b.Sort = CoffeSorts.Robusta).ToBravage();
            //espresso is type of Espresso

            //IBeverage latte = new Espresso().AddWater(20).AddBeans(b => b.AmountInG = 7 && b.Sort = CoffeSorts.Robusta).AddMilk().ToBravage();
            //latte is type of Latte

        }
    }
}
