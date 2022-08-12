using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/dado/d{numeroDefaces}", (
   [FromRoute] int numeroDefaces
) =>  {
    if (numeroDefaces <+ 0)
{
    return Results.BadRequest( new { mensagem = "Somente dados com pelo menos uma face"}) ;

}
    int face = RandomNumberGenerator.GetInt32(1, numeroDefaces + 1);
    return Results.Ok (new { dado = $"d{numeroDefaces}", rolagem = face });
});


app.Run();
