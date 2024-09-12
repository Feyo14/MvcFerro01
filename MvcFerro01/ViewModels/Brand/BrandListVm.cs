﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.ViewModels.Brand.BrandListVm
{
    public class BrandListVm
    {
        public int BrandId { get; set; }
        [DisplayName("BrandName")]

        public string BrandName { get; set; } = null!;
        public bool Active { get; set; }


    }
}
