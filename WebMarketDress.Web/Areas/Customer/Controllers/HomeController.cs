using Microsoft.AspNetCore.Mvc;
using WebMarketDress.DataAccess.Service.Interface;
using WebMarketDress.Models.ViewModel;

namespace WebMarketDress.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            ShoppingCartVM shoppingCart = new ShoppingCartVM()
            {
                Product = _productService.GetFirstOrDefualt(p => p.Id == id),
                Count = 1
            };
            return View(shoppingCart);
        }
    }
}
