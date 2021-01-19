using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModels
{
    public class UserViewModel
    {
        public int id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="Correo Electronico")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Contrasena")]
        public string password { get; set; }
    }
}