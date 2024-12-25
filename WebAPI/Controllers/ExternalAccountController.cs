using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ExternalAccountController(IAllServices<ExternalAccount> externalAccountService):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<ExternalAccount>>> GetExternalAccounts()
    {
        return externalAccountService.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<ExternalAccount>> GetExternalAccount(int id)
    {
        return externalAccountService.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> AddExternalAccount(ExternalAccount externalAccount)
    {
        return externalAccountService.Create(externalAccount);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> UpdateExternalAccount(int id, ExternalAccount externalAccount)
    {
        return externalAccountService.Update(externalAccount);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> DeleteExternalAccount(int id)
    {
        return externalAccountService.Delete(id);
    }
}