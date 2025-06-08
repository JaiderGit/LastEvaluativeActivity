using Facturacion.DAL;
using Facturacion.Domain.Interfaces;
using Facturacion.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped < IBillService,BillService>();
builder.Services.AddScoped<ICreditNoteService, CreditNoteService>();
builder.Services.AddTransient<SeederDB>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

SeederData();

void SeederData()
{
    IServiceScopeFactory? scopeFactory= app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopeFactory.CreateScope())
    {
        SeederDB? service=scope.ServiceProvider.GetService<SeederDB>();
        service.SeederAsync().Wait();
    }

}


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
