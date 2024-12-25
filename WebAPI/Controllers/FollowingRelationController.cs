using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class FollowingRelationController(IAllServices<FollowingRelation> service):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<FollowingRelation>>> Get()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<FollowingRelation>> Get(int id)
    {
        return service.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Post(FollowingRelation value)
    {
        return service.Create(value);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> Put(FollowingRelation value)
    {
        return service.Update(value);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> Delete(int id)
    {
        return service.Delete(id);
    }
    
}