using clusterRestaurante.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clusterRestaurante.Api.Controllers
{
    [ApiController]
    [Route("/api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext dataContext;

        public EmployeesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet] //Metodo get
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Employees.ToListAsync());
        }

        [HttpGet("id:int")] //Metodo get pero con un id
        public async Task<IActionResult> GetAsync(int id)
        {
            var store = await dataContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost] //Metodo post
        public async Task<IActionResult> PostAsync(Employee employee)
        {
            dataContext.Employees.Add(employee);
            await dataContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut] //Metodo put
        public async Task<IActionResult> PutAsync(Employee employee)
        {
            dataContext.Employees.Update(employee);
            await dataContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete("id:int")] //Metodo delete
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Employees.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
