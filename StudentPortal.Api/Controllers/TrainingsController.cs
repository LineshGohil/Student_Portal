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
    builder.EntitySet<Training>("Trainings");
    builder.EntitySet<Student>("Students"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TrainingsController : ODataController
    {
        private StudentPortalEntities db = new StudentPortalEntities();

        // GET: odata/Trainings
        [EnableQuery]
        public IQueryable<Training> GetTrainings()
        {
            return db.Trainings;
        }

        // GET: odata/Trainings(5)
        [EnableQuery]
        public SingleResult<Training> GetTraining([FromODataUri] int key)
        {
            return SingleResult.Create(db.Trainings.Where(training => training.TID == key));
        }

        // PUT: odata/Trainings(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Training> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Training training = db.Trainings.Find(key);
            if (training == null)
            {
                return NotFound();
            }

            patch.Put(training);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(training);
        }

        // POST: odata/Trainings
        public IHttpActionResult Post(Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trainings.Add(training);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrainingExists(training.TID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(training);
        }

        // PATCH: odata/Trainings(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Training> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Training training = db.Trainings.Find(key);
            if (training == null)
            {
                return NotFound();
            }

            patch.Patch(training);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(training);
        }

        // DELETE: odata/Trainings(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Training training = db.Trainings.Find(key);
            if (training == null)
            {
                return NotFound();
            }

            db.Trainings.Remove(training);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Trainings(5)/Student
        [EnableQuery]
        public SingleResult<Student> GetStudent([FromODataUri] int key)
        {
            return SingleResult.Create(db.Trainings.Where(m => m.TID == key).Select(m => m.Student));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingExists(int key)
        {
            return db.Trainings.Count(e => e.TID == key) > 0;
        }
    }
}
