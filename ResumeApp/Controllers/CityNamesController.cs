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
    public class CityNamesController : ApiController
    {
        private DBCountryCityList db = new DBCountryCityList();

        // GET: api/CityNames
        public IQueryable<CityName> GetCityNames()
        {
            return db.CityNames;
        }

        public IQueryable<CityName> GetCityNamesById(int id)
        {
            CityName cityName = db.CityNames.Find(id);
            return db.CityNames;
            //List<CityName> cityName = db.CityNames.Where( data=>data.C_id = id).Select(data =>data.CityName1).Distinct().ToList();
            //return db.CityNames;
        }

        // GET: api/CityNames/5
        [ResponseType(typeof(CityName))]
        public IHttpActionResult GetCityName(int id)
        {
            CityName cityName = db.CityNames.Find(id);
            if (cityName == null)
            {
                return NotFound();
            }

            return Ok(cityName);
        }

        // PUT: api/CityNames/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCityName(int id, CityName cityName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cityName.id)
            {
                return BadRequest();
            }

            db.Entry(cityName).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityNameExists(id))
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

        // POST: api/CityNames
        [ResponseType(typeof(CityName))]
        public IHttpActionResult PostCityName(CityName cityName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CityNames.Add(cityName);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cityName.id }, cityName);
        }

        // DELETE: api/CityNames/5
        [ResponseType(typeof(CityName))]
        public IHttpActionResult DeleteCityName(int id)
        {
            CityName cityName = db.CityNames.Find(id);
            if (cityName == null)
            {
                return NotFound();
            }

            db.CityNames.Remove(cityName);
            db.SaveChanges();

            return Ok(cityName);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityNameExists(int id)
        {
            return db.CityNames.Count(e => e.id == id) > 0;
        }
    }
}