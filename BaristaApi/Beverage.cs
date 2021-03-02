using System.Collections.Generic;

public enum CoffeeSorts
{
    Robusta,
    Arabica,
    Liberica,
    Excelsa
}

public enum CoffeeCup
{
    Espresso,
    Small,
    Medium,
    Large
}

public class Bean
{
    public int AmmountInG { get; set; }
    public CoffeeSorts Sort { get; set; }
}

/* 
 * IBeverage latte = new FluentEspresso()
                        .AddBeans(new Bean(){ 
                            AmountInG = 5,
                            Sort = CoffeSorts.Robusta})
                        .GrindBeans()
                        .AddWater(20)
                        .AddMilk()
                        .Validate(e => e.Temerature < 80) ** Above 90degree's for espresso
                    .ToBeverage();
 */

// IBeverage espresso = new Espresso().AddWater(20).AddBeans(b => b.AmountInG = 5 && b.Sort = CoffeSorts.Robusta).AddWater().ToBravage();
public interface IBeverage{
	List<string> Ingredients { get; }
    CoffeeCup CupType { get; }
    Bean Bean { get; }
    int WaterAmount { get; }
    // int Temperature { get; } ** Maybe we use it depending on the logic for American formula.
    IBeverage AddBeans(Bean bean);
    IBeverage GrindBeans();
    IBeverage AddWater(int amount);
    IBeverage AddMilk();
    IBeverage AddMilkFoam();
    IBeverage AddChocolateSyrup();
    IBeverage Validate ();
    IBeverage ToBeverage();
}

class Espresso : IBeverage
{
    // This isnt a property, the get or set has to be there to declare a property. In the constructor you would be making the new list.
    public List<string> Ingredients { get; }
    // the new bean would be added in the program.cs so you are creating the new bean as perameter.
    public Bean Bean { get; private set; }
    public CoffeeCup CupType { get; }
    public int WaterAmount { get; private set; }

    // contructor to be used in Program.cs
    public Espresso()
    {
        Ingredients = new List<string>();
    }

    public Espresso(List<string> ingredients)
    {
        Ingredients = ingredients;
    }

    List<string> IBeverage.Ingredients => throw new System.NotImplementedException();

    Bean IBeverage.Bean => throw new System.NotImplementedException();

    public IBeverage AddBeans(Bean bean)
    {
        Bean = bean;
        return this;
    }

    public IBeverage AddChocolateSyrup()
    {
        Ingredients.Add("Chocolate Syrup");
        return this;
    }

    public IBeverage AddMilk()
    {
        Ingredients.Add("Milk");
        return this;
    }

    public IBeverage AddMilkFoam()
    {
        Ingredients.Add("Milk Foam");
        return this;
    }

    public IBeverage AddWater()
    {
        Ingredients.Add("Water");
        return this;
    }

    public IBeverage AddWater(int amount)
    {
        WaterAmount = amount;
        return this;
    }

    public IBeverage GrindBeans()
    {
        System.Console.WriteLine("Grinding Beans...");
        return this;
    }

    public IBeverage ToBeverage()
    {
        // Espresso
        if (Ingredients.Count == 0)
        {
            return this;
        }
        // Latte
        if (Ingredients.Count == 1 && Ingredients.Contains("Milk"))
        {

            return new Latte();
        }
        return this;
    }

    public IBeverage Validate()
    {
        throw new System.NotImplementedException();
    }
}

class Latte : Espresso
{
    public Latte() : base(new List<string>() { "Milk" })
    {

    }
} 