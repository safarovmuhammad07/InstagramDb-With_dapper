using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostCommentController(IAllServices<PostComment> postComments):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<PostComment>>> Get()
    {
        return postComments.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<PostComment>> Get(int id)
    {
        return postComments.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> Post(PostComment comment)
    {
        return postComments.Create(comment);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> Put(int id, PostComment comment)
    {
        return postComments.Update(comment);
    }

    [HttpDelete("{id}")]
    public Task<Responce<bool>> Delete(int id)
    {
        return postComments.Delete(id);
    }
}