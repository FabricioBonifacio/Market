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
using MarketAPI.DAL;
using MarketAPI.Models;

namespace MarketAPI.Controllers
{
    public class UnidadeController : ApiController
    {
        private ContextMarketAPI db = new ContextMarketAPI();

        // GET: api/Unidade
        public IQueryable<Unidade> GetUnidades()
        {
            return db.Unidades;
        }

        // GET: api/Unidade/5
        [ResponseType(typeof(Unidade))]
        public IHttpActionResult GetUnidade(int id)
        {
            Unidade unidade = db.Unidades.Find(id);
            if (unidade == null)
            {
                return NotFound();
            }

            return Ok(unidade);
        }

        // PUT: api/Unidade/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUnidade(int id, Unidade unidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unidade.ID)
            {
                return BadRequest();
            }

            db.Entry(unidade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadeExists(id))
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

        // POST: api/Unidade
        [ResponseType(typeof(Unidade))]
        public IHttpActionResult PostUnidade(Unidade unidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Unidades.Add(unidade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unidade.ID }, unidade);
        }

        // DELETE: api/Unidade/5
        [ResponseType(typeof(Unidade))]
        public IHttpActionResult DeleteUnidade(int id)
        {
            Unidade unidade = db.Unidades.Find(id);
            if (unidade == null)
            {
                return NotFound();
            }

            db.Unidades.Remove(unidade);
            db.SaveChanges();

            return Ok(unidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnidadeExists(int id)
        {
            return db.Unidades.Count(e => e.ID == id) > 0;
        }
    }
}