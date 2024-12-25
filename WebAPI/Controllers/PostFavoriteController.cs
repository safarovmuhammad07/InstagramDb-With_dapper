using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostFavoriteController(IAllServices<PostFavorite> service):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<PostFavorite>>> Get()
    {
        return service.GetAll();
    }


    [HttpGet("{id}")]
    public Task<Responce<PostFavorite>> Get(int id)
    {
        return service.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Add(PostFavorite postFavorite)
    {
        return service.Create(postFavorite);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> Update(PostFavorite postFavorite)
    {
        return service.Update(postFavorite);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> Delete(int id)
    {
        return service.Delete(id);
    }
}