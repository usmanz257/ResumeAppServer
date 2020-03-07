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
    public class SkillListsController : ApiController
    {
        private Resume_Language_Skill_Entities db = new Resume_Language_Skill_Entities();

        // GET: api/SkillLists
        public IQueryable<SkillList> GetSkillLists()
        {
            return db.SkillLists;
        }

        // GET: api/SkillLists/5
        [ResponseType(typeof(SkillList))]
        public IHttpActionResult GetSkillList(int id)
        {
            SkillList skillList = db.SkillLists.Find(id);
            if (skillList == null)
            {
                return NotFound();
            }

            return Ok(skillList);
        }

        // PUT: api/SkillLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkillList(int id, SkillList skillList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skillList.id)
            {
                return BadRequest();
            }

            db.Entry(skillList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillListExists(id))
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

        // POST: api/SkillLists
        [ResponseType(typeof(SkillList))]
        public IHttpActionResult PostSkillList(SkillList skillList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SkillLists.Add(skillList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = skillList.id }, skillList);
        }

        // DELETE: api/SkillLists/5
        [ResponseType(typeof(SkillList))]
        public IHttpActionResult DeleteSkillList(int id)
        {
            SkillList skillList = db.SkillLists.Find(id);
            if (skillList == null)
            {
                return NotFound();
            }

            db.SkillLists.Remove(skillList);
            db.SaveChanges();

            return Ok(skillList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkillListExists(int id)
        {
            return db.SkillLists.Count(e => e.id == id) > 0;
        }
    }
}