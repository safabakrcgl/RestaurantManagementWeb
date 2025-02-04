namespace RestaurantManagement.Models;

public class RestaurantTables
{
    public RestaurantTables()
    {
        Orders = new HashSet<Orders>();
    }

    public int ID { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public string Status { get; set; } = string.Empty;

    // Navigation property
    public virtual ICollection<Orders> Orders { get; set; }
}