using DoMain.Models;
using Infrastructure.ApiResponce;

namespace Infrastructure.Interfaces;

public interface IAllServices<T>
{
    Task<Responce<List<T>>> GetAll();
    Task<Responce<T>> GetById(int id);
    Task<Responce<bool>> Create(T entity);
    Task<Responce<bool>> Update(T entity);
    Task<Responce<bool>> Delete(int id);
}