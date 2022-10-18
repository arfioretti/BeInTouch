using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.Context;
using WebApi.Models.Entity;

namespace WebApi.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private BeInTouchContext db = new BeInTouchContext();


        public bool ClienteExist(int id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }

        public bool DeleteCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return false;
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            return true;
        }

        public Cliente GetCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);

            return cliente;
        }

        public IQueryable<Cliente> GetClientes()
        {
            return db.Clientes;
        }

        public bool PostCliente([FromBody] Cliente cliente)
        {
            db.Clientes.Add(cliente);
            db.SaveChanges();

            return true;
        }

        public bool PutCliente(int id, [FromBody] Cliente cliente)
        {
            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}