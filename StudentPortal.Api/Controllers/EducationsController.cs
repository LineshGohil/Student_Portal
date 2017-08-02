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
    builder.EntitySet<Education>("Educations");
    builder.EntitySet<Student>("Students"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EducationsController : ODataController
    {
        private StudentPortalEntities db = new StudentPortalEntities();

        // GET: odata/Educations
        [EnableQuery]
        public IQueryable<Education> GetEducations()
        {
            return db.Educations;
        }

        // GET: odata/Educations(5)
        [EnableQuery]
        public SingleResult<Education> GetEducation([FromODataUri] int key)
        {
            return SingleResult.Create(db.Educations.Where(education => education.EID == key));
        }

        // PUT: odata/Educations(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Education> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Education education = db.Educations.Find(key);
            if (education == null)
            {
                return NotFound();
            }

            patch.Put(education);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(education);
        }

        // POST: odata/Educations
        public IHttpActionResult Post(Education education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Educations.Add(education);
            db.SaveChanges();

            return Created(education);
        }

        // PATCH: odata/Educations(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Education> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Education education = db.Educations.Find(key);
            if (education == null)
            {
                return NotFound();
            }

            patch.Patch(education);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(education);
        }

        // DELETE: odata/Educations(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Education education = db.Educations.Find(key);
            if (education == null)
            {
                return NotFound();
            }

            db.Educations.Remove(education);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Educations(5)/Student
        [EnableQuery]
        public SingleResult<Student> GetStudent([FromODataUri] int key)
        {
            return SingleResult.Create(db.Educations.Where(m => m.EID == key).Select(m => m.Student));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EducationExists(int key)
        {
            return db.Educations.Count(e => e.EID == key) > 0;
        }
    }
}
