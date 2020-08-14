using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eConteudoPdf.Models
{
    public class Conteudo
    {
        [Required]
        public string caminho { get; set; }
        public string conteudo { get; set; }
    }
}