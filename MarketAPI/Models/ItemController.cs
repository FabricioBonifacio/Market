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
    public class ItemController : ApiController
    {
        private ContextMarketAPI db = new ContextMarketAPI();

        // GET: api/Item
        public IQueryable<Item> GetItems()
        {
            return db.Items;
        }

        // GET: api/Item/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/Item/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.ID)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;
            db.Produtoes.Attach(item.Produto);
            db.Entry(item.Produto).State = EntityState.Unchanged;
            db.Categorias.Attach(item.Produto.Categoria);
            db.Entry(item.Produto.Categoria).State = EntityState.Unchanged;
            db.Unidades.Attach(item.Produto.Unidade);
            db.Entry(item.Produto.Unidade).State = EntityState.Unchanged;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Item
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Items.Add(item);
            db.Produtoes.Attach(item.Produto);
            db.Entry(item.Produto).State = EntityState.Unchanged;
            db.Categorias.Attach(item.Produto.Categoria);
            db.Entry(item.Produto.Categoria).State = EntityState.Unchanged;
            db.Unidades.Attach(item.Produto.Unidade);
            db.Entry(item.Produto.Unidade).State = EntityState.Unchanged;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = item.ID }, item);
        }

        // DELETE: api/Item/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            Item item = db.Items.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            db.Items.Remove(item);
            db.SaveChanges();

            return Ok(item);

            //List<Item> itens = db.Items.Where(i => i.CompraID == id).ToList<Item>();

            //if (itens == null)
            //{
            //    return NotFound();
            //}

            //db.Items.RemoveRange(itens);
            //db.SaveChanges();

            //return Ok(itens);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.ID == id) > 0;
        }
    }
}