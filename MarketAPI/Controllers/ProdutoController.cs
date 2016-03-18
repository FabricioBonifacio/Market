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
    public class ProdutoController : ApiController
    {
        private ContextMarketAPI db = new ContextMarketAPI();

        // GET: api/Produto
        public List<Produto> GetProdutoes()
        {
            List<Produto> list = db.Produtoes.Include(i => i.Categoria).Include(i => i.Unidade).ToList<Produto>();
            return list;
        }

        // GET: api/Produto/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult GetProduto(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // PUT: api/Produto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.ID)
            {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;
            db.Unidades.Attach(produto.Unidade);
            db.Entry(produto.Unidade).State = EntityState.Unchanged;
            db.Categorias.Attach(produto.Categoria);
            db.Entry(produto.Categoria).State = EntityState.Unchanged;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        // POST: api/Produto
        [ResponseType(typeof(Produto))]
        public IHttpActionResult PostProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produtoes.Add(produto);
            db.Unidades.Attach(produto.Unidade);
            db.Entry(produto.Unidade).State = EntityState.Unchanged;
            db.Categorias.Attach(produto.Categoria);
            db.Entry(produto.Categoria).State = EntityState.Unchanged;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produto.ID }, produto);
        }

        // DELETE: api/Produto/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult DeleteProduto(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            db.Produtoes.Remove(produto);
            db.SaveChanges();

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoExists(int id)
        {
            return db.Produtoes.Count(e => e.ID == id) > 0;
        }
    }
}