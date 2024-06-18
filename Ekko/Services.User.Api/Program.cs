using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Services.User.Api.Domain.Data;
using Services.User.Api.Domain.Models;
using Services.User.Api.Initializer;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ApplyInitializers(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapIdentityApi<User>();
app.MapControllers();
app.Run();
