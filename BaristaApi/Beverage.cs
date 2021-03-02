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
    public List<string> Ingredients = new List<string>() ;
    public Bean Bean = new Bean();
    public CoffeeCup esCup => CoffeeCup.Espresso;
    public IBeverage AddBeans(Bean bean)
    {
        Bean = bean;
        return this;
    }
    public IBeverage AddWater()
    {
        Ingredients.Add("Water");
        return this;
    }
}

class Latte : IBeverage
{
    public List<string> Ingredients => throw new System.NotImplementedException();

    public string CupType => throw new System.NotImplementedException();
}