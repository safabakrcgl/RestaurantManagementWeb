namespace RestaurantManagement.Models;

public class MenuItems
{
    public MenuItems()
    {
        RecipeRequirements = new HashSet<RecipeRequirements>();
        OrderItems = new HashSet<OrderItems>();
    }

    public int ID { get; set; }
    public int SubCategoryID { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }

    // Navigation properties
    public virtual SubCategories SubCategories { get; set; } = null!;
    public virtual ICollection<RecipeRequirements> RecipeRequirements { get; set; }
    public virtual ICollection<OrderItems> OrderItems { get; set; }
}