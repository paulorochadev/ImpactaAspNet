using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//---
using System.ComponentModel.DataAnnotations;


namespace AspNetVS2017.Capitulo03.Portifolio.Models
{
    public class ContatoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Mensagem { get; set; }
    }
}