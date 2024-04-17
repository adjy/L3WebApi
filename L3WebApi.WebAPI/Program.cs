using L3WebApi.Business.Implementations;
using L3WebApi.Business.Interfaces;
using L3WebApi.DataAccess.Implementations;
using L3WebApi.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IGamesDataAccess, GamesDataAccess>();
builder.Services.AddTransient<IGameService, GameService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
