namespace RestaurantManagement.Models;

public class SubCategories
{
    public SubCategories()
    {
        MenuItems = new HashSet<MenuItems>();
    }

    public int ID { get; set; }
    public int MainCategoryID { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation properties
    public virtual MainCategories MainCategories { get; set; } = null!;
    public virtual ICollection<MenuItems> MenuItems { get; set; }
}