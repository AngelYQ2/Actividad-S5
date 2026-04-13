using ActividadS5.Models;
using ActividadS5.Repositories.Interfaces;

namespace ActividadS5.Repositories.Implementations
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Actividads5Context context) : base(context)
        {
        }
    }
}