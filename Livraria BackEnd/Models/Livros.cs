using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria_BackEnd.Models
{
    public class Livros
    {
        [Key]
        public Guid Codigo { get; set; }
        public int CodEditora { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo Titulo precisa ter entre 1 e 30 caracteres", MinimumLength = 1)]
        public string Titulo { get; set; }
        public string Resumo    { get; set; }
        public string Autores { get; set; }
    }
}
