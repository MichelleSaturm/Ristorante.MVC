using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ristorante.MVC.Models
{
    public class MenuViewModel
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Nome")]
            public string Nome { get; set; }
            
        }
    
}
