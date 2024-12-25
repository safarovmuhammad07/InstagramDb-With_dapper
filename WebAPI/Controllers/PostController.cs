using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostController(IAllServices<Post> services):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<Post>>> GetAll()
    {
        return services.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<Post>> GetById(int id)
    {
        return services.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Add(Post post)
    {
        return services.Create(post);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> Update(Post post)
    {
        return services.Update(post);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> Delete(int id)
    {
        return services.Delete(id);
    }
}