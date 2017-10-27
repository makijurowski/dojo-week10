using System;
using System.ComponentModel.DataAnnotations;
using LoginRegistration.Models;

namespace TheWall.Models
{
    public class Message : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [Display(Name="Message")]
        public string UserMessage { get; set; }
    }
}