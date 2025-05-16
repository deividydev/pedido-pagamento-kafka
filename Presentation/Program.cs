using System.Reflection;
using Application.Workers;
using Infrastructure.Kafka.Abstractions;
using Infrastructure.Kafka.Producers;
using Infrastructure.Kafka.Validators;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var applicationAssembly = Assembly.Load("Application");

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));
builder.Services.AddSingleton<IKafkaProducer, KafkaProducer>();
builder.Services.AddTransient<IKafkaValidator, KafkaValidator>();
builder.Services.AddHostedService<PaymentConsumerWorker>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

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