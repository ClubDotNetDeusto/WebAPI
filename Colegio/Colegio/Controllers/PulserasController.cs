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
using Colegio.Models;

namespace Colegio.Controllers
{
    public class PulserasController : ApiController
    {
        private ColegioContext db = new ColegioContext();

        // GET: api/Pulseras
        public IQueryable<Pulsera> GetPulseras()
        {
            return db.Pulseras;
        }

        // GET: api/Pulseras/5
        [ResponseType(typeof(Pulsera))]
        public IHttpActionResult GetPulsera(int id)
        {
            Pulsera pulsera = db.Pulseras.Find(id);
            if (pulsera == null)
            {
                return NotFound();
            }

            return Ok(pulsera);
        }

        // PUT: api/Pulseras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPulsera(int id, Pulsera pulsera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pulsera.PulseraID)
            {
                return BadRequest();
            }

            db.Entry(pulsera).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PulseraExists(id))
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

        // POST: api/Pulseras
        [ResponseType(typeof(Pulsera))]
        public IHttpActionResult PostPulsera(Pulsera pulsera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pulseras.Add(pulsera);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pulsera.PulseraID }, pulsera);
        }

        // DELETE: api/Pulseras/5
        [ResponseType(typeof(Pulsera))]
        public IHttpActionResult DeletePulsera(int id)
        {
            Pulsera pulsera = db.Pulseras.Find(id);
            if (pulsera == null)
            {
                return NotFound();
            }

            db.Pulseras.Remove(pulsera);
            db.SaveChanges();

            return Ok(pulsera);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PulseraExists(int id)
        {
            return db.Pulseras.Count(e => e.PulseraID == id) > 0;
        }
    }
}