using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class PostFavoriteService(IDapperContext context):IAllServices<PostFavorite>
{
    public async Task<Responce<List<PostFavorite>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = "select * from PostFavorite";
        var res = await connect.QueryAsync<PostFavorite>(sql);
        return new Responce<List<PostFavorite>>(res.ToList());
    }

    public async Task<Responce<PostFavorite>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "select * from PostFavorite where id=@id";
        var res = await connect.QueryFirstOrDefaultAsync(sql, new { id });
        return res != null 
            ? new Responce<PostFavorite>(res) 
            : new Responce<PostFavorite>(HttpStatusCode.NotFound, "PostFavorite not found");
    }

    public async Task<Responce<bool>> Create(PostFavorite entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "insert into PostFavorite (PostId,UserId,DateFavorited) values (@PostId,@UserId,@DateFavorited)";
        var res = await connect.ExecuteAsync(sql, entity);
        return res == 0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Server Error") 
            : new Responce<bool>(HttpStatusCode.Created, "PostFavorite added");
    }

    public async Task<Responce<bool>> Update(PostFavorite entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "update PostFavorite set  PostId=@PostId, UserId=@UserId,DateFavorited=@DateFavorited where id=@id";
        var res = await connect.ExecuteAsync(sql, entity);
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "PostFavorite updated");
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "delete from PostFavorite where id=@id";
        var res = await connect.ExecuteAsync(sql, new { Id=id });
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "PostFavorite deleted");
    }
}