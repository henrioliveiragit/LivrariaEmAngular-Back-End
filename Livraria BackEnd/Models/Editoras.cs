using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria_BackEnd.Models
{
    public class Editoras
    {
        [Key]
        public int CodEditora { get; set; }
        public string Nome { get; set; }
    }
}
