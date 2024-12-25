using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;


namespace Infrastructure.Services;

public class PostCommentService(IDapperContext context):IAllServices<PostComment>
{
    public async Task<Responce<List<PostComment>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from PostCommentService";
        var res = await connect.QueryAsync<PostComment>(sql);
        return new Responce<List<PostComment>>(res.ToList());
    }

    public async Task<Responce<PostComment>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from PostComments where id=@id";
        var res = await connect.QueryFirstOrDefaultAsync<PostComment>(sql, new { id });
        return res != null 
            ? new Responce<PostComment>(res) 
            : new Responce<PostComment>(HttpStatusCode.NotFound, "Not found");
    }

    public async Task<Responce<bool>> Create(PostComment entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "insert into PostComments (PostId,CommenterID,Comment,DateCommented) values (@PostId,@CommenterID,@Comment,@DateCommented)";
        var res = await connect.ExecuteAsync(sql, entity);
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Error")
            : new Responce<bool>(HttpStatusCode.Created, "Created");

    }

    public async Task<Responce<bool>> Update(PostComment entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "update PostComments set PostId=@PostId,CommenterID=@CommenterID,Comment=@Comment where id=@id";
        var res = await connect.ExecuteAsync(sql, entity);
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Error")
            : new Responce<bool>(HttpStatusCode.OK, "Updated");
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "delete from PostComments where id=@id";
        var res = await connect.ExecuteAsync(sql, new{Id = id});
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Error")
            : new Responce<bool>(HttpStatusCode.OK, "Deleted");
    }
}