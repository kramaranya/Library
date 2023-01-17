using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    
    Task<IEnumerable<T>> GetAllAsync();
    
    Task<T> GetByIdAsync(int id); //Task?????
    
    Task AddAsync(T entity); 
    
    void Remove(T entity);
    
    void Remove(int id);
    
    void Update(T entity);
}