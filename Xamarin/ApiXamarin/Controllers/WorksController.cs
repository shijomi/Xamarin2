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
using ApiXamarin.Models;

namespace ApiXamarin.Controllers
{
    public class WorksController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Works
        public IQueryable<Work> GetWorks()
        {
            return db.Works;
        }

        // GET: api/Works/5
        [ResponseType(typeof(Work))]
        public IHttpActionResult GetWork(int id)
        {
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return NotFound();
            }

            return Ok(work);
        }

        // PUT: api/Works/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWork(int id, Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != work.WorkID)
            {
                return BadRequest();
            }

            db.Entry(work).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
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

        // POST: api/Works
        [ResponseType(typeof(Work))]
        public IHttpActionResult PostWork(Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Works.Add(work);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = work.WorkID }, work);
        }

        // DELETE: api/Works/5
        [ResponseType(typeof(Work))]
        public IHttpActionResult DeleteWork(int id)
        {
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return NotFound();
            }

            db.Works.Remove(work);
            db.SaveChanges();

            return Ok(work);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkExists(int id)
        {
            return db.Works.Count(e => e.WorkID == id) > 0;
        }
    }
}