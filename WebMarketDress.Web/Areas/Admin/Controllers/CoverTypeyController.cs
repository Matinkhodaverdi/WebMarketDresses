using Microsoft.AspNetCore.Mvc;
using WebMarketDress.DataAccess;
using WebMarketDress.DataAccess.Service.Interface;
using WebMarketDress.Models;


namespace WebMarketDress.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly ICoverTypeService _coverTypeService;

        public CoverTypeController(ICoverTypeService coverTypeService)
        {
            _coverTypeService = coverTypeService;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> CoverTypeList = _coverTypeService.GetAll();
            return View(CoverTypeList);
        }

        //Get
        public IActionResult Create()
        {

            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(CoverType obj)
        {

            if (ModelState.IsValid)
            {
                _coverTypeService.Add(obj);
                TempData["Success"] = "جنسیت لباس با موفقیت ایجاد شد";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CoverTypeFromDbFirst = _coverTypeService.GetFirstOrDefualt(i => i.Id == id);
            if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDbFirst);
        }

        //Post
        [HttpPost]
        public IActionResult Edit(CoverType obj)
        {

            if (ModelState.IsValid)
            {
                _coverTypeService.Update(obj);
                TempData["Success"] = "جنسیت لباس با موفقیت ویرایش شد";
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
            var CoverTypeFromDbFirst = _coverTypeService.GetFirstOrDefualt(i => i.Id == id);
            if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDbFirst);
        }

        //Post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _coverTypeService.GetFirstOrDefualt(i => i.Id == id);
            _coverTypeService.Remove(obj);
            TempData["Success"] = " جنسیت لباس با موفقیت حذف شد";
            return RedirectToAction("Index");

        }
    }
}
