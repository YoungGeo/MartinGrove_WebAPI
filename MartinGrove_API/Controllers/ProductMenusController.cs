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
    public class ProductMenusController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/ProductMenus
        public IQueryable<ProductMenu> GetProductMenus()
        {
            return db.ProductMenus;
        }

        // GET: api/ProductMenus/5
        [ResponseType(typeof(ProductMenu))]
        public async Task<IHttpActionResult> GetProductMenu(int id)
        {
            ProductMenu productMenu = await db.ProductMenus.FindAsync(id);
            if (productMenu == null)
            {
                return NotFound();
            }

            return Ok(productMenu);
        }

        // PUT: api/ProductMenus/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductMenu(int id, ProductMenu productMenu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productMenu.ProductMenuId)
            {
                return BadRequest();
            }

            db.Entry(productMenu).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMenuExists(id))
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

        // POST: api/ProductMenus
        [ResponseType(typeof(ProductMenu))]
        public async Task<IHttpActionResult> PostProductMenu(ProductMenu productMenu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductMenus.Add(productMenu);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductMenuExists(productMenu.ProductMenuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productMenu.ProductMenuId }, productMenu);
        }

        // DELETE: api/ProductMenus/5
        [ResponseType(typeof(ProductMenu))]
        public async Task<IHttpActionResult> DeleteProductMenu(int id)
        {
            ProductMenu productMenu = await db.ProductMenus.FindAsync(id);
            if (productMenu == null)
            {
                return NotFound();
            }

            db.ProductMenus.Remove(productMenu);
            await db.SaveChangesAsync();

            return Ok(productMenu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductMenuExists(int id)
        {
            return db.ProductMenus.Count(e => e.ProductMenuId == id) > 0;
        }
    }
}