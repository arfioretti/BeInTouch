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
using WebApi.Repository;

namespace WebApi.Controllers
{
    [RoutePrefix("api/v1/clientes")]
    public class ClientesController : ApiController
    {
        private readonly IClientesRepository _clientesRepository;

        public ClientesController(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        [HttpGet]
        [Route("")]
        // GET: api/v1/clientes
        public IQueryable<Cliente> GetClientes()
        {
            return _clientesRepository.GetClientes();
        }

        [HttpGet]
        [Route("{id:int}")]
        // GET: api/v1/clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = _clientesRepository.GetCliente(id);

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
            bool bRet;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            bRet = _clientesRepository.PutCliente(id, cliente);

            if (bRet == false) return BadRequest();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("")]
        // POST: api/v1/clientes
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente([FromBody]Cliente cliente)
        {
            bool bRet;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bRet = _clientesRepository.PostCliente(cliente);

            if (bRet == false) return BadRequest(ModelState);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        // DELETE: api/v1/clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            bool bRet;

            bRet = _clientesRepository.DeleteCliente(id);

            if (bRet == false) return NotFound();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clientesRepository.Dispose(disposing);
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        [Route("{id:int}/existe")]
        // GET: api/v1/clientes/5/existe
        public bool ClienteExist(int id)
        {
            return _clientesRepository.ClienteExist(id);
        }
    }
}