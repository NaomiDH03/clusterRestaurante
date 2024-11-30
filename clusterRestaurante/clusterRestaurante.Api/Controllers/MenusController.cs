using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using clusterRestaurante.Shared.Entities;

namespace clusterRestaurante.Api.Controllers
{

    [ApiController]
    [Route("/api/menus")]
    public class MenusController : ControllerBase
    {
        private readonly DataContext dataContext;

        public MenusController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet] //Metodo get
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Menus.ToListAsync());
        }

        [HttpGet("id:int")] //Metodo get pero con un id
        public async Task<IActionResult> GetAsync(int id)
        {
            var store = await dataContext.Menus.FirstOrDefaultAsync(x => x.Id == id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost] //Metodo post
        public async Task<IActionResult> PostAsync(Menu menu)
        {
            dataContext.Menus.Add(menu);
            await dataContext.SaveChangesAsync();
            return Ok(menu);
        }

        [HttpPut] //Metodo put
        public async Task<IActionResult> PutAsync(Menu menu)
        {
            dataContext.Menus.Update(menu);
            await dataContext.SaveChangesAsync();
            return Ok(menu);
        }

        [HttpDelete("id:int")] //Metodo delete
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Menus.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
