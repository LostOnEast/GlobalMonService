using GlobalMonService.Models;
using GlobalMonService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ISenderService, SenderService>();

//builder.Services.AddSendService().BuildServiceProvider();
//builder.Services.GetRequiredService<ISenderService>();



builder.Services.AddMemoryCache();
builder.Services.AddTransient<IMessageStatusDb, MessageStatusDb>();
builder.Services.AddTransient<ISenderService, SenderService>();
builder.Services.AddTransient(typeof(ISender<IosMessage>), typeof(IosSender));
builder.Services.AddTransient(typeof(ISender<AndroidMessage>), typeof(AndroidSender));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
