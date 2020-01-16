using System;

namespace CandyShopV2.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCard _shoppingCard;


        public OrderRepository(AppDbContext appDbContext, ShoppingCard shoppingCard)
        {
            _appDbContext = appDbContext;
            _shoppingCard = shoppingCard;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCard.GetShoppingCardTotal();
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var shoppingCardItems = _shoppingCard.GetShoppingCardItems();


            foreach (var shoppingCardItem in shoppingCardItems)
            {
                var orderdetail = new OrderDetail
                {
                    Amount = shoppingCardItem.Amount,
                    Price = shoppingCardItem.Candy.Price,
                    CandyId = shoppingCardItem.Candy.CandyId,
                    OrderId = order.OrderId
                };
                _appDbContext.OrderDetails.Add(orderdetail);
            }

            _appDbContext.SaveChanges();

        }
    }
}
