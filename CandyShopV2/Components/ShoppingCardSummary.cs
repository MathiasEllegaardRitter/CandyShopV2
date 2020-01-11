using CandyShopV2.Models;
using CandyShopV2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopV2.Components
{
    public class ShoppingCardSummary : ViewComponent
    {
        private readonly ShoppingCard _shoppingCard;

        public ShoppingCardSummary(ShoppingCard shoppingCard)
        {
            _shoppingCard = shoppingCard;
        }

        public IViewComponentResult Invoke()
        {
            _shoppingCard.ShoppingCardItems = _shoppingCard.GetShoppingCardItems();
            var shoppingCardViewModel = new ShoppingCardViewModel
            {
                ShoppingCard = _shoppingCard,
                ShoppingCardTotal = _shoppingCard.GetShoppingCardTotal()
            };
            return View(shoppingCardViewModel);
        }


    }
}
