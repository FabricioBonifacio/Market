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
    public class FormaPagamentoController : ApiController
    {
        private ContextMarketAPI db = new ContextMarketAPI();

        // GET: api/FormaPagamento
        public IQueryable<FormaPagamento> GetFormaPagamentoes()
        {
            return db.FormaPagamentoes;
        }

        // GET: api/FormaPagamento/5
        [ResponseType(typeof(FormaPagamento))]
        public IHttpActionResult GetFormaPagamento(int id)
        {
            FormaPagamento formaPagamento = db.FormaPagamentoes.Find(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return Ok(formaPagamento);
        }

        // PUT: api/FormaPagamento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFormaPagamento(int id, FormaPagamento formaPagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formaPagamento.ID)
            {
                return BadRequest();
            }

            db.Entry(formaPagamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormaPagamentoExists(id))
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

        // POST: api/FormaPagamento
        [ResponseType(typeof(FormaPagamento))]
        public IHttpActionResult PostFormaPagamento(FormaPagamento formaPagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FormaPagamentoes.Add(formaPagamento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = formaPagamento.ID }, formaPagamento);
        }

        // DELETE: api/FormaPagamento/5
        [ResponseType(typeof(FormaPagamento))]
        public IHttpActionResult DeleteFormaPagamento(int id)
        {
            FormaPagamento formaPagamento = db.FormaPagamentoes.Find(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            db.FormaPagamentoes.Remove(formaPagamento);
            db.SaveChanges();

            return Ok(formaPagamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FormaPagamentoExists(int id)
        {
            return db.FormaPagamentoes.Count(e => e.ID == id) > 0;
        }
    }
}