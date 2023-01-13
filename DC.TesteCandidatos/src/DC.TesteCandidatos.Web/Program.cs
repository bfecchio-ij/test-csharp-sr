using DC.TesteCandidatos.Data.ORM;
using DC.TesteCandidatos.Data.Repositories;
using DC.TesteCandidatos.Domain.Entities;
using DC.TesteCandidatos.Domain.Handlers;
using DC.TesteCandidatos.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<DCDbContext>(options =>
{
    options.UseSqlServer(
            builder.Configuration.GetConnectionString("Default")
    );
});
builder.Services.AddControllersWithViews();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(CandidateCreateHandler));
builder.Services.AddMediatR(typeof(CandidateDeleteHandler));
builder.Services.AddMediatR(typeof(CandidateGetAllQueryHandler));
builder.Services.AddMediatR(typeof(CandidateSelectQueryHandler));
builder.Services.AddMediatR(typeof(CandidateUpdateHandler));
builder.Services.AddMediatR(typeof(ExperiencesCreateHandler));
builder.Services.AddMediatR(typeof(ExperiencesGetAllHandler));
builder.Services.AddMediatR(typeof(ExperiencesSelectHandler));
builder.Services.AddMediatR(typeof(ExperiencesDeleteHandler));
builder.Services.AddMediatR(typeof(ExperiencesUpdateHandler));

builder.Services.AddScoped(typeof(IRepository<Candidates>), typeof(CandidatesRepository));
builder.Services.AddScoped(typeof(IRepository<CandidateExperiences>), typeof(CandidatesExperiencesRepository));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
