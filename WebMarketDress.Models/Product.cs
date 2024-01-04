using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarketDress.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن نام لباس اجباریست")]
        [DisplayName("نام لباس")]
        public string Name { get; set; }
        [Required(ErrorMessage = "وارد کردن جنس لباس اجباریست")]
        [DisplayName("جنس لباس")]
        public string Material { get; set; }
        [Required(ErrorMessage = "وارد کردن رنگ لباس اجباریست")]
        [DisplayName("رنگ لباس")]
        public string Color { get; set; }
        [Required(ErrorMessage = "وارد کردن سایز لباس اجباریست")]
        [DisplayName("سایز لباس")]
        public int Size { get; set; }
        [Required(ErrorMessage = "وارد کردن توضیحات اجباریست")]
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [Required(ErrorMessage = "وارد کردن قیمت لباس اجباریست")]
        [DisplayName("قیمت لباس")]
        public double Price { get; set; }
        [Required(ErrorMessage = "وارد کردن قیمت50 عدد لباس اجباریست")]
        [DisplayName("قیمت 50 عدد لباس")]
        public double Price50 { get; set; }
        [Required(ErrorMessage = "وارد کردن قیمت 100 عدد لباس اجباریست")]
        [DisplayName("قیمت 100 عدد لباس")]
        public double Price100 { get; set; }
        [Required(ErrorMessage = "وارد کردن تصویر لباس اجباریست")]
        [DisplayName("تصویر لباس")]
        [ValidateNever]
        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "وارد کردن دسته اجباریست")]
        [DisplayName(" دسته")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [Required(ErrorMessage = "وارد کردن  جنسیت لباس اجباریست")]
        [DisplayName("جنسیت لباس")]
        public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")]
        [ValidateNever]
        public CoverType CoverType { get; set; }

    }
}
