using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Pour faire le mapping selon les profile en auto
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Mapping en dur,le auto marche pas je le fait comme ca
builder.Services.AddAutoMapper(typeof(ProfileApi));

// Pour prendre mon context
builder.Services.AddDbContext<MyApiContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));

var app = builder.Build();

// Pour creer la db
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MyApiContext>();

    // Le Ensute Creer la Db si pas deja existante
    context.Database.EnsureCreated();

    //context.Database.Migrate();
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