using DownloadDocs.Handlers;
using DownloadDocs.Helpers;
using DownloadDocs.Interfaces;
using DownloadDocs.Models;
using DownloadDocs.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHandlerDispatch, HandlerDispatch>();
builder.Services.AddScoped<IExportService, ExportService>();
builder.Services.AddScoped<IRequestHandler<GetManualRequest, byte[]>, GetPDFHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Serves the Swagger JSON
    app.UseSwaggerUI(); // Serves Swagger UI
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
