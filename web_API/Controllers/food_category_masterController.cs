using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using web_API.Models;

namespace web_API.Controllers
{
    public class food_category_masterController : ApiController
    {
        private canteen_manege_systemEntities6 db = new canteen_manege_systemEntities6();

        // GET: api/food_category_master
        public IQueryable<food_category_master> Getfood_category_master()
        {
            return db.food_category_master;
        }

        // GET: api/food_category_master/5
        [ResponseType(typeof(food_category_master))]
        public IHttpActionResult Getfood_category_master(int id)
        {
            food_category_master food_category_master = db.food_category_master.Find(id);
            if (food_category_master == null)
            {
                return NotFound();
            }

            return Ok(food_category_master);
        }

        // PUT: api/food_category_master/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfood_category_master(int id, food_category_master food_category_master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != food_category_master.food_cat_id)
            {
                return BadRequest();
            }

            db.Entry(food_category_master).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!food_category_masterExists(id))
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

        // POST: api/food_category_master
        [ResponseType(typeof(food_category_master))]
        public IHttpActionResult Postfood_category_master(food_category_master food_category_master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.food_category_master.Add(food_category_master);
           
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = food_category_master.food_cat_id }, food_category_master);
        }

        // DELETE: api/food_category_master/5
        [ResponseType(typeof(food_category_master))]
        public IHttpActionResult Deletefood_category_master(int id)
        {
            food_category_master food_category_master = db.food_category_master.Find(id);
            if (food_category_master == null)
            {
                return NotFound();
            }

            db.food_category_master.Remove(food_category_master);
            db.SaveChanges();

            return Ok(food_category_master);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool food_category_masterExists(int id)
        {
            return db.food_category_master.Count(e => e.food_cat_id == id) > 0;
        }
    }
}