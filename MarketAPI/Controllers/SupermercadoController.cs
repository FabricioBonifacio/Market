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
    public class SupermercadoController : ApiController
    {
        private ContextMarketAPI db = new ContextMarketAPI();

        // GET: api/Supermercado
        public List<Supermercado> GetSupermercado()
        {
            return db.Supermercado.ToList<Supermercado>();
        }
        //public IQueryable<Supermercado> GetSupermercado()
        //{
        //    return db.Supermercado;
        //}

        // GET: api/Supermercado/5
        [ResponseType(typeof(Supermercado))]
        public IHttpActionResult GetSupermercado(int id)
        {
            Supermercado supermercado = db.Supermercado.Find(id);
            if (supermercado == null)
            {
                return NotFound();
            }

            return Ok(supermercado);
        }

        // PUT: api/Supermercado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupermercado(int id, Supermercado supermercado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supermercado.ID)
            {
                return BadRequest();
            }

            db.Entry(supermercado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupermercadoExists(id))
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

        // POST: api/Supermercado
        [ResponseType(typeof(Supermercado))]
        public IHttpActionResult PostSupermercado(Supermercado supermercado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Supermercado.Add(supermercado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supermercado.ID }, supermercado);
        }

        // DELETE: api/Supermercado/5
        [ResponseType(typeof(Supermercado))]
        public IHttpActionResult DeleteSupermercado(int id)
        {
            Supermercado supermercado = db.Supermercado.Find(id);
            if (supermercado == null)
            {
                return NotFound();
            }

            db.Supermercado.Remove(supermercado);
            db.SaveChanges();

            return Ok(supermercado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupermercadoExists(int id)
        {
            return db.Supermercado.Count(e => e.ID == id) > 0;
        }
    }
}