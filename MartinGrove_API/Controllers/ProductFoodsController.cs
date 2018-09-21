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
    public class ProductFoodsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/ProductFoods
        public IQueryable<ProductFood> GetProductFoods()
        {
            return db.ProductFoods;
        }

        // GET: api/ProductFoods/5
        [ResponseType(typeof(ProductFood))]
        public async Task<IHttpActionResult> GetProductFood(int id)
        {
            ProductFood productFood = await db.ProductFoods.FindAsync(id);
            if (productFood == null)
            {
                return NotFound();
            }

            return Ok(productFood);
        }

        // PUT: api/ProductFoods/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductFood(int id, ProductFood productFood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productFood.FoodId)
            {
                return BadRequest();
            }

            db.Entry(productFood).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductFoodExists(id))
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

        // POST: api/ProductFoods
        [ResponseType(typeof(ProductFood))]
        public async Task<IHttpActionResult> PostProductFood(ProductFood productFood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductFoods.Add(productFood);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductFoodExists(productFood.FoodId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productFood.FoodId }, productFood);
        }

        // DELETE: api/ProductFoods/5
        [ResponseType(typeof(ProductFood))]
        public async Task<IHttpActionResult> DeleteProductFood(int id)
        {
            ProductFood productFood = await db.ProductFoods.FindAsync(id);
            if (productFood == null)
            {
                return NotFound();
            }

            db.ProductFoods.Remove(productFood);
            await db.SaveChangesAsync();

            return Ok(productFood);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductFoodExists(int id)
        {
            return db.ProductFoods.Count(e => e.FoodId == id) > 0;
        }
    }
}