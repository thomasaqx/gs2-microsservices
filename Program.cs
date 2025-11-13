using PromptApi.Data;
using PromptApi.Services;
using PromptApi.Middlewares; 

var builder = WebApplication.CreateBuilder(args);

//serviços
builder.Services.AddControllers();
builder.Services.AddSingleton<PromptRepository>(); 
builder.Services.AddScoped<IPromptService, PromptService>(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

//swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();