﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMarketDress.DataAccess;
using WebMarketDress.DataAccess.Service;
using WebMarketDress.DataAccess.Service.Interface;
using WebMarketDress.Models;
using WebMarketDress.Models.ProductVM;


namespace WebMarketDress.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductService productService
            , ICategoryService categoryService, ICoverTypeService coverTypeService,
            IWebHostEnvironment hostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _coverTypeService = coverTypeService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _categoryService.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _coverTypeService.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Gender,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                //create
               
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _productService.GetFirstOrDefualt(u => u.Id == id);
                return View(productVM);
            }


            return View(productVM);
        }

        //post
        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.Product.ImgUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImgUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStrems = new FileStream(Path.Combine(uploads, fileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStrems);
                    }

                    obj.Product.ImgUrl = fileName + extention;
                }

                if (obj.Product.Id == 0) _productService.Add(obj);
                else _productService.Update(obj.Product);

                TempData["success"] = "محصول با موفقیت ویرایش شد";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _productService.GetAll();
            return Json(new { data = productList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _productService.GetFirstOrDefualt(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "خطا در حذف " });
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImgUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _productService.Remove(obj);
            return Json(new { success = true, message = "حذف موفقیت آمیز بود" });
        }
        #endregion

    }
}
