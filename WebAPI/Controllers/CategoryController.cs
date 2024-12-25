using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController(IAllServices<Category> service) : ControllerBase
{
    [HttpGet]
    public Task<Responce<List<Category>>> Get()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<Category>> Get(int id)
    {
        return service.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Post(Category category)
    {
        return service.Create(category);
    }

    [HttpPut]
    public Task<Responce<bool>> Put(Category category)
    {
        return service.Update(category);
    }

    [HttpDelete]
    public Task<Responce<bool>> Delete(int id)
    {
        return service.Delete(id);
    }
}