using Microsoft.AspNetCore.Mvc;
using WebMarketDress.DataAccess;
using WebMarketDress.DataAccess.Service;
using WebMarketDress.DataAccess.Service.Interface;
using WebMarketDress.Models;


namespace WebMarketDress.Web
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _categoryService.GetAll();
            return View(CategoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }


        //Post
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisPlayOrder.ToString())
            {
                ModelState.AddModelError("customerror", "مقدار نام و ترتیب نمایش نباید باهم برابر باشد");

            }
            if(ModelState.IsValid)
            {
                _categoryService.Add(obj);
                TempData["Success"] = "دسته با موفقیت ایجاد شد";
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            var categoryFromDbFirst= _categoryService.GetFirstOrDefualt(u =>u.Id==id);
            if(categoryFromDbFirst==null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        //Post
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisPlayOrder.ToString())
            {
                ModelState.AddModelError("customerror", "مقدار نام و ترتیب نمایش نباید باهم برابر باشد");

            }
            if (ModelState.IsValid)
            {
                _categoryService.Update(obj);
                TempData["Success"] = "دسته با موفقیت ویرایش شد";
                return RedirectToAction("Index");

            }
            return View(obj);
        }


        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDbFirst = _categoryService.GetFirstOrDefualt(u => u.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        //Post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {

            var obj = _categoryService.GetFirstOrDefualt(u => u.Id == id);
            _categoryService.Remove(obj);
            TempData["Success"] = "دسته با موفقیت حذف شد";
            return RedirectToAction("Index");

            
        }


    }




}
