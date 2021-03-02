using System;

namespace BaristaApi
{
    class Program
    {
        static void Main(string[] args)
        {

            IBeverage latte = new Espresso().AddBeans(new Bean() { AmmountInG = 9, Sort = CoffeeSort.Robusta }).AddMilk().ToBeverage();
            Console.WriteLine(latte.GetType());
            IBeverage cappuccino = new Espresso().AddMilk().AddMilkFoam().ToBeverage();
            Console.WriteLine(cappuccino.GetType());
            IBeverage americano = new Espresso().AddWater().ToBeverage();
            Console.WriteLine(americano.GetType());
            //IBeverage espresso = new Espresso().AddWater(20).AddBeans(b => b.AmountInG = 5 && b.Sort = CoffeSorts.Robusta).ToBravage();
            //espresso is type of Espresso

            //IBeverage latte = new Espresso().AddWater(20).AddBeans(b => b.AmountInG = 7 && b.Sort = CoffeSorts.Robusta).AddMilk().ToBravage();
            //latte is type of Latte

        }
    }
}
