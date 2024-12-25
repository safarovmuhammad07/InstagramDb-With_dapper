

using DoMain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IDapperContext, DapperContext>();
builder.Services.AddScoped<IAllServices<Category>, CategoryService>();
builder.Services.AddScoped<IAllServices<ExternalAccount>, ExternalAccountService>();
builder.Services.AddScoped<IAllServices<FollowingRelation>, FollowingRelationService>();
builder.Services.AddScoped<IAllServices<Location>, LocationService>();
builder.Services.AddScoped<IAllServices<PostCategory>, PostCategoryService>();
builder.Services.AddScoped<IAllServices<PostComment>, PostCommentService>();
builder.Services.AddScoped<IAllServices<PostFavorite>, PostFavoriteService>();
builder.Services.AddScoped<IAllServices<Post>, PostService>();
builder.Services.AddScoped<IAllServices<PostStatus>, PostStatusService>();
builder.Services.AddScoped<IAllServices<PostTag>, PostTagService>();
builder.Services.AddScoped<IAllServices<Tag>, TagService>();
builder.Services.AddScoped<IAllServices<UserProfile>, UserProfileService>();
builder.Services.AddScoped<IAllServices<User>, UserService>();
builder.Services.AddScoped<IAllServices<UserSetting>, UserSettingService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Rest API"));
}

app.UseHttpsRedirection();




app.MapControllers();
app.Run();



