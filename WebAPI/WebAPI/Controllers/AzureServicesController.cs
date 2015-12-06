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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AzureServicesController : ApiController
    {
        private AzureServicesContext db = new AzureServicesContext();

        // GET: api/AzureServices
        public IQueryable<AzureService> GetAzureServices()
        {
            return db.AzureServices;
        }

        // GET: api/AzureServices/5
        [ResponseType(typeof(AzureService))]
        public IHttpActionResult GetAzureService(int id)
        {
            AzureService azureService = db.AzureServices.Find(id);
            if (azureService == null)
            {
                return NotFound();
            }

            return Ok(azureService);
        }

        // PUT: api/AzureServices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAzureService(int id, AzureService azureService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != azureService.AzureServiceID)
            {
                return BadRequest();
            }

            db.Entry(azureService).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AzureServiceExists(id))
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

        // POST: api/AzureServices
        [ResponseType(typeof(AzureService))]
        public IHttpActionResult PostAzureService(AzureService azureService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AzureServices.Add(azureService);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = azureService.AzureServiceID }, azureService);
        }

        // DELETE: api/AzureServices/5
        [ResponseType(typeof(AzureService))]
        public IHttpActionResult DeleteAzureService(int id)
        {
            AzureService azureService = db.AzureServices.Find(id);
            if (azureService == null)
            {
                return NotFound();
            }

            db.AzureServices.Remove(azureService);
            db.SaveChanges();

            return Ok(azureService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AzureServiceExists(int id)
        {
            return db.AzureServices.Count(e => e.AzureServiceID == id) > 0;
        }
    }
}