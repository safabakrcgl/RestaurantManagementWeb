namespace RestaurantManagement.Models;

public class Orders
{
    public Orders()
    {
        OrderItems = new HashSet<OrderItems>();
    }

    public int ID { get; set; }
    public int TableID { get; set; }
    public decimal TotalAmount { get; set; }

    // Navigation properties
    public virtual RestaurantTables RestaurantTables { get; set; } = null!;
    public virtual ICollection<OrderItems> OrderItems { get; set; }
}