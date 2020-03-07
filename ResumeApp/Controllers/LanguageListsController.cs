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
    public class LanguageListsController : ApiController
    {
        private Resume_Language_Skill_Entities db = new Resume_Language_Skill_Entities();

        // GET: api/LanguageLists
        public IQueryable<LanguageList> GetLanguageLists()
        {
            return db.LanguageLists;
        }

        // GET: api/LanguageLists/5
        [ResponseType(typeof(LanguageList))]
        public IHttpActionResult GetLanguageList(int id)
        {
            LanguageList languageList = db.LanguageLists.Find(id);
            if (languageList == null)
            {
                return NotFound();
            }

            return Ok(languageList);
        }

        // PUT: api/LanguageLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLanguageList(int id, LanguageList languageList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != languageList.id)
            {
                return BadRequest();
            }

            db.Entry(languageList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageListExists(id))
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

        // POST: api/LanguageLists
        [ResponseType(typeof(LanguageList))]
        public IHttpActionResult PostLanguageList(LanguageList languageList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LanguageLists.Add(languageList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = languageList.id }, languageList);
        }

        // DELETE: api/LanguageLists/5
        [ResponseType(typeof(LanguageList))]
        public IHttpActionResult DeleteLanguageList(int id)
        {
            LanguageList languageList = db.LanguageLists.Find(id);
            if (languageList == null)
            {
                return NotFound();
            }

            db.LanguageLists.Remove(languageList);
            db.SaveChanges();

            return Ok(languageList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LanguageListExists(int id)
        {
            return db.LanguageLists.Count(e => e.id == id) > 0;
        }
    }
}