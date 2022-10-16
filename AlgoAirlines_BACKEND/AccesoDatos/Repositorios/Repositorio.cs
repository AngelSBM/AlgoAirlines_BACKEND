using AlgoAirlines_BACKEND.AccesoDatos.Abstracciones;
using System.Linq.Expressions;

namespace AlgoAirlines_BACKEND.AccesoDatos.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repositorio(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<T> ObtenerTodos()
        {
            return _context.Set<T>().ToList();
        }

        public void Agregar(T entidad)
        {
            _context.Set<T>().Add(entidad);
        }

        public T BuscarPor(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public void Eliminar(T entidad)
        {
            _context.Set<T>().Remove(entidad);
        }

        public T ObtenerPorId(int id)
        {
            return _context.Set<T>().Find(id);
        }

    }
}
