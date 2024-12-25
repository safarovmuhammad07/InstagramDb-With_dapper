using DoMain.Models;
using Infrastructure.ApiResponce;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostCategoryController(IAllServices<PostCategory> services):ControllerBase
{
    [HttpGet]
    public Task<Responce<List<PostCategory>>> GetPostCategories()
    {
        return services.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Responce<PostCategory>> GetPostCategory(int id)
    {
        return services.GetById(id);
    }

    [HttpPost]
    public Task<Responce<bool>> AddPostCategory(PostCategory postCategory)
    {
        return services.Create(postCategory);
    }

    [HttpPut("{id}")]
    public Task<Responce<bool>> UpdatePostCategory( PostCategory postCategory)
    {
        return services.Update(postCategory);
    }
}