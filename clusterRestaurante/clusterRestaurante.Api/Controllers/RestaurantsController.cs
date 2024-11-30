using clusterRestaurante.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clusterRestaurante.Api.Controllers
{
    [ApiController]
    [Route("/api/restaurants")]
    public class RestaurantsController: ControllerBase
    {
        private readonly DataContext dataContext;

        public RestaurantsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet] //Metodo get
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Restaurants.ToListAsync());
        }

        [HttpGet("id:int")] //Metodo get pero con un id
        public async Task<IActionResult> GetAsync(int id)
        {
            var store = await dataContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost] //Metodo post
        public async Task<IActionResult> PostAsync(Restaurant restaurant)
        {
            dataContext.Restaurants.Add(restaurant);
            await dataContext.SaveChangesAsync();
            return Ok(restaurant);
        }

        [HttpPut] //Metodo put
        public async Task<IActionResult> PutAsync(Restaurant restaurant)
        {
            dataContext.Restaurants.Update(restaurant);
            await dataContext.SaveChangesAsync();
            return Ok(restaurant);
        }

        [HttpDelete("id:int")] //Metodo delete
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Restaurants.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
