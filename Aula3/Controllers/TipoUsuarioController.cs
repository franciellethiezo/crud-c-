using System.Collections.Generic;
using System.Threading.Tasks;
using Aula3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
         GufosContext context = new GufosContext();

        [HttpGet]
/// <summary>
/// 
/// </summary>
/// <returns></returns>
        public async Task<ActionResult<List<TipoUsuario>>> Get(){
            List<TipoUsuario> listaDeTipoUsuario = await context.TipoUsuario.ToListAsync();

            if(listaDeTipoUsuario == null){
                return NotFound();
            }

            return listaDeTipoUsuario;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<TipoUsuario>> Get (int id){
            TipoUsuario tipoUsuarioRetornado = await context.TipoUsuario.FindAsync(id);

            if (tipoUsuarioRetornado == null)
            {
                return NotFound();
            }
            return tipoUsuarioRetornado;
        }

        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> Post(TipoUsuario tipousuario){

            try
            {
            await context.TipoUsuario.AddAsync(tipousuario);
            await context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return tipousuario;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoUsuario>> Put(int id, TipoUsuario tipousuario){
            if (id != tipousuario.TipoUsuarioId)
            {
                return BadRequest();
            }
            context.Entry(tipousuario).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var TipoUsuarioValido = context.Usuario.FindAsync(id);
                if (TipoUsuarioValido == null)
                {
                   return NotFound(); 
                }
                else
                {
                    throw;
                } 
            }
            return Ok(tipousuario);
        }

        [HttpDelete ("{id}")]

        public async Task<ActionResult<TipoUsuario>> Delete(int id){
            TipoUsuario tipoUsuarioRetornado = await context.TipoUsuario.FindAsync(id);
            if (tipoUsuarioRetornado == null){
                return NotFound();
            }
            context.TipoUsuario.Remove(tipoUsuarioRetornado);
            await context.SaveChangesAsync();

            return tipoUsuarioRetornado;
        }
    }
}