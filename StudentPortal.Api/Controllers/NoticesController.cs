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
    builder.EntitySet<Notice>("Notices");
    builder.EntitySet<Teacher>("Teachers"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class NoticesController : ODataController
    {
        private StudentPortalEntities db = new StudentPortalEntities();

        // GET: odata/Notices
        [EnableQuery]
        public IQueryable<Notice> GetNotices()
        {
            return db.Notices;
        }

        // GET: odata/Notices(5)
        [EnableQuery]
        public SingleResult<Notice> GetNotice([FromODataUri] int key)
        {
            return SingleResult.Create(db.Notices.Where(notice => notice.NID == key));
        }

        // PUT: odata/Notices(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Notice> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Notice notice = db.Notices.Find(key);
            if (notice == null)
            {
                return NotFound();
            }

            patch.Put(notice);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(notice);
        }

        // POST: odata/Notices
        public IHttpActionResult Post(Notice notice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notices.Add(notice);
            db.SaveChanges();

            return Created(notice);
        }

        // PATCH: odata/Notices(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Notice> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Notice notice = db.Notices.Find(key);
            if (notice == null)
            {
                return NotFound();
            }

            patch.Patch(notice);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(notice);
        }

        // DELETE: odata/Notices(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Notice notice = db.Notices.Find(key);
            if (notice == null)
            {
                return NotFound();
            }

            db.Notices.Remove(notice);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Notices(5)/Teacher
        [EnableQuery]
        public SingleResult<Teacher> GetTeacher([FromODataUri] int key)
        {
            return SingleResult.Create(db.Notices.Where(m => m.NID == key).Select(m => m.Teacher));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoticeExists(int key)
        {
            return db.Notices.Count(e => e.NID == key) > 0;
        }
    }
}
