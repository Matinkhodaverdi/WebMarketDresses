using Microsoft.AspNetCore.Identity;
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

        [HttpGet]
        public IActionResult Index()
        {
            var user = _signInManager.UserManager.FindByNameAsync(User.Identity.Name).Result;
            ShoppingCartVM shoppingCartVM = new ShoppingCartVM()
            {
                ListCart = _shoppingCart.GetAll(user.Id)
            };
            return View(shoppingCartVM);
        }
    }
}
