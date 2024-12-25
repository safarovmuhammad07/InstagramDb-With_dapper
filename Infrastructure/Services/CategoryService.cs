using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using static DoMain.Models.Category;

namespace Infrastructure.Services;

public class CategoryService(IDapperContext context):IAllServices<Category>
{
    public async Task<Responce<List<Category>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from Categories";
        var res= await connect.QueryAsync<Category>(sql);
        return new Responce<List<Category>>(res.ToList());
    }

    public async Task<Responce<Category>> GetById(int id)
    { 
        await using var connect = context.GetConnection();
        const string sql = @"select * from Categories where Categoryid=@id";
        var  res= await  connect.QueryFirstOrDefaultAsync<Category>(sql);
        return res is null 
            ? new Responce<Category>(HttpStatusCode.NotFound, "Category Not Found") 
            : new Responce<Category>(res);
    }
    public async Task<Responce<bool>> Create(Category entity)
    {
        await using var connect = context.GetConnection();
        const string sql = @"insert into Categories (Categoryname) values (@categoryname)";
        var res = await connect.ExecuteAsync(sql, entity);
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "INTERVAL SERVER EROR")
            : new Responce<bool>(HttpStatusCode.Created,"Category Created");
    }

    public async Task<Responce<bool>> Update(Category entity)
    {
        await using var connect = context.GetConnection();
        const string sql = @"update Categories set Categoryname=@categoryname where Categoryid=@categoryid";
        var res = await connect.ExecuteAsync(sql, entity);
        return res==0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "INTERVAL SERVER EROR")
            : new Responce<bool>(HttpStatusCode.OK,"Category UPDATED");
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"delete from Categories where Categoryid=@categoryid";
        var res = await context.GetConnection().ExecuteAsync(sql,new {Id=id} );
        return res==0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "INTERVAL SERVER EROR")
            : new Responce<bool>(HttpStatusCode.OK,"Category Deleted");
    }
}