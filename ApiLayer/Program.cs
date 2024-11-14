using ToDoApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDb(builder.Configuration);
builder.Services.AddServices();


builder.Services.AddControllers();
builder.Services.AddSwaggerSettings();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

