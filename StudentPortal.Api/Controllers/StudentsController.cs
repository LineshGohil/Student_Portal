using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using StudentPortal.Data;

namespace StudentPortal.Api.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using StudentPortal.Data;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Student>("Students");
    builder.EntitySet<Education>("Educations"); 
    builder.EntitySet<Intership>("Interships"); 
    builder.EntitySet<Training>("Trainings"); 
    builder.EntitySet<Workshop>("Workshops"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StudentsController : ODataController
    {
        private StudentPortalEntities db = new StudentPortalEntities();

        // GET: odata/Students
        [EnableQuery]
        public IQueryable<Student> GetStudents()
        {
            return db.Students;
        }

        // GET: odata/Students(5)
        [EnableQuery]
        public SingleResult<Student> GetStudent([FromODataUri] int key)
        {
            return SingleResult.Create(db.Students.Where(student => student.StudId == key));
        }

        // PUT: odata/Students(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Student> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student student = db.Students.Find(key);
            if (student == null)
            {
                return NotFound();
            }

            patch.Put(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(student);
        }

        // POST: odata/Students
        public IHttpActionResult Post(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            db.SaveChanges();

            return Created(student);
        }

        // PATCH: odata/Students(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Student> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student student = db.Students.Find(key);
            if (student == null)
            {
                return NotFound();
            }

            patch.Patch(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(student);
        }

        // DELETE: odata/Students(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Student student = db.Students.Find(key);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Students(5)/Educations
        [EnableQuery]
        public IQueryable<Education> GetEducations([FromODataUri] int key)
        {
            return db.Students.Where(m => m.StudId == key).SelectMany(m => m.Educations);
        }

        // GET: odata/Students(5)/Interships
        [EnableQuery]
        public IQueryable<Intership> GetInterships([FromODataUri] int key)
        {
            return db.Students.Where(m => m.StudId == key).SelectMany(m => m.Interships);
        }

        // GET: odata/Students(5)/Trainings
        [EnableQuery]
        public IQueryable<Training> GetTrainings([FromODataUri] int key)
        {
            return db.Students.Where(m => m.StudId == key).SelectMany(m => m.Trainings);
        }

        // GET: odata/Students(5)/Workshops
        [EnableQuery]
        public IQueryable<Workshop> GetWorkshops([FromODataUri] int key)
        {
            return db.Students.Where(m => m.StudId == key).SelectMany(m => m.Workshops);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int key)
        {
            return db.Students.Count(e => e.StudId == key) > 0;
        }
    }
}
