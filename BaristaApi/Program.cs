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
            IBeverage espresso = 
                new Espresso()
                .AddBeans(new Bean() { AmmountInG = 9, Sort = CoffeeSort.Robusta })
                .GrindBeans()
                .AddWater(30)
                .AddMilk()
                .Validate(e => e.IsGround && e.IsBrewed)
                .ToBeverage();
            Console.WriteLine(espresso.GetType());

            // e=> e.IsGround && e.IsBrewed

            //IBeverage americano = new Espresso().AddWater().ToBeverage();
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

            /* 
 * IBeverage latte = new FluentEspresso()
                        .AddBeans(new Bean(){ 
                            AmountInG = 5,
                            Sort = CoffeSorts.Robusta})
                        .GrindBeans()
                        .AddWater(20)
                        .AddMilk()
                        .Validate(e => e.IsGrinded < 80) ** Above 90degree's for espresso
                    .ToBeverage();
 */

            //IBeverage espresso = new Espresso().AddWater(20).AddBeans(b => b.AmountInG = 5 && b.Sort = CoffeSorts.Robusta).ToBravage();
            //espresso is type of Espresso

            //IBeverage latte = new Espresso().AddWater(20).AddBeans(b => b.AmountInG = 7 && b.Sort = CoffeSorts.Robusta).AddMilk().ToBravage();
            //latte is type of Latte

        }
    }
}
