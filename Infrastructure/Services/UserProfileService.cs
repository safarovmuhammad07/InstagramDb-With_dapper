using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class UserProfileService(IDapperContext context):IAllServices<UserProfile>
{
    public  async Task<Responce<List<UserProfile>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = "SELECT * FROM UserProfile";
        var res = await connect.QueryAsync<UserProfile>(sql);
        return new Responce<List<UserProfile>>(res.ToList());
    }

    public async Task<Responce<UserProfile>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "SELECT * FROM UserProfile WHERE Id = @Id";
        var res = await connect.QueryAsync<UserProfile>(sql, new { Id = id });
        return new Responce<UserProfile?>(res.ToList().FirstOrDefault());
    }

    public  async Task<Responce<bool>> Create(UserProfile entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "Insert into UserProfile(Username,Password) values (@Username, @Password)";
         var res=await connect.ExecuteAsync(sql, entity);
         return res==0
             ? new Responce<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
             : new Responce<bool>(HttpStatusCode.Created,"User profile created successfully");
    }

    public  async Task<Responce<bool>> Update(UserProfile entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "Update UserProfile set Username=@Username, Password=@Password"; 
        var res=await connect.ExecuteAsync(sql, entity);
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Responce<bool>(HttpStatusCode.OK,"User profile updated successfully");
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "Delete UserProfile where Id = @Id"; 
        var res=await connect.ExecuteAsync(sql, new { Id = id });
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Responce<bool>(HttpStatusCode.OK,"User profile deleted successfully");
    }

}