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
    builder.EntitySet<Workshop>("Workshops");
    builder.EntitySet<Student>("Students"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class WorkshopsController : ODataController
    {
        private StudentPortalEntities db = new StudentPortalEntities();

        // GET: odata/Workshops
        [EnableQuery]
        public IQueryable<Workshop> GetWorkshops()
        {
            return db.Workshops;
        }

        // GET: odata/Workshops(5)
        [EnableQuery]
        public SingleResult<Workshop> GetWorkshop([FromODataUri] int key)
        {
            return SingleResult.Create(db.Workshops.Where(workshop => workshop.WID == key));
        }

        // PUT: odata/Workshops(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Workshop> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Workshop workshop = db.Workshops.Find(key);
            if (workshop == null)
            {
                return NotFound();
            }

            patch.Put(workshop);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(workshop);
        }

        // POST: odata/Workshops
        public IHttpActionResult Post(Workshop workshop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workshops.Add(workshop);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WorkshopExists(workshop.WID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(workshop);
        }

        // PATCH: odata/Workshops(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Workshop> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Workshop workshop = db.Workshops.Find(key);
            if (workshop == null)
            {
                return NotFound();
            }

            patch.Patch(workshop);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(workshop);
        }

        // DELETE: odata/Workshops(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Workshop workshop = db.Workshops.Find(key);
            if (workshop == null)
            {
                return NotFound();
            }

            db.Workshops.Remove(workshop);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Workshops(5)/Student
        [EnableQuery]
        public SingleResult<Student> GetStudent([FromODataUri] int key)
        {
            return SingleResult.Create(db.Workshops.Where(m => m.WID == key).Select(m => m.Student));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkshopExists(int key)
        {
            return db.Workshops.Count(e => e.WID == key) > 0;
        }
    }
}
