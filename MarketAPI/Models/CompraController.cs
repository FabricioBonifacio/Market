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

namespace MarketAPI.Models
{
    public class CompraController : ApiController
    {
        private ContextMarketAPI db = new ContextMarketAPI();

        // GET: api/Compra
        public List<Compra> GetCompras()
        {
            List<Compra> lista = db.Compras.Include(i => i.FormaPagamento).Include(i => i.Supermercado).ToList<Compra>();
            foreach (var compra in lista)
            {
                compra.DataTexto = compra.Data.ToString("dd/mm/yyyy");
                compra.Itens = db.Items.Where(i => i.CompraID == compra.ID).Include(i => i.Produto).ToList<Item>();
            }
            return lista;
        }

        // GET: api/Compra/5
        [ResponseType(typeof(Compra))]
        public IHttpActionResult GetCompra(int id)
        {
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return NotFound();
            }

            return Ok(compra);
        }

        // PUT: api/Compra/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompra(int id, Compra compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compra.ID)
            {
                return BadRequest();
            }

            db.Entry(compra).State = EntityState.Modified;
            db.Entry(compra.Supermercado).State = EntityState.Unchanged;
            db.FormaPagamentoes.Attach(compra.FormaPagamento);
            db.Entry(compra.FormaPagamento).State = EntityState.Unchanged;
            //foreach (var item in compra.Itens)
            //{
            //    db.Produtoes.Attach(item.Produto);
            //    db.Entry(item.Produto).State = EntityState.Unchanged;
            //    db.Categorias.Attach(item.Produto.Categoria);
            //    db.Entry(item.Produto.Categoria).State = EntityState.Unchanged;
            //    db.Unidades.Attach(item.Produto.Unidade);
            //    db.Entry(item.Produto.Unidade).State = EntityState.Unchanged;
            //}

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
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

        // POST: api/Compra
        [ResponseType(typeof(Compra))]
        public IHttpActionResult PostCompra(Compra compra)
        {
            compra.Data = Convert.ToDateTime(compra.DataTexto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Compras.Add(compra);
            db.Supermercado.Attach(compra.Supermercado);
            db.Entry(compra.Supermercado).State = EntityState.Unchanged;
            db.FormaPagamentoes.Attach(compra.FormaPagamento);
            db.Entry(compra.FormaPagamento).State = EntityState.Unchanged;
            //foreach (var item in compra.Itens)
            //{
            //    db.Produtoes.Attach(item.Produto);
            //    db.Entry(item.Produto).State = EntityState.Unchanged;
            //    db.Categorias.Attach(item.Produto.Categoria);
            //    db.Entry(item.Produto.Categoria).State = EntityState.Unchanged;
            //    db.Unidades.Attach(item.Produto.Unidade);
            //    db.Entry(item.Produto.Unidade).State = EntityState.Unchanged;   
            //}
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = compra.ID }, compra);
        }

        // DELETE: api/Compra/5
        [ResponseType(typeof(Compra))]
        public IHttpActionResult DeleteCompra(int id)
        {
            Compra compra = db.Compras.Find(id);
            
            if (compra == null)
            {
                return NotFound();
            }
            List<Item> itens = db.Items.Where(i => i.CompraID == compra.ID).ToList<Item>();
            db.Items.RemoveRange(itens);
            db.Compras.Remove(compra);
            db.SaveChanges();

            return Ok(compra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompraExists(int id)
        {
            return db.Compras.Count(e => e.ID == id) > 0;
        }
    }
}