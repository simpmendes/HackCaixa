
using HackCaixa.Application.Interfaces;
using HackCaixa.Application.Services;
using HackCaixa.Infra.Data;
using HackCaixa.Infra.Data.Context;
using HackCaixa.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ProdutosConection");

builder.Services.AddDbContext<ProdutosDBContext>(
    o => o.UseSqlServer(connectionString)
    );
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
//builder.Services.AddDbContext<JobsDbContext>(
//    o => o.UseInMemoryDatabase("JobsDb")
//    );

// Configurar o AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
