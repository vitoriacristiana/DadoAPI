
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/dado",
(
    [FromQuery] string dado
) =>
{
    Random rnd = new Random();

    var tamanho = dado.Length;
    int faces = Int32.Parse(dado.Substring(1, tamanho - 1));

    if (faces <= 0)
    {
        return Results.BadRequest(new { mensagem = "Valor de face do dado inválida!" });
    }

    int rolagem = rnd.Next(1, faces + 1);

    return Results.Ok(
        new
        {
            dado = dado,
            rolagem = rolagem
        }
    );
});

app.Run();