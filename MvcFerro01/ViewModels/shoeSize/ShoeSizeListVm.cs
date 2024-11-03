using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcFerro01.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.ViewModels.ShoeSize.ShoeSizeListVm
{
    public class ShoeSizeListVm
    {
       public int ShoeSizeId { get; set; }
        public int ShoeId { get; set; }

        public int SizeId { get; set; }

        public Shoes? Shoe { get; set; }
        public Size? Size { get; set; }
        public int QuantityInStock { get; set; }
    }
}
