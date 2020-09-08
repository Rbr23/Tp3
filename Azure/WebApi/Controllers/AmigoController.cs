using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmigoController : ControllerBase
    {
        private readonly WebApiContext _context;

        public AmigoController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Amigo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amigo>>> GetAmigo()
        {
            return await _context.Amigo.FromSqlRaw("exec BuscarAmigo").ToListAsync();
        }

        // GET: api/Amigo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amigo>> GetAmigo(int id)
        {
            var amigo = await _context.Amigo.FindAsync(id);

            if (amigo == null)
            {
                return NotFound();
            }

            return amigo;
        }

        // PUT: api/Amigo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmigo(int id, Amigo amigo)
        {
            if (id != amigo.Id)
            {
                return BadRequest();
            }

            _context.Entry(amigo).State = EntityState.Modified;

            try
            {
               _context.Database.ExecuteSqlInterpolated($"@exec AlterarAmigo {amigo.Nome}, {amigo.Sobrenome}, {amigo.Email}, {amigo.Telefone}, {amigo.Nascimento}");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmigoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Amigo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Amigo>> PostAmigo(Amigo amigo)
        {
            
            _context.Database.ExecuteSqlInterpolated($"@exec AdicionarAmigo {amigo.Nome}, {amigo.Sobrenome}, {amigo.Email}, {amigo.Telefone}, {amigo.Nascimento}");

            return CreatedAtAction("GetAmigo", new { id = amigo.Id }, amigo);
        }

        // DELETE: api/Amigo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amigo>> DeleteAmigo(int id)
        {
            var amigo = await _context.Amigo.FindAsync(id);
            if (amigo == null)
            {
                return NotFound();
            }

            await _context.Database.ExecuteSqlInterpolatedAsync($"exec ExcluirAmigo {id}");

            return amigo;
        }

        private bool AmigoExists(int id)
        {
            return _context.Amigo.Any(e => e.Id == id);
        }
    }
}
