using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostStatusController(IAllServices<PostStatus> service): ControllerBase
{
    [HttpGet]
    public Task<Responce<List<PostStatus>>> Get()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<PostStatus>> Get(int id)
    {
        return service.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Post(PostStatus postStatus)
    {
        return service.Create(postStatus);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> Put(PostStatus postStatus)
    {
            return service.Update(postStatus);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> Delete(int id)
    {
        return service.Delete(id);
    }
}