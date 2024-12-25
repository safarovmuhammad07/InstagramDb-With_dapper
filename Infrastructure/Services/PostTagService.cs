using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class PostTagService(IDapperContext context):IAllServices<PostTag>
{
    public async Task<Responce<List<PostTag>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = "SELECT * FROM PostTagService";
        var res = await connect.QueryAsync<PostTag>(sql);
        return new Responce<List<PostTag>>(res.ToList());
    }

    public async Task<Responce<PostTag>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "SELECT * FROM PostTagService WHERE PostTagServiceID = @PostTagServiceID";
        var res = await connect.QueryAsync<PostTag>(sql, new { PostTagServiceID = id });
        return new Responce<PostTag?>(res.ToList().FirstOrDefault());
    }

    public async Task<Responce<bool>> Create(PostTag entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "INSERT INTO PostTagService (PostId,TagID) VALUES (@PostId,@TagID)";
        var res = await connect.ExecuteAsync(sql, entity);
        return res==0 
            ?new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.Created, "Created");
    }

    public async Task<Responce<bool>> Update(PostTag entity)
    {
        await using var connect = context.GetConnection();
        const string sql ="Update PostTags set PostId=@PostId,TagID = @TagID where PostTagID = @PostTagID ";
        var res = await connect.ExecuteAsync(sql, entity);
        return res==0 
            ?new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.Created, "Updated");
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "Delete PostTags WHERE PostTagServiceID = @PostTagServiceID";
        var res = await connect.ExecuteAsync(sql, new { Id=id});
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
        : new Responce<bool>(HttpStatusCode.Created, "Deleted");
    }
}