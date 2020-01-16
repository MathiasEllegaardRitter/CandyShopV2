using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CandyShopV2.Models
{
    public class ShoppingCard
    {
        private readonly AppDbContext _appDbContext;
        public string ShoppingCardId { get; set; }

        public List<ShoppingCardItem> ShoppingCardItems { get; set; }

        public ShoppingCard(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCard GetCard(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cardId = session.GetString("CardId") ?? Guid.NewGuid().ToString();
            session.SetString("CardId", cardId);

            return new ShoppingCard(context) { ShoppingCardId = cardId };

        }


        public void AddToCard(Candy candy, int amount)
        {
            var shoppingCardItem = _appDbContext.ShoppingCardItems.SingleOrDefault(s => s.Candy.CandyId == candy.CandyId && s.ShoppingCardId == ShoppingCardId);

            if (shoppingCardItem == null)
            {
                shoppingCardItem = new ShoppingCardItem
                {
                    ShoppingCardId = ShoppingCardId,
                    Candy = candy,
                    Amount = amount
                };
                _appDbContext.ShoppingCardItems.Add(shoppingCardItem);
            } else {
                shoppingCardItem.Amount++;

            }
            _appDbContext.SaveChanges();

        }

        public int RemoveFromCard(Candy candy)
        {
            var shoppingCardItem = _appDbContext.ShoppingCardItems.SingleOrDefault(
                s => s.Candy.CandyId == candy.CandyId && s.ShoppingCardId == ShoppingCardId);

            var localAmount = 0;

            if (shoppingCardItem != null)
            {
                if (shoppingCardItem.Amount > 1)
                {
                    shoppingCardItem.Amount--;
                    localAmount = shoppingCardItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCardItems.Remove(shoppingCardItem);
                }
            }
            _appDbContext.SaveChanges();
            return localAmount;
        }


        public List<ShoppingCardItem> GetShoppingCardItems()
        {
            return ShoppingCardItems ?? (ShoppingCardItems = _appDbContext.ShoppingCardItems.Where(c => c.ShoppingCardId == ShoppingCardId).Include(s => s.Candy).ToList());
        }


        public void ClearCard()
        {
            var cardItems = _appDbContext.ShoppingCardItems.Where(c => c.ShoppingCardId == ShoppingCardId);

            _appDbContext.ShoppingCardItems.RemoveRange(cardItems);

            _appDbContext.SaveChanges();
        }


        public decimal GetShoppingCardTotal()
        {
            var total = (decimal)_appDbContext.ShoppingCardItems.Where(c => c.ShoppingCardId == ShoppingCardId).Select(c => c.Candy.Price * c.Amount).Sum();

            return total;

        }
    }
}
