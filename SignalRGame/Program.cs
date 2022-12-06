using SignalRGame;
using SignalRGame.Hubs;
using SignalRGame.Clients;
using Microsoft.AspNetCore.SignalR;
using SignalRGame.GameLogic;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
//builder.Services.AddOptions<GameConfigOptions>()
//    .Bind(builder.Configuration.GetSection(GameConfigOptions.GameConfig));

builder.Services.Configure<GameConfigOptions>(builder.Configuration.GetSection("GameConfig"));

//needed?
//builder.Services.AddSingleton<IHubContext<ChatHub, IChatClient>>();
builder.Services.AddSingleton<GameService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");

app.Run();
