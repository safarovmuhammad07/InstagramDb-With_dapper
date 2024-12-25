using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UserProfileController(IAllServices<UserProfile> services):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<UserProfile>>> Get()
    {
        return services.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<UserProfile>> Get(int id)
    {
        return services.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Post(UserProfile value)
    {
        return services.Create(value);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> Put(UserProfile value)
    {
        return services.Update(value);
    }
}