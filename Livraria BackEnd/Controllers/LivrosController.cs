using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Livraria_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria_BackEnd.Controllers
{
    [Route("api/Livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public LivrosController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livros>>> GetAll()
        {
            return await _context.Livros.ToListAsync();
        }

            

            

        // GET: api/Livros/{codigo}
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Livros>> GetLivro(int codigo)
        {
            var livro = await _context.Livros.FindAsync(codigo);
            if(livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        [HttpGet("teste")]

        public ActionResult teste()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("Select * from Livros");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<LivrosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LivrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LivrosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
