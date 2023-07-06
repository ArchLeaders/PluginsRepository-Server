using System.Linq.Expressions;

namespace PluginRepository.Core.DataAccess;
public interface IDataProvider<T> where T : DataObject
{
    Task Add(T item);
    Task<T> Get(Expression<Func<T, bool>> filter);
    Task<List<T>> GetAll();
    Task Update(T item);
}