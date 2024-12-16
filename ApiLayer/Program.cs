using ApiLayer.ErrorHandling;
using ToDoApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDb(builder.Configuration);
builder.Services.AddServices();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddControllers();
builder.Services.AddSwaggerSettings();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(ops => { });

app.UseHttpsRedirection();
app.MapControllers();
await app.RunAsync();

