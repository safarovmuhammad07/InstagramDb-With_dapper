using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class LocationController(IAllServices<Location> service):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<Location>>> Get()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<Location>> Get(int id)
    {
        return service.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Post(Location value)
    {
        return service.Create(value);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> Put(Location value)
    {
        return service.Update(value);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> Delete(int id)
    {
        return service.Delete(id);
    }
}