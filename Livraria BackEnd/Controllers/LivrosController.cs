using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Livraria_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        // GET: api/Livros
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

        // PUT: api/Livros/{codigo}
        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutLivro(int codigo, Livros livro)
        {
            if (codigo != livro.Codigo)
            {
                return BadRequest(); 
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            { 
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;

            }

            return NoContent();

        }

        //POST: api/Livros
        [HttpPost]
        public async Task<ActionResult<Livros>> PostLivro(Livros livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivro", new { codigo = livro.Codigo}, livro);
        }

        // GET: api/Livros/teste
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

        // DELETE: api/Livros/{codigo}
        [HttpDelete("{codigo}")]
        public async Task<ActionResult<Livros>> DeleteLivro(int codigo)
        {
            var livro = await _context.Livros.FindAsync(codigo);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return livro;
        }

        private bool LivroExists(int codigo)
        {
            return _context.Livros.Any(l => l.Codigo == codigo);
        }
    }
}
