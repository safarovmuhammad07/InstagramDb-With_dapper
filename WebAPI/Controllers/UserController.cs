using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController(IAllServices<User> controllers):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<User>>> Get()
    {
        return controllers.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<User>> Get(int id)
    {
        return controllers.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Post(User user)
    {
        return controllers.Create(user);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> Put(User user)
    {
        return controllers.Update(user);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> Delete(int id)
    {
        return controllers.Delete(id);
    }
}