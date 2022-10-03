using System.Linq.Expressions;

namespace AlgoAirlines_BACKEND.AccesoDatos.Abstracciones
{
    public interface IRepositorio<T> where T : class
    {
        public void Agregar(T entidad);
        public IEnumerable<T> ObtenerTodos();
        public T BuscarPor(Expression<Func<T, bool>> expression);
        public T ObtenerPorId(int id);
        public void Eliminar(T entidad);
    }
}
