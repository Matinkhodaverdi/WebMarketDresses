using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarketDress.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="جنسیت لباس مشخص شود")]
        [Display(Name ="جنسیت لباس")]
        public String Gender { get; set; }
    }
}
