using System.Collections.Generic;
using System.Threading.Tasks;
using Aula3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        GufosContext context = new GufosContext();

        [HttpGet]

/// <summary>
/// Listagem de categoria
/// </summary>
/// <returns> </returns>
        public async Task<ActionResult<List<Categoria>>> Get(){
            List<Categoria> listaDeCategoria = await context.Categoria.ToListAsync();

            if(listaDeCategoria == null){
                return NotFound();
            }

            return listaDeCategoria;
        }
/// <summary>
/// Listagem de apenas uma categoria específica
/// </summary>
/// <param name="id"> </param>
/// <returns></returns>
        [HttpGet ("{id}")]
        public async Task<ActionResult<Categoria>> Get (int id){
            Categoria categoriaRetornada = await context.Categoria.FindAsync(id);

            if (categoriaRetornada == null)
            {
                return NotFound();
            }
            return categoriaRetornada;
        }
/// <summary>
/// Insere uma categoria
/// </summary>
/// <param name="categoria"></param>
/// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria){

            try
            {
            await context.Categoria.AddAsync(categoria);
            await context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return categoria;
        }
/// <summary>
/// Atualiza uma categoria em específico
/// </summary>
/// <param name="id"></param>
/// <param name="categoria"></param>
/// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Categoria categoria){
           Categoria categoriaRetornada = await context.Categoria.FindAsync(id);
           if (categoriaRetornada == null)
           {
               return NotFound();
           }

            categoriaRetornada.Titulo = categoria.Titulo;
            context.Categoria.Update(categoriaRetornada);
            await context.SaveChangesAsync();

            return NoContent();
        }
/// <summary>
/// 
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
        [HttpDelete ("{id}")]

        public async Task<ActionResult<Categoria>> Delete(int id){
            Categoria categoriaRetornada = await context.Categoria.FindAsync(id);
            if (categoriaRetornada == null){
                return NotFound();
            }
            context.Categoria.Remove(categoriaRetornada);
            await context.SaveChangesAsync();

            return categoriaRetornada;
        }

    }
}