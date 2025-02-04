namespace RestaurantManagement.Models;

public class Ingredients
{
    public Ingredients()
    {
        RecipeRequirements = new HashSet<RecipeRequirements>();
    }

    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;

    // Navigation property
    public virtual ICollection<RecipeRequirements> RecipeRequirements { get; set; }
}