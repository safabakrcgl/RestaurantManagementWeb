namespace RestaurantManagement.Models;

public class MainCategories
{
    public MainCategories()
    {
        SubCategories = new HashSet<SubCategories>();
    }

    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation property
    public virtual ICollection<SubCategories> SubCategories { get; set; }
}