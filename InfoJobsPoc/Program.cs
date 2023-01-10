using InfoJobsPoc.Bootstrap;
using Microsoft.AspNetCore.Mvc.RazorPages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddBootstrapDemo(builder.Configuration);
builder.Services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/UI/Pages");

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapBootstrapDemo();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
