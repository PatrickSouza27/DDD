using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.API.Setup;
using NerdStore.Catalogo.Data;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<CatalogoContext>(x=> x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.RegisterServices(builder.Configuration);
builder.Services.RegisterApi();



var app = builder.Build();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();