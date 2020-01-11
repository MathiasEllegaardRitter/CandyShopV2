using CandyShopV2.Models;
using CandyShopV2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopV2.Controllers
{
    public class ShoppingCardController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ShoppingCard _shoppingCard;

        public ShoppingCardController(ICandyRepository candyRepository, ShoppingCard shoppingCard)
        {
            _candyRepository = candyRepository;
            _shoppingCard = shoppingCard;
        }


        public ViewResult Index()
        {
            _shoppingCard.ShoppingCardItems = _shoppingCard.GetShoppingCardItems();

            var shoppingCardViewModel = new ShoppingCardViewModel
            {
                ShoppingCard = _shoppingCard,
                ShoppingCardTotal = _shoppingCard.GetShoppingCardTotal()
            };
            return View(shoppingCardViewModel);
        }

        public RedirectToActionResult AddToShoppigCard(int candyId)
        {
            var selectedCandy = _candyRepository.GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);
            if (selectedCandy != null)
            {
                _shoppingCard.AddToCard(selectedCandy, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppigCard(int candyId)
        {
            var selectedCandy = _candyRepository.GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);
            if (selectedCandy != null)
            {
                _shoppingCard.RemoveFromCard(selectedCandy);
            }
            return RedirectToAction("Index");
        }





    }
}
