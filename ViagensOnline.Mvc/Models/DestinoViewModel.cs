using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//---
using System.ComponentModel.DataAnnotations;

namespace ViagensOnline.Mvc.Models
{
    public class DestinoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, Display(Name = "País")]
        public string Pais { get; set; }

        [Required]
        public string Cidade { get; set; }


        public string CaminhoImagem { get; set; }

        [Display(Name = "Foto")]
        public HttpPostedFileBase ArquivoFoto { get; set; }
    }
}