
using HackCaixa.Application.Interfaces;
using HackCaixa.Application.Services;
using HackCaixa.Domain.Interfaces;
using HackCaixa.Infra.Data;
using HackCaixa.Infra.Data.Context;
using HackCaixa.Infra.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using HackCaixa.Application.Validators;

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


builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EntradaSimulacaoDTOValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEventHubIntegration>(provider =>
{
    // Configure os dados de conexão e o nome do Event Hub
    string connectionString = "Endpoint=sb://eventhack.servicebus.windows.net/;SharedAccessKeyName=hack;SharedAccessKey=HeHeVaVqyVkntO2FnjQcs2Ilh/4MUDo4y+AEhKp8z+g=;EntityPath=simulacoes";
    

    return new EventHubIntegration(connectionString);
});

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
