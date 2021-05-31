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

namespace Loja.Controllers
{
    public class BebidasController : ApiController
    {
        private LojaContext db = new LojaContext();

        // GET: api/Bebidas
        public IQueryable<Bebida> GetBebidas()
        {
            return db.Bebidas;
        }

        // GET: api/Bebidas/5
        [ResponseType(typeof(Bebida))]
        public async Task<IHttpActionResult> GetBebida(int id)
        {
            Bebida bebida = await db.Bebidas.FindAsync(id);
            if (bebida == null)
            {
                return NotFound();
            }

            return Ok(bebida);
        }

        // PUT: api/Bebidas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBebida(int id, Bebida bebida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bebida.BebidaId)
            {
                return BadRequest();
            }

            db.Entry(bebida).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BebidaExists(id))
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

        // POST: api/Bebidas
        [ResponseType(typeof(Bebida))]
        public async Task<IHttpActionResult> PostBebida(Bebida bebida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bebidas.Add(bebida);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bebida.BebidaId }, bebida);
        }

        // DELETE: api/Bebidas/5
        [ResponseType(typeof(Bebida))]
        public async Task<IHttpActionResult> DeleteBebida(int id)
        {
            Bebida bebida = await db.Bebidas.FindAsync(id);
            if (bebida == null)
            {
                return NotFound();
            }

            db.Bebidas.Remove(bebida);
            await db.SaveChangesAsync();

            return Ok(bebida);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BebidaExists(int id)
        {
            return db.Bebidas.Count(e => e.BebidaId == id) > 0;
        }
    }
}