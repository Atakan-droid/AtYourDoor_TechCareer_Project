using Business.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Result<Order> AddOrder(OrderAddDTO order);
        Result<Order> UpdateOrder(int orderId, Order order);
        Result<Order> IsOrderReadyUpdate(int orderId,int courierId);
        
        Result<Order> DeleteOrder(int orderId);
        Result<Order> HardDeleteOrder(int orderId);
        Result<Order> GetOrderById(int orderId);
        
        Result<List<Order>> GetUserOrders(int userId);
        Result<Order> CourierDelivery(OrderDeliveryDTO order);
    }
}
