﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFerro01.ViewModels.Sport.SportEditVm
{
    public class SportEditVm
    {
        public int SportId { get; set; }
        [Required(ErrorMessage ="{0} is required")]
        [StringLength(200,ErrorMessage ="{0} must have between {2} and {1} characters", MinimumLength =3)]
        [DisplayName("SportName")]
        [MaxLength(256, ErrorMessage = "{0} must have less than 257 characters")]
        public string SportName { get; set; } = null!;
        [ValidateNever]
        public bool Active { get; set; }
        [ValidateNever]


        public IEnumerable<SelectListItem> Shoes { get; set; } = null!;

    }
}