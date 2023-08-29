var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "izin2";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7113/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});
builder.Services.AddControllers();
builder.Services.AddSwaggerDocument();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseOpenApi();
app.UseSwaggerUi3();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
