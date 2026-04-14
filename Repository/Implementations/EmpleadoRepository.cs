using ActividadS5.Models;
using ActividadS5.Repositories.Interfaces;

namespace ActividadS5.Repositories.Implementations
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(Actividads5Context context) : base(context)
        {
        }
    }
}