using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleWebApi.Service.Implementation;
using SimpleWebApi.Service.Interface;
using SimpleWebApi.Web.Middleware;
using SimpleWebApp.Repository;
using SimpleWebApp.Repository.Implementation;
using SimpleWebApp.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IContactRepository), typeof(ContactRepository));
builder.Services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
builder.Services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));

builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IContactService, ContactService>();

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
