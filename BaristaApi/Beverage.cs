using System.Collections.Generic;

public enum CoffeeSort
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

public enum Ingredient
{
    Espresso,
    Milk,
    MilkFoam,
    ChocolateSyrup,
    Water
}

public class Bean
{
    public int AmmountInG { get; set; }
    public CoffeeSort Sort { get; set; }
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
	List<Ingredient> Ingredients { get; }
   // Ingredient Ingredient { get; }
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
    public List<Ingredient> Ingredients { get; }
    // the new bean would be added in the program.cs so you are creating the new bean as perameter.
    public Bean Bean { get; private set; }
    public CoffeeCup CupType { get; }
    public int WaterAmount { get; private set; }

    // contructor to be used in Program.cs
    public Espresso()
    {
        Ingredients = new List<Ingredient>();
    }

    public Espresso(List<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    // List<Ingredient> IBeverage.Ingredients => throw new System.NotImplementedException();

    // Bean IBeverage.Bean => throw new System.NotImplementedException();

    public IBeverage AddBeans(Bean bean)
    {
        Bean = bean;
        return this;
    }

    public IBeverage AddChocolateSyrup()
    {
        Ingredients.Add(Ingredient.ChocolateSyrup);
        return this;
    }

    public IBeverage AddMilk()
    {
        Ingredients.Add(Ingredient.Milk);
        return this;
    }

    public IBeverage AddMilkFoam()
    {
        Ingredients.Add(Ingredient.MilkFoam);
        return this;
    }

    public IBeverage AddWater()
    {
        Ingredients.Add(Ingredient.Water);
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
        if (Ingredients.Count == 1 && Ingredients.Contains(Ingredient.Milk))
        {
            return new Latte();
        }
        // Cappuccino
        if (Ingredients.Count == 2 && Ingredients.Contains(Ingredient.MilkFoam) && Ingredients.Contains(Ingredient.Milk))
        {
            return new Cappuccino();
        }
        // Americano
        if (Ingredients.Count == 1 && Ingredients.Contains(Ingredient.Water))
        {
            return new Americano();
        }
        // Macchiato
        if (Ingredients.Count == 1 && Ingredients.Contains(Ingredient.MilkFoam))
        {
            return new Macchiato(); 
        }
        //Mocha 
        //...
        return new CustomBeverage();
    }

    public IBeverage Validate()
    {
        throw new System.NotImplementedException();
    }
}

class Latte : Espresso
{
    public Latte() : base(new List<Ingredient>() { Ingredient.Milk })
    {

    }
} 

class Cappuccino : Espresso
{
    public Cappuccino() : base(new List<Ingredient>() { Ingredient.Milk, Ingredient.MilkFoam})
    {

    }
}

class Americano : Espresso
{
    public Americano() : base(new List<Ingredient>() { Ingredient.Water })
    {

    }
}
class Macchiato : Espresso
{
    public Macchiato() : base (new List<Ingredient>() { Ingredient.MilkFoam })
    {
    }
}
//Mocha class 
//...
class CustomBeverage : Espresso
{
    public CustomBeverage(): base (new List<Ingredient>() { })
    {

    }
}