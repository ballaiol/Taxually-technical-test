using Taxually.TechnicalTest.BL.Converters;
using Taxually.TechnicalTest.BL.Interfaces;
using Taxually.TechnicalTest.BL.Services;
using Taxually.TechnicalTest.DL.Http;
using Taxually.TechnicalTest.DL.Interfaces;
using Taxually.TechnicalTest.DL.Queue;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVatRegistrationDispatcher, VatRegistrationDispatcher>();
builder.Services.AddScoped<IHttp, TaxuallyHttpClient>();
builder.Services.AddScoped<IQueue, TaxuallyQueueClient>();
builder.Services.AddScoped<ICsvBuilder, CsvBuilder>();
builder.Services.AddScoped<IXmlWriter, XmlWriter>();

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