namespace RestaurantManagement.Models;

public class RecipeRequirements
{
    public int ID { get; set; }
    public int MenuItemID { get; set; }
    public int IngredientID { get; set; }
    public decimal RequiredQuantity { get; set; }
    public string Unit { get; set; } = string.Empty;

    // Navigation properties
    public virtual MenuItems MenuItems { get; set; } = null!;
    public virtual Ingredients Ingredients { get; set; } = null!;
}