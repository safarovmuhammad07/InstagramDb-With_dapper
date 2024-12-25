using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class TagService(IDapperContext context):IAllServices<Tag>
{
    public  async Task<Responce<List<Tag>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = "SELECT * FROM Tags";
        var res =  await connect.QueryAsync<Tag>(sql);
        return new Responce<List<Tag>>(res.ToList());
    }

    public async Task<Responce<Tag>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "SELECT * FROM Tags WHERE Id = @Id";
        var res = await connect.QueryAsync<Tag>(sql, new { Id = id });
        return new Responce<Tag?>(res?.ToList().FirstOrDefault());
    }

    public async Task<Responce<bool>> Create(Tag entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "INSERT INTO Tags (TagName) VALUES (@TagName)";
        var res = await connect.ExecuteAsync(sql, entity);  
        return res == 0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Service Eror") 
            : new Responce<bool>(HttpStatusCode.Created,"Tag created");
    }

    public async Task<Responce<bool>> Update(Tag entity)
    {
        await using var connect = context.GetConnection();
        const string sql="UPDATE Tags SET TagName=@TagName WHERE Id=@Id";
        var res = await connect.ExecuteAsync(sql, entity);
        return res==0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Service Error")
            : new Responce<bool>(HttpStatusCode.OK, "Update success");
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "DELETE FROM Tags WHERE Id = @Id";
        var res = await connect.ExecuteAsync(sql, new { Id = id });  
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Service Error")
            : new Responce<bool>(HttpStatusCode.OK, "Delete success");
    }
}