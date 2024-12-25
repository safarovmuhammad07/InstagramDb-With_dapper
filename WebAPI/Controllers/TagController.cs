using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class TagController(IAllServices<Tag> service):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<Tag>>> Get()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<Tag>> Get(int id)
    {
        return service.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Add(Tag tag)
    {
        return service.Create(tag);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> Update(Tag tag)
    {
        return service.Update(tag);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> Delete(int id)
    {
        return service.Delete(id);
    }
}