using RestaurantManagement.Models;

namespace RestaurantManagement.Services;

public interface IOrderService
{
    Task AddOrderItem(OrderItems item);
}