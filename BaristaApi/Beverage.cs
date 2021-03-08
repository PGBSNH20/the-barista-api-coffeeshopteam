using System;
using System.Collections.Generic;
using System.Linq;

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
    Milk,
    MilkFoam,
    ChocolateSyrup,
    Water
}

public class Bean
{
    public int AmountInG { get; set; }
    public CoffeeSort Sort { get; set; }
}

public interface IBeverage
{
	List<Ingredient> Ingredients { get; }
    CoffeeCup CupType { get; }
    Bean Bean { get; }
    int WaterAmount { get; }
    bool IsBrewed { get; }
    bool IsGround { get; }
    IBeverage AddBeans(Bean bean);
    IBeverage GrindBeans();
    IBeverage AddWater(int amount);
    bool HasWater();
    IBeverage BrewCoffee();
    IBeverage AddsWaterAsIngredient();
    IBeverage AddMilk();
    IBeverage AddMilkFoam();
    IBeverage AddChocolateSyrup();
    IBeverage Validate (Func<IBeverage, bool> validator);
    IBeverage ToBeverage();
}

public class Espresso : IBeverage
{
    public List<Ingredient> Ingredients { get; }
    public Bean Bean { get; private set; }
    public CoffeeCup CupType { get; }
    public int WaterAmount { get; private set; }
    public bool IsBrewed { get; private set; }
    public bool IsGround { get; private set; }

    public Espresso()
    {
        Ingredients = new List<Ingredient>();
    }

    public Espresso(List<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public IBeverage AddBeans(Bean bean)
    {
        Bean = bean;
        return this;
    }

    public IBeverage GrindBeans()
    {
        if (Bean == null)
        {
            throw new Exception("Error:  Beans Missing");
        }
        IsGround = true;
        return this;
    }

    // Adds water to brew espresso
    public IBeverage AddWater(int amount)
    {
        WaterAmount += amount;
        return this;
    }

    // Adds water as ingredient, after brewing for Americano
    public IBeverage AddsWaterAsIngredient()
    {
        Ingredients.Add(Ingredient.Water);
        return this;
    }

    public bool HasWater()
    {
        return WaterAmount > 0;
    }

    public IBeverage BrewCoffee()
    {
        if (!HasWater())
        {
            throw new Exception("Error: missing water");
        }

        if (!IsGround)
        {
            throw new Exception("Error: missing ground beans");
        }

        IsBrewed = true;
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

    public IBeverage Validate(Func<IBeverage, bool> validator)
    {
        if (!validator(this))
        {
            throw new Exception("Error: Something's missing");
        }
        return this;
    }

    public IBeverage ToBeverage()
    {
        if (!IsBrewed)
        {
            throw new Exception("Error: coffee hasn't been brewed yet");
        }

        if (Ingredients.Count == 0)
        {
            return this;
        }
        // Latte
        if (Ingredients.Count == 1 && Ingredients.Contains(Ingredient.Milk))
        {
            return new Latte();
        }
        // Americano
        if (Ingredients.Count == 1 && Ingredients.Contains(Ingredient.Water))
        {
            return new Americano();
        }
        // Mocha
        Ingredient[] mochaIngredients = { Ingredient.Milk, Ingredient.ChocolateSyrup };
        if (Ingredients.Count == 2 && Ingredients.All(mochaIngredients.Contains))
        {
            return new Mocha();
        }
        // Cappuccino
        Ingredient[] capuccinoIngredients = { Ingredient.Milk, Ingredient.MilkFoam };
        if (Ingredients.Count == 2 && Ingredients.All(capuccinoIngredients.Contains))
        {
            return new Cappuccino();
        }
        // Macchiato
        if (Ingredients.Count == 1 && Ingredients.Contains(Ingredient.MilkFoam))
        {
            return new Macchiato();
        }
        // the return this will be changed to custom beverage;
        return new CustomBeverage(Ingredients);

        //   Type coffeeType = CoffeeTypes.GetCoffeeType(Ingredients);

        //   // Ingredients for espresso
        //   if (coffeeType == typeof(Espresso))
        //   {
        //       return this;
        //   }

        //   if (coffeeType != typeof(CustomBeverage))
        //   {
        //       return (IBeverage)Activator.CreateInstance(coffeeType);
        //   }

        //   return new CustomBeverage(Ingredients);
    }
}

//public static class CoffeeTypes
//{
//    static Dictionary<Type, Ingredient[]> coffeeTypes = new Dictionary<Type, Ingredient[]>()
//    { { typeof(Latte), new Ingredient[] { Ingredient.Milk } },
//      { typeof(Cappuccino), new Ingredient[] { Ingredient.MilkFoam, Ingredient.Milk } },
//      { typeof(Americano), new Ingredient[] { Ingredient.Water } },
//      { typeof(Macchiato), new Ingredient[] { Ingredient.MilkFoam } },
//      { typeof(Mocha), new Ingredient[] { Ingredient.ChocolateSyrup, Ingredient.Milk } }
//    };
    
//    public static Type GetCoffeeType(List<Ingredient> ingredients)
//    {
//        if (ingredients.Count == 0)
//        {
//            return typeof(Espresso);
//        }

//        foreach (var coffeeType in coffeeTypes)
//        {
//            if (coffeeType.Value.Length == ingredients.Count && coffeeType.Value.All(ingredients.Contains))
//            {
//                return coffeeType.Key;
//            }
//        }
//        return typeof(CustomBeverage);
//    }
//}

public class Latte : Espresso
{
    public Latte() : base(new List<Ingredient>() { Ingredient.Milk })
    {

    }
} 

public class Cappuccino : Espresso
{
    public Cappuccino() : base(new List<Ingredient>() { Ingredient.Milk, Ingredient.MilkFoam })
    {

    }
}

public class Americano : Espresso
{
    public Americano() : base(new List<Ingredient>() { Ingredient.Water })
    {

    }
}

public class Macchiato : Espresso
{
    public Macchiato() : base (new List<Ingredient>() { Ingredient.MilkFoam })
    {
    }
}

public class Mocha : Espresso
{
    public Mocha() : base(new List<Ingredient>() { Ingredient.ChocolateSyrup, Ingredient.Milk })
    {
    }
}

public class CustomBeverage : Espresso
{
    public CustomBeverage(List<Ingredient> ingredients): base (ingredients)
    {
    }
}