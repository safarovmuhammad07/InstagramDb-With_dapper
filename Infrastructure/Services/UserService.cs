using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class UserService(IDapperContext context):IAllServices<User>
{
    public async Task<Responce<List<User>>> GetAll()
    {
        await using var connect = context.GetConnection();
        var users = await connect.QueryAsync<User>("select * from User");
        return new Responce<List<User>>(users.ToList());
    }

    public async Task<Responce<User>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        var user = await connect.QueryFirstOrDefaultAsync<User>($"select * from User where Id = {id}"); 
        return new Responce<User?>(user);
    }

    public async Task<Responce<bool>> Create(User entity)
    {
        await using var connect = context.GetConnection();
        var user = await connect.ExecuteAsync("insert into User (Username, Password) values (@Username, @Password);", entity);
        return user==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.Created, "Created Successfully");
    }

    public async Task<Responce<bool>> Update(User entity)
    {
        await using var connect = context.GetConnection();
        var user = await connect.ExecuteAsync("update User set Password = @Password where Id = @Id;", entity);
        return user==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "Updated successfully");
    }

    public async Task<Responce<bool>> Delete(int id)
    { 
        await using var connect = context.GetConnection();
        var user = await connect.ExecuteAsync("delete from User where Id = @Id;", new { Id = id });
        return user==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "Deleted successfully");
    }
}