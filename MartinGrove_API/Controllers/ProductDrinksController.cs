using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MartinGrove_API.DataClasses;
using MartinGrove_API.Models;

namespace MartinGrove_API.Controllers
{
    public class ProductDrinksController : ApiController
    {
        
        private Entities db = new Entities();
        
        // GET: api/ProductDrinks
        public IQueryable<ProductDrink> GetProductDrinks()
        {
            return db.ProductDrinks;
        }

        // GET: api/ProductDrinks/5
        [ResponseType(typeof(ProductDrink))]
        public async Task<IHttpActionResult> GetProductDrink(int id)
        {
            ProductDrink productDrink = await db.ProductDrinks.FindAsync(id);
            if (productDrink == null)
            {
                return NotFound();
            }

            return Ok(productDrink);
        }

        // PUT: api/ProductDrinks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductDrink(int id, ProductDrink productDrink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDrink.DrinkId)
            {
                return BadRequest();
            }

            db.Entry(productDrink).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDrinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductDrinks
        [ResponseType(typeof(ProductDrink))]
        public async Task<IHttpActionResult> PostProductDrink(ProductDrink productDrink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductDrinks.Add(productDrink);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductDrinkExists(productDrink.DrinkId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productDrink.DrinkId }, productDrink);
        }

        // DELETE: api/ProductDrinks/5
        [ResponseType(typeof(ProductDrink))]
        public async Task<IHttpActionResult> DeleteProductDrink(int id)
        {
            ProductDrink productDrink = await db.ProductDrinks.FindAsync(id);
            if (productDrink == null)
            {
                return NotFound();
            }

            db.ProductDrinks.Remove(productDrink);
            await db.SaveChangesAsync();

            return Ok(productDrink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductDrinkExists(int id)
        {
            return db.ProductDrinks.Count(e => e.DrinkId == id) > 0;
        }
    }
}