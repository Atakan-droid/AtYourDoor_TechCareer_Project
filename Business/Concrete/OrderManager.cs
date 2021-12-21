using Business.Abstract;
using Business.Utilities.Messages;
using Business.Utilities.Result;
using Business.Validation.FluentValidation;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        public  IOrderDal _orderDal;
        public IUserDal _userDal;
        public IAddressDal _addressDal;
        public IProductService _productService;
        public OrderManager(IOrderDal orderDal,IUserDal userDal,IAddressDal addressDal, IProductService productService)
        {
            _orderDal = orderDal;
            _userDal = userDal;
            _addressDal = addressDal;
            _productService = productService;
        }
        public Result<Order> AddOrder(OrderAddDTO order)
        {
           var result = ValidateOrder(order);
            if (result.IsValid)
            {
                var usersAddress = _addressDal.Get(a => a.Id == order.AddressId);
                if (usersAddress.UserId != order.UserId) { return new Result<Order>(false, Messages.AddressWrong); }
                if (!CheckIsUserExist(order.UserId)) { return new Result<Order>(false, Messages.UserNotFound); }
                if (!_userDal.CheckUserIsUYE(order.UserId)) { return new Result<Order>(false, Messages.UserNotOrder); }
                var productsToAdd=_productService.CheckProductsStock(order.Products);
                if (!productsToAdd.Success) { return new Result<Order>(false, productsToAdd.Message); }
                _productService.ChangeProductsStockAfterOrder(productsToAdd.Data,order.Products);
                
                Order orderToAdd = new Order();
                orderToAdd.Products = productsToAdd.Data;
                orderToAdd.UserId = order.UserId;
                orderToAdd.AddressId = order.AddressId;
                _orderDal.Add(orderToAdd);
                return new Result<Order>(orderToAdd,true,Messages.OrderAdded);

            }
            else
            {
                List<string> errorList = new List<string>();
                foreach (var error in result.Errors)
                {
                    errorList.Add(error.PropertyName + " : " + error.ErrorMessage);
                }
                return new Result<Order>(errorList, false, Messages.OrderError);
            }
        }

        public Result<Order> CourierDelivery(OrderDeliveryDTO order)
        {
            var validateOrder = ValidateDeliveryOrder(order);
            if (validateOrder.IsValid)
            {
                var result = GetOrderById(order.OrderId);
                
                if (result.Success)
                {
                    if (result.Data.isReady == false) { return new Result<Order>(false, Messages.OrderIsNotReadyToDeliver); }
                    if (result.Data.CourierId != order.CourierId) { return new Result<Order>(false, Messages.OrderNotThisCourier); }
                    result.Data.isDelivered = order.IsDelivered;
                    result.Data.ModifiedDate = DateTime.Now;
                    result.Data.DeliveryNote = order.Note;
                    _orderDal.Update(result.Data);

                    return new Result<Order>(true, Messages.OrderUpdated);
                }
                return new Result<Order>(false, Messages.OrderNotFound);
            }
            else
            {
                List<string> errorList = new List<string>();
                foreach (var error in validateOrder.Errors)
                {
                    errorList.Add(error.PropertyName + " : " + error.ErrorMessage);
                }
                return new Result<Order>(errorList, false, Messages.OrderError);
            }
        }

        public Result<Order> DeleteOrder(int orderId)
        {
            var result = GetOrderById(orderId);
            if (result.Success)
            {
                result.Data.IsDeleted = true;
                result.Data.ModifiedDate = DateTime.Now;
                _orderDal.Update(result.Data);

                return new Result<Order>(true, Messages.OrderDeleted);
            }
            return new Result<Order>(false, Messages.OrderNotFound);
        }

        public Result<Order> GetOrderById(int orderId)
        {
            var order=_orderDal.Get(o => o.Id == orderId, o => o.Products);
            if (order == null)
            {
                return new Result<Order>(false, Messages.OrderNotFound);
            }
            return new Result<Order>(order, true, Messages.OrderGet);
        }

        public Result<List<Order>> GetUserOrders(int userId)
        {
            return new Result<List<Order>>(_orderDal.GetAll(o => o.Id == userId,o=>o.Products), true, Messages.OrderGet);
        }

        public Result<Order> HardDeleteOrder(int orderId)
        {
            var result = GetOrderById(orderId);
            if (result.Success)
            {
                
                _orderDal.Delete(result.Data);
                return new Result<Order>(true, Messages.OrderDeleted);
            }
            return new Result<Order>(false, Messages.OrderError);
        }

        public Result<Order> IsOrderReadyUpdate(int orderId,int courierId)
        {
            var isOrderExist = GetOrderById(orderId);
            if (!isOrderExist.Success) { return new Result<Order>(false, Messages.OrderNotFound); }

                isOrderExist.Data.CourierId = courierId;
                isOrderExist.Data.isReady = true;
                isOrderExist.Data.ModifiedDate = DateTime.Now;
                _orderDal.Update(isOrderExist.Data);
                return new Result<Order>(isOrderExist.Data, true, Messages.OrderOnTheWay);
        }


        public Result<Order> UpdateOrder(int orderId, Order order)
        {
            var result = GetOrderById(orderId);
            if (result.Success)
            {
                result.Data.CourierId = order.CourierId;
                result.Data.AddressId = order.AddressId;
                result.Data.ModifiedDate = DateTime.Now;
                _orderDal.Update(result.Data);
                return new Result<Order>(true, Messages.OrderDeleted);
            }
            return new Result<Order>(false, Messages.OrderError);
        }
        private  bool CheckIsUserExist(int userId)
        {
            return _userDal.Any(u => u.Id == userId);
        }
        private ValidationResult ValidateOrder(OrderAddDTO order)
        {
            OrderAddDTOValidator rules = new OrderAddDTOValidator();
            ValidationResult result = rules.Validate(order);
            return result;
        }
        private ValidationResult ValidateDeliveryOrder(OrderDeliveryDTO order)
        {
            OrderDeliveryDTOValidator rules = new OrderDeliveryDTOValidator();
            ValidationResult result = rules.Validate(order);
            return result;
        }

    }
}
