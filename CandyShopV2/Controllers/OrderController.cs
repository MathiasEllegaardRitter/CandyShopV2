using CandyShopV2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopV2.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCard _shoppingCard;


        public OrderController(IOrderRepository orderRepository, ShoppingCard shoppingCard)
        {
            _orderRepository = orderRepository;
            _shoppingCard = shoppingCard;
        }

        
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shoppingCard.ShoppingCardItems = _shoppingCard.GetShoppingCardItems();
            if (_shoppingCard.ShoppingCardItems.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty"); 
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCard.ClearCard();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }


        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for your order. Enjoy your candy";
            return View();
        }


    
    }
}
