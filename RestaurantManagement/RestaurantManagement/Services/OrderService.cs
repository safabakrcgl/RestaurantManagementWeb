using RestaurantManagement.Data;
using RestaurantManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantManagement.Services;

public class OrderService : IOrderService
{
    private readonly RestaurantDbContext _context;

    public OrderService(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task AddOrderItem(OrderItems item)
    {
        try
        {
            // Debug için kontrol noktası 1
            Console.WriteLine("Sipariş oluşturuluyor...");

            var order = new Orders
            {
                TableID = 1,
                TotalAmount = 0,
                
            };

            // Debug için kontrol noktası 2
            Console.WriteLine($"Sipariş objesi oluşturuldu: TableID={order.TableID}");

            // Orders tablosuna kaydet
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Debug için kontrol noktası 3
            Console.WriteLine($"Sipariş kaydedildi. OrderID={order.ID}");

            // OrderItems'a sipariş detayını ekle
            item.OrderID = order.ID;
            
            // Debug için kontrol noktası 4
            Console.WriteLine($"OrderItem hazırlandı: OrderID={item.OrderID}, MenuItemID={item.MenuItemID}, Quantity={item.Quantity}");

            _context.OrderItems.Add(item);
            await _context.SaveChangesAsync();

            // Debug için kontrol noktası 5
            Console.WriteLine("Sipariş detayı kaydedildi.");
        }
        catch (Exception ex)
        {
            // Hata detaylarını logla
            Console.WriteLine($"HATA: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            throw;
        }
    }
}