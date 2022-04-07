using AnnouncementApp.BLL.DTO;
using AnnouncementApp.BLL.Helpers.ExceptionModels;
using AnnouncementApp.BLL.Helpers.Mappers;
using AnnouncementApp.BLL.Interfaces;
using AnnouncementApp.BLL.Services;
using AnnouncementApp.DAL.EF;
using AnnouncementApp.DAL.Interfaces;
using AnnouncementApp.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AnnouncementMapper());
});

builder.Services.AddSingleton(mappingConfig.CreateMapper());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    /// <summary>
    /// middleware that handles internally exceptions and sets the appropriate status code
    /// </summary>
    app.UseExceptionHandler(exceptionHandlerApp =>
    {
        exceptionHandlerApp.Run(async context =>
        {
            context.Response.ContentType = Text.Plain;
            var exception = context.Features.Get<IExceptionHandlerPathFeature>()!.Error;
            var exceptionText = $"Exception Message: {exception!.Message} ";

            if (exception is CustomException customException)
            {
                context.Response.StatusCode = customException.StatusCode;
            } 
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                if (exception.InnerException != null)
                    exceptionText += $"Inner Exception Message: {exception.InnerException.Message}";
            }

            await context.Response.WriteAsync($"{exceptionText}");
        });
    });

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
