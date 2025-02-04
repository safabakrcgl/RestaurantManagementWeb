namespace RestaurantManagement.Models;

public class OrderItems
{
    public int ID { get; set; }
    public int OrderID { get; set; }
    public int MenuItemID { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    // Navigation properties
    public virtual Orders Orders { get; set; } = null!;
    public virtual MenuItems MenuItems { get; set; } = null!;
}