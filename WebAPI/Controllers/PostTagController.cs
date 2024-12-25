using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostTagController(IAllServices<PostTag> service):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<PostTag>>> Get()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<PostTag>> GetById(int id)
    {
        return service.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Add(PostTag postTag)
    {
        return service.Create(postTag);
    }

    [HttpPut]
    public Task<Responce<bool>> Update(PostTag postTag)
    {
        return service.Update(postTag);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> Delete(int id)
    {
        return service.Delete(id);
    }
    
    
    
}