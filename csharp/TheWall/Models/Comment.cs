using System;
using System.ComponentModel.DataAnnotations;
using LoginRegistration.Models;

namespace TheWall.Models
{
    public class Comment : BaseEntity
    {       
        [Required]
        [MinLength(2)]
        [Display(Name = "Comment")]
        public string UserComment { get; set; }
    }
}