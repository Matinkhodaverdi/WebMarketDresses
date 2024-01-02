using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMarketDress.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن نام اجباریست")]
        [DisplayName("نام")]
        public string Name { get; set; }
        [Required(ErrorMessage = "وارد کردن ترتیب نمایش اجباریست")]
        [DisplayName("ترتیب نمایش")]
        public int DisPlayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
