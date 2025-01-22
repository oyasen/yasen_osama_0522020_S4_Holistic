using Microsoft.EntityFrameworkCore;
using yasen_osama_0522020_S4_Holistic.Data;
using yasen_osama_0522020_S4_Holistic.Repo.ClassRepo;
using yasen_osama_0522020_S4_Holistic.Repo.GradRepo;
using yasen_osama_0522020_S4_Holistic.Repo.StudentRepo;
using yasen_osama_0522020_S4_Holistic.Repo.SubjectRepo;
using yasen_osama_0522020_S4_Holistic.Repo.TeacherRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
builder.Services.AddScoped<IClassRepo,ClassRepo>();
builder.Services.AddScoped<ITeacherRepo,TeacherRepo>();
builder.Services.AddScoped<IStudentRepo,StudentRepo>();
builder.Services.AddScoped<IGradRepo,GradRepo>();
builder.Services.AddScoped<ISubjectRepo,SubjectRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
