using wordmedia.Model.DapperContext;
using wordmedia.Repositories.AvatarRepository;
using wordmedia.Repositories.UserDataRepository;
using wordmedia.Repositories.UserRepository;
using wordmedia.Repositories.UserRoleRepository;
using wordmedia.Repositories.UserWords;
using wordmedia.Repositories.WordRepository;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<IAvatarRepository, AvatarRepository>();
builder.Services.AddTransient<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddTransient<IUserWordDataRepository, UserWordDataRepository>();
builder.Services.AddTransient<IUserWordsRepository,  UserWordsRepository>();
builder.Services.AddTransient<IWordRepository, WordRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.WithOrigins("http://localhost:40630").AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
