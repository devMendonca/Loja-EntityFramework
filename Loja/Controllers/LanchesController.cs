using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Loja.Data;
using Loja.Models;

namespace Loja.
    Controllers

{
    public class LanchesController : ApiController
    {
        private LojaContext db = new LojaContext();

        // GET: api/Lanches
        public IQueryable<Lanche> GetLanches()
        {
            return db.Lanches;
        }

        // GET: api/Lanches/5
        [ResponseType(typeof(Lanche))]
        public async Task<IHttpActionResult> GetLanche(int id)
        {
            Lanche lanche = await db.Lanches.FindAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }

            return Ok(lanche);
        }

        // PUT: api/Lanches/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLanche(int id, Lanche lanche)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lanche.LancheId)
            {
                return BadRequest();
            }

            db.Entry(lanche).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancheExists(id))
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

        // POST: api/Lanches
        [ResponseType(typeof(Lanche))]
        public async Task<IHttpActionResult> PostLanche(Lanche lanche)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lanches.Add(lanche);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lanche.LancheId }, lanche);
        }

        // DELETE: api/Lanches/5
        [ResponseType(typeof(Lanche))]
        public async Task<IHttpActionResult> DeleteLanche(int id)
        {
            Lanche lanche = await db.Lanches.FindAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }

            db.Lanches.Remove(lanche);
            await db.SaveChangesAsync();

            return Ok(lanche);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LancheExists(int id)
        {
            return db.Lanches.Count(e => e.LancheId == id) > 0;
        }
    }
}