using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;

namespace testeef.Controllers
{
    [ApiController]
    [Route("v1/products")]

    public class CategoryController : ControllerBase
    {
    // private DataContext _context;

    // public CategoryController(DataContext context)
    // {
    //     _context=context;
    // }

    
        [HttpGet]
        [Route("")]

        public async Task<ActionsResult<List<Product>>> Get([FromServices] DataContext context)
        {
            
            var products = await context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionsResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            
            var product = await context.Products.Include(x => x.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [HttpGet]
        [Route("{categories/{id:int}")]

        public async Task<ActionsResult<List<Product>>> GetByCategory([FromServices] DataContext context, int id)
        {
            
            var products = await context.Products.Include(x => x.Category)
            .AsNoTracking()
            .Where(x => x.CategoryId == id)
            .ToListAsync();
            return products;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
            {
                if (ModelState.IsValid)
                {
                    context.Products.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
    }
}