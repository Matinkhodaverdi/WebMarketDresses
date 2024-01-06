using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMarketDress.DataAccess.Service.Interface;
using WebMarketDress.Models.ViewModel;

namespace WebMarketDress.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class ShoppingCartController : Controller
	{
		private readonly IShoppingCartService _shoppingCart;

		public ShoppingCartController(IShoppingCartService shoppingCart)
		{
			_shoppingCart = shoppingCart;
		}

		public IActionResult Index()
		{
			var ClaimIdentity=(ClaimsIdentity)User.Identity;
			var Claim = ClaimIdentity.FindFirst(ClaimTypes.NameIdentifier).ToString();
			ShoppingCartVM shoppingCartVM = new ShoppingCartVM()
			{
				ListCart = _shoppingCart.GetAll(Claim)
			};
			return View(shoppingCartVM);
		}


	}
}
