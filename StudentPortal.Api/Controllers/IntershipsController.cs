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
    builder.EntitySet<Intership>("Interships");
    builder.EntitySet<Student>("Students"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class IntershipsController : ODataController
    {
        private StudentPortalEntities db = new StudentPortalEntities();

        // GET: odata/Interships
        [EnableQuery]
        public IQueryable<Intership> GetInterships()
        {
            return db.Interships;
        }

        // GET: odata/Interships(5)
        [EnableQuery]
        public SingleResult<Intership> GetIntership([FromODataUri] int key)
        {
            return SingleResult.Create(db.Interships.Where(intership => intership.IID == key));
        }

        // PUT: odata/Interships(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Intership> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Intership intership = db.Interships.Find(key);
            if (intership == null)
            {
                return NotFound();
            }

            patch.Put(intership);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntershipExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(intership);
        }

        // POST: odata/Interships
        public IHttpActionResult Post(Intership intership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Interships.Add(intership);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IntershipExists(intership.IID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(intership);
        }

        // PATCH: odata/Interships(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Intership> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Intership intership = db.Interships.Find(key);
            if (intership == null)
            {
                return NotFound();
            }

            patch.Patch(intership);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntershipExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(intership);
        }

        // DELETE: odata/Interships(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Intership intership = db.Interships.Find(key);
            if (intership == null)
            {
                return NotFound();
            }

            db.Interships.Remove(intership);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Interships(5)/Student
        [EnableQuery]
        public SingleResult<Student> GetStudent([FromODataUri] int key)
        {
            return SingleResult.Create(db.Interships.Where(m => m.IID == key).Select(m => m.Student));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IntershipExists(int key)
        {
            return db.Interships.Count(e => e.IID == key) > 0;
        }
    }
}
