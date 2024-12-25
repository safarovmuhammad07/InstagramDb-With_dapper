using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class LocationService(IDapperContext context):IAllServices<Location>
{
    public async Task<Responce<List<Location>>> GetAll()
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from locations";
        var res = context.GetConnection().Query<Location>(sql).ToList();
        return new Responce<List<Location>>(res);
    }

    public async Task<Responce<Location>> GetById(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"select * from locations where id=@id";
        var res = await connect.QueryFirstOrDefaultAsync<Location>(sql, new { id });
        return res != null
            ? new Responce<Location>(res)
            : new Responce<Location>(HttpStatusCode.NoContent,"Location not found");
    }

    public async Task<Responce<bool>> Create(Location entity)
    {
        await using var connect = context.GetConnection();
        const string sql = @"insert into locations (City,State,ZipCode,Country) values (@City,@State,@ZipCode,@Country)";
        var res = await connect.ExecuteAsync(sql, entity);
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError,"Error")
            : new Responce<bool>(HttpStatusCode.OK, "Success");
    }

    public async Task<Responce<bool>> Update(Location entity)
    {
        await using var connect = context.GetConnection();
        const string sql = @"Update Locations set City=@City, State=@State, ZipCode=@ZipCode where id=@id";
        var res = await connect.ExecuteAsync(sql, entity);
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError,"Error")
            : new Responce<bool>(HttpStatusCode.OK, "Success");
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        const string sql = @"delete from locations where id=@id";
        var res = await connect.ExecuteAsync(sql, new {Id=id});
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError,"Error")
            : new Responce<bool>(HttpStatusCode.OK,"Success");
    }
}