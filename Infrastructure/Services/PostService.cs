using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class PostService(IDapperContext context) : IAllServices<Post>
{
    public async Task<Responce<List<Post>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from Posts";
        var res= await connect.QueryAsync<Post>(sql);
        return new Responce<List<Post>>(res.ToList());
    }

    public async Task<Responce<Post>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from Posts where PostId = @id";
        var res = await connect.QueryFirstOrDefaultAsync<Post>(sql, new { id });
        return res != null ? new Responce<Post>(res) : new Responce<Post>(HttpStatusCode.NotFound, "Not found");
    }

    public async Task<Responce<bool>> Create(Post entity)
    {
        await using var connect = context.GetConnection();
        const string sql = @"insert into Posts(UserID,Title,Content,Status,DatePublished,PostComments,PostStatus) values (@UserID,@Title,@Content,@Status,@DatePublished,@PostComments,@PostStatus)";
        var res = await connect.ExecuteAsync(sql, entity);
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Responce<bool>(HttpStatusCode.Created, "Created");
        
    }

    public async Task<Responce<bool>> Update(Post entity)
    {
        
        await using var connect = context.GetConnection();
        const string sql = "Update Posts set  UserID=@UserID,Title=@Title,Content=@Content,Status=@Status,DatePublished=@DatePublished ,PostComments=@PostComments,PostStatus=@PostStatus"; 
        var res =  await connect.ExecuteAsync(sql, entity);
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Responce<bool>(HttpStatusCode.OK, "Updated");
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "Delete from Posts where PostId = @PostId";
        var res = await connect.ExecuteAsync(sql, new { PostId = id });
        return res==0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Responce<bool>(HttpStatusCode.OK, "Deleted");
    }
}