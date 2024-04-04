using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google; // ��� Google OAuth
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OAUTHandJWT.Models.HotelBaseContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = "1025531072038-emvu4p5juukgd8a0cpui7hmd9ctdv6dh.apps.googleusercontent.com";
    googleOptions.ClientSecret = "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";
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication(); // �������� ��� ����� UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    // ��������� CSRF ������
    var csrfToken = context.Request.Cookies[".AspNetCore.Antiforgery.wgkNfB39j3E"];

    if (string.IsNullOrEmpty(csrfToken))
    {
        // ���� CSRF ����� �� ����������, ���������� �����
        csrfToken = Guid.NewGuid().ToString();
        context.Response.Cookies.Append(".AspNetCore.Antiforgery.wgkNfB39j3E", csrfToken);
    }

    // ��������� CSRF ����� � ��������� ������
    context.Response.Headers.Append("X-CSRF-Token", csrfToken);

    await next();
});

app.Run();
