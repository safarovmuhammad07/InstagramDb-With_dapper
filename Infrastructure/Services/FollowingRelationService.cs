using System.ComponentModel.DataAnnotations;
using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class FollowingRelationService(IDapperContext context):IAllServices<FollowingRelation>
{
    public async Task<Responce<List<FollowingRelation>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from FollowingRelations";
        var res = context.GetConnection().Query<FollowingRelation>(sql).ToList();
        return new Responce<List<FollowingRelation>>(res);
    }

    public async Task<Responce<FollowingRelation>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from FollowingRelations where id=@id";
        var res = await connect.QueryFirstOrDefaultAsync<FollowingRelation>(sql, new { id });
        return res != null
            ? new Responce<FollowingRelation>(res) 
            : new Responce<FollowingRelation>(HttpStatusCode.NotFound, "Not found");

    }


    public async Task<Responce<bool>> Create(FollowingRelation entity)
    {
        await using var connect = context.GetConnection();
        const string sql = @"insert into FollowingRelations (UserId,FollowingId,DataFollowed) values (@UserId,@FollowingId,@DataFollowed)";
        var res = await connect.ExecuteAsync(sql, entity);
        return res == 0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Service Error") 
            : new Responce<bool>(HttpStatusCode.Created, "Created");
    }

    public async Task<Responce<bool>> Update(FollowingRelation entity)
    {
        await using var connect = context.GetConnection();
        const string sql = "Update FollowingRelations set UserId=@UserId, FollowingId=@FollowingId,DataFollowed=@DataFollowed where id=@id";
        var res = await connect.ExecuteAsync(sql, entity);
        return res == 0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Service Error")
            : new Responce<bool>(HttpStatusCode.OK, "Updated");
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = "delete from FollowingRelations where id=@id";
        var res = await connect.ExecuteAsync(sql, new {Id = id});
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Service Error")
            : new Responce<bool>(HttpStatusCode.OK, "Deleted"); 
    }
}