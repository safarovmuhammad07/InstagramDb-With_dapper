using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class UserSettingService(IDapperContext context) : IAllServices<UserSetting>
{
    public async Task<Responce<List<UserSetting>>> GetAll()
    {
        await using var connect = context.GetConnection();
        var res = await connect.QueryAsync<UserSetting>("select * from UserSetting");
        return new Responce<List<UserSetting>>(res.ToList());
    }

    public async Task<Responce< UserSetting >>GetById(int id)
    {
        await using var connect = context.GetConnection();
        var res = await connect.QueryFirstOrDefault($"select * from UserSetting where Id = {id}", new {id})!;
         return new Responce<UserSetting?>(res);
    }

    public async Task<Responce<bool>> Create(UserSetting entity)
    {
        await using var connect = context.GetConnection();
        var res = await connect.ExecuteAsync(
            "Insert into UserSetings(NotificationsNewsletter,NotificationsFollowers,NotificationsComm,NotificationsMessages) values (@NotificationsNewsletter,@NotificationsFollowers,@NotificationsComm,@NotificationsMessages)");
        return res== 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.Created, "created");
    }

    public async Task<Responce<bool>> Update(UserSetting entity)
    {
        await using var connect = context.GetConnection();
        var res = await connect.ExecuteAsync("Update UserSetting set NotificationsNewsletter=@NotificationsNewsletter, NotificationsFollowers=@NotificationsFollowers,NotificationsComm=@NotificationsComm NotificationsMessages=@NotificationsMessages where  id =@id");
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "Updated ");
        
    }

    public async Task<Responce<bool>> Delete(int id)
    {
        await using var connect = context.GetConnection();
        var res = await connect.ExecuteAsync("Delete from UserSettings where id=@id", new {id});
        return res == 0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.OK, "Updated ");
    }
}