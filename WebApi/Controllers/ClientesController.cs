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
using WebApi.Context;
using WebApi.Models.Entity;

namespace WebApi.Controllers
{
    [RoutePrefix("api/v1/clientes")]
    public class ClientesController : ApiController
    {
        private BeInTouchContext db = new BeInTouchContext();

        [HttpGet]
        [Route("")]
        // GET: api/v1/clientes
        public IQueryable<Cliente> GetClientes()
        {
            return db.Clientes;
        }

        [HttpGet]
        [Route("{id:int}")]
        // GET: api/v1/clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPut]
        [Route("{id:int}")]
        // PUT: api/v1/clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente(int id, [FromBody]Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        [HttpPost]
        [Route("")]
        // POST: api/v1/clientes
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente([FromBody]Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(cliente);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        // DELETE: api/v1/clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        [Route("{id:int}/existe")]
        // GET: api/v1/clientes/5/existe
        public bool ClienteExists(int id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }
    }
}