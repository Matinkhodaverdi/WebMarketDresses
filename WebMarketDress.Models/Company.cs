﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarketDress.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="نام شرکت")]
        public string Name { get; set; }
        [Display(Name = "آدرس خیابان")]
        public string? StreetAddress { get; set; }
        [Display(Name = "نام شهر")]
        public string? City { get; set; }
        [Display(Name = "شماره تماس ")]
        public string? PhoneNumber { get; set; }
    }
}
