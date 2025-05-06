using BlazorAppDataBinding2;
using BlazorAppDataBinding2.Components;
using System.Buffers.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Daniel added this crucial code: Add PersonService to Progect using Singleton design pattern,
// that we learned last month!

builder.Services.AddSingleton<DBService>(sp => new DBService("Server=localhost;Port=3306;Database=companyhershko;User=root;Password=Root1234"));
builder.Services.AddSingleton<PersonService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
