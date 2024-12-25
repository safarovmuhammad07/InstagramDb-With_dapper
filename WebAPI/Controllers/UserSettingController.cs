using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UserSettingController(IAllServices<UserSetting> service):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<UserSetting>>> Get()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<UserSetting>> Get(int id)
    {
        return service.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Post(UserSetting userSetting)
    {
        return service.Create(userSetting);
    }
    [HttpPut]
    public Task<Responce<bool>> Put(UserSetting userSetting)
    {
        return service.Update(userSetting);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> Delete(int id)
    {
        return service.Delete(id);
    }
}