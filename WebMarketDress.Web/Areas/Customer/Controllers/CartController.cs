﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMarketDress.DataAccess.Service.Interface;
using WebMarketDress.Models;
using WebMarketDress.Models.ViewModel;

namespace WebMarketDress.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IShoppingCartService _shoppingCart;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CartController(IShoppingCartService shoppingCart, SignInManager<IdentityUser> signInManager)
        {
            _shoppingCart = shoppingCart;
            _signInManager = signInManager;
        }

        public int OrderTotal { get; set; }



        [HttpGet]
        public IActionResult Index()
        {
            var user = _signInManager.UserManager.FindByNameAsync(User.Identity.Name).Result;
            ShoppingCartVM shoppingCartVM = new ShoppingCartVM()
            {
                ListCart = _shoppingCart.GetAll(user.Id)
            };
            foreach (var cart in shoppingCartVM.ListCart)
            {
                cart.Price = GetPriceBasedOnQuantity(cart.Count, cart.Product.Price, cart.Product.Price50, cart.Product.Price100);
                shoppingCartVM.CartTotal += (cart.Price * cart.Count);
            }
            return View(shoppingCartVM);
        }


        private double GetPriceBasedOnQuantity(double quantity, double price, double price50, double price100)
        {
            if(quantity <= 50)
            {
                return price;
            }
            else
            {
                if(quantity <= 100)
                {
                    return price50;
                }
                else
                {
                    return price100;
                }
            }
        }
    }
}
