using clusterRestaurante.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clusterRestaurante.Api.Controllers
{
    [ApiController]
    [Route("/api/dishes")]
    public class DishesController: ControllerBase
    {
        private readonly DataContext dataContext;

        public DishesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet] //Metodo get
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Dishes.ToListAsync());
        }

        [HttpGet("id:int")] //Metodo get pero con un id
        public async Task<IActionResult> GetAsync(int id)
        {
            var store = await dataContext.Dishes.FirstOrDefaultAsync(x => x.Id == id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost] //Metodo post
        public async Task<IActionResult> PostAsync(Dish dish)
        {
            dataContext.Dishes.Add(dish);
            await dataContext.SaveChangesAsync();
            return Ok(dish);
        }

        [HttpPut] //Metodo put
        public async Task<IActionResult> PutAsync(Dish dish)
        {
            dataContext.Dishes.Update(dish);
            await dataContext.SaveChangesAsync();
            return Ok(dish);
        }

        [HttpDelete("id:int")] //Metodo delete
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Dishes.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
