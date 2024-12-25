using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class PostCategoryService(IDapperContext context):IAllServices<PostCategory>
{
    public async Task<Responce<List<PostCategory>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from PostCategories";
        var res= await connect.QueryAsync<PostCategory>(sql);
        return new Responce<List<PostCategory>>(res.ToList());
    }

    public async Task<Responce<PostCategory>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from PostCategories where PostCategoryID=@id";
        var res= await connect.QueryFirstOrDefaultAsync<PostCategory>(sql);
        return res != null 
            ? new Responce<PostCategory>(res) 
            : new Responce<PostCategory>(HttpStatusCode.NotFound,"PostCategory not found");
    }

    public async Task<Responce<bool>> Create(PostCategory entity)
    {
        await using var connect = context.GetConnection();
        const string sql = @"insert into PostCategories (PostId,CategoryId) values (@PostId,@CategoryId)";
        var res = await connect.ExecuteAsync(sql, entity);
        return res ==0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Responce<bool>(HttpStatusCode.Created, "Created");
    }

    public async Task<Responce<bool>> Update(PostCategory entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "Update PostCategories set PostId=@PostId,CategoryId=@CategoryId where PostCategoryID=@PostCategoryID"; 
        var res = await connect.ExecuteAsync(sql, entity);
        return res ==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Responce<bool>(HttpStatusCode.OK, "Updated");
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "Delete from PostCategories where PostCategoryID=@PostCategoryID"; 
        var res = await connect.ExecuteAsync(sql, new { PostCategoryID = id });
        return res ==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Responce<bool>(HttpStatusCode.OK, "Deleted");
    }
}