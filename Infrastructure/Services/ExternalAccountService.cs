using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ExternalAccountService(IDapperContext context):IAllServices<ExternalAccount>
{
    public async Task<Responce<List<ExternalAccount>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from ExternalAccount";
        var res= await connect.QueryAsync<ExternalAccount>(sql);
        return new Responce<List<ExternalAccount>>(res.ToList());
    }

    public async Task<Responce<ExternalAccount>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from ExternalAccounts where id=@id";
        var res = await connect.QueryFirstOrDefaultAsync<ExternalAccount>(sql, new { id });
        return new Responce<ExternalAccount>(res);
    }

    public async Task<Responce<bool>> Create(ExternalAccount entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "Insert into ExternalAccounts (FacebookEmail, TwitterUsername) values (@FacebookEmail, @TwitterUsername)";
        var res = await connect.ExecuteAsync(sql, entity);
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, " Internal Server Error")
            : new Responce<bool>(HttpStatusCode.Created, "ExternalAccount Created");
    }

    public async Task<Responce<bool>> Update(ExternalAccount entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "Update ExternalAccounts set FacebookEmail=@FacebookEmail, TwitterUsername=@TwitterUsername where id=@id";
        var res = await connect.ExecuteAsync(sql, entity);
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, " Internal Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "ExternalAccount Updated");
    }

  

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "Delete from ExternalAccounts where id=@id";
        var res =await connect.ExecuteAsync(sql, new { Id=id });
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, " Internal Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "ExternalAccount Deleted");
    }
}