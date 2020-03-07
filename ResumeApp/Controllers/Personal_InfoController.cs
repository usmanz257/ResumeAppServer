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
    public class Personal_InfoController : ApiController
    {
        private Resume_DBEntities db = new Resume_DBEntities();

        // GET: api/Personal_Info
        public IQueryable<Personal_Info> GetPersonal_Info()
        {
            return db.Personal_Info;
        }

        // GET: api/Personal_Info/5
        [ResponseType(typeof(Personal_Info))]
        public IHttpActionResult GetPersonal_Info(int id)
        {
            Personal_Info personal_Info = db.Personal_Info.Find(id);
            if (personal_Info == null)
            {
                return NotFound();
            }

            return Ok(personal_Info);
        }

        // PUT: api/Personal_Info/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonal_Info(int id, Personal_Info personal_Info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personal_Info.CandidateId)
            {
                return BadRequest();
            }

            db.Entry(personal_Info).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Personal_InfoExists(id))
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

        // POST: api/Personal_Info
        [ResponseType(typeof(Personal_Info))]
        public IHttpActionResult PostPersonal_Info(Personal_Info personal_Info)
        {
            try { 
                //Personal info
                   db.Personal_Info.Add(personal_Info);
                // Personal Experience

                db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personal_Info.CandidateId }, personal_Info);
        }
            catch (Exception ex)
            {
                throw ex;
            }
            }
        // DELETE: api/Personal_Info/5
        [ResponseType(typeof(Personal_Info))]
        public IHttpActionResult DeletePersonal_Info(int id)
        {
            Personal_Info personal_Info = db.Personal_Info.Find(id);
            if (personal_Info == null)
            {
                return NotFound();
            }

            db.Personal_Info.Remove(personal_Info);
            db.SaveChanges();

            return Ok(personal_Info);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Personal_InfoExists(int id)
        {
            return db.Personal_Info.Count(e => e.CandidateId == id) > 0;
        }
    }
}