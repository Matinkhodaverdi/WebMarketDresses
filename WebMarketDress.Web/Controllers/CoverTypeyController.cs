using Microsoft.AspNetCore.Mvc;
using WebMarketDress.DataAccess;
using WebMarketDress.DataAccess.Service.Interface;
using WebMarketDress.Models;


namespace WebMarketDress.Web
{
    public class CoverTypeyController : Controller
    {
        private readonly ICoverTypeService _coverTypeService;

        public CoverTypeyController(ICoverTypeService coverTypeService)
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
           
            if(ModelState.IsValid)
            {
                _coverTypeService.Add(obj);
                TempData["Success"] = "جنسیت با موفقیت ایجاد شد";
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
            var CoverTypeFromDbFirst= _coverTypeService.GetFirstOrDefualt(u =>u.Id==id);
            if(CoverTypeFromDbFirst==null)
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
                TempData["Success"] = "جنسیت با موفقیت ویرایش شد";
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
            var CoverTypeFromDbFirst = _coverTypeService.GetFirstOrDefualt(u => u.Id == id);
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

            var obj = _coverTypeService.GetFirstOrDefualt(u => u.Id == id);
            _coverTypeService.Remove(obj);
            TempData["Success"] = "جنسیت با موفقیت حذف شد";
            return RedirectToAction("Index");

            
        }


    }




}
