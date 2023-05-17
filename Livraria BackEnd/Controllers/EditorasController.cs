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
    [Route("api/Editoras")]
    [ApiController]
    public class EditorasController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public EditorasController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Editoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editoras>>> GetAll()
        {
            return await _context.Editoras.ToListAsync();
        }

        // GET: api/Editoras/{codigo}
        [HttpGet("{codeditora}")]
        public async Task<ActionResult<Editoras>> GetEditora(int codeditora)
        {
            var editora = await _context.Editoras.FindAsync(codeditora);
            if (editora == null)
            {
                return NotFound();
            }

            return editora;
        }

        // PUT: api/Editoras/{codEditora}
        [HttpPut("{codeditora}")]
        public async Task<IActionResult> PutEditora(int codeditora, Editoras editora)
        {
            if (codeditora != editora.CodEditora)
            {
                return BadRequest();
            }

            _context.Entry(editora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }

            return NoContent();

        }

        //POST: api/Editoras
        [HttpPost]
        public async Task<ActionResult<Editoras>> PostEditora(Editoras editora)
        {
            _context.Editoras.Add(editora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditora", new { codeditora = editora.CodEditora }, editora);
        }

        // GET: api/Editoras/teste
        [HttpGet("teste")]
        public ActionResult teste()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("Select * from Editoras");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Editoras/{codeditora}
        [HttpDelete("{codeditora}")]
        public async Task<ActionResult<Editoras>> DeleteEditora(int codeditora)
        {
            var editora = await _context.Editoras.FindAsync(codeditora);
            if (editora == null)
            {
                return NotFound();
            }

            _context.Editoras.Remove(editora);
            await _context.SaveChangesAsync();

            return editora;
        }

        private bool EditoraExists(int codeditora)
        {
            return _context.Editoras.Any(e => e.CodEditora == codeditora);
        }
    }
}
