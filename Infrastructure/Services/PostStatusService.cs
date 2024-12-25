using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class PostStatusService(IDapperContext context):IAllServices<PostStatus>
{
    public async Task<Responce<List<PostStatus>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from PostStatuses";
        var res= await connect.QueryAsync<PostStatus>(sql); 
        return new Responce<List<PostStatus>>(res.ToList());
    }

    public async Task<Responce<PostStatus>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from PostStatuses where PostStatusServiceID = @id";
        var res = await connect.QueryFirstOrDefaultAsync<PostStatus>(sql, new { id });
        return res != null 
            ? new Responce<PostStatus>(res) 
            : new Responce<PostStatus>(HttpStatusCode.NotFound, "PostStatusService not found");
    }

    public async Task<Responce<bool>> Create(PostStatus entity)
    {
        await using var connect = context.GetConnection();
        const string sql = @"insert into PostStatuses (ViewCount) values (@ViewCount)";
        var res = await connect.ExecuteAsync(sql, entity);
        return res != 0 
            ? new Responce<bool>(HttpStatusCode.Created, "PostStatusService created")
            : new Responce<bool>(HttpStatusCode.InternalServerError, "Internal server error");
    }

    public async Task<Responce<bool>> Update(PostStatus entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "Update PostStatuses set ViewCount=@ViewCount where PostID = @PostID";
        var res = await connect.ExecuteAsync(sql, entity);
        return res != 0
            ?new Responce<bool>(HttpStatusCode.Accepted, "PostStatusService updated")
            : new Responce<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"delete from PostStatuses where PostStatusServiceID = @PostStatusServiceID";
        var res = await connect.ExecuteAsync(sql, new { Id = id });
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Responce<bool>(HttpStatusCode.OK, "PostStatusService Deleted allready");
    }
}