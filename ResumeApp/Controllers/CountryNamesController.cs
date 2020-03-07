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
using ResumeApp.Models;

namespace ResumeApp.Controllers
{
    public class CountryNamesController : ApiController
    {
        private DBCountryCityList db = new DBCountryCityList();

        // GET: api/CountryNames
        public IQueryable<CountryName> GetCountryNames()
        {
            return db.CountryNames;
        }

        // GET: api/CountryNames/5
        [ResponseType(typeof(CountryName))]
        public IHttpActionResult GetCountryName(int id)
        {
            CountryName countryName = db.CountryNames.Find(id);
            if (countryName == null)
            {
                return NotFound();
            }

            return Ok(countryName);
        }

        // PUT: api/CountryNames/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCountryName(int id, CountryName countryName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countryName.C_id)
            {
                return BadRequest();
            }

            db.Entry(countryName).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryNameExists(id))
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

        // POST: api/CountryNames
        [ResponseType(typeof(CountryName))]
        public IHttpActionResult PostCountryName(CountryName countryName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CountryNames.Add(countryName);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = countryName.C_id }, countryName);
        }

        // DELETE: api/CountryNames/5
        [ResponseType(typeof(CountryName))]
        public IHttpActionResult DeleteCountryName(int id)
        {
            CountryName countryName = db.CountryNames.Find(id);
            if (countryName == null)
            {
                return NotFound();
            }

            db.CountryNames.Remove(countryName);
            db.SaveChanges();

            return Ok(countryName);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryNameExists(int id)
        {
            return db.CountryNames.Count(e => e.C_id == id) > 0;
        }
    }
}