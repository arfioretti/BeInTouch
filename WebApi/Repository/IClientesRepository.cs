using System.Linq;
using System.Web.Http;
using WebApi.Models.Entity;

namespace WebApi.Repository
{
    public interface IClientesRepository
    {
        bool ClienteExist(int id);
        bool DeleteCliente(int id);
        Cliente GetCliente(int id);
        IQueryable<Cliente> GetClientes();
        bool PostCliente([FromBody] Cliente cliente);
        bool PutCliente(int id, [FromBody] Cliente cliente);

        void Dispose(bool disposing);
    }
}