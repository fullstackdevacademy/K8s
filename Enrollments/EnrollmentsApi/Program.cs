
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using EnrollmentsApi.Services;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Azure.KeyVault;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//var keyVaultUrl = "https://<Your-KeyVault-Name>.vault.azure.net";
//var secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
//var dbConnectionString = secretClient.GetSecret("<Secret-Name>").Value.Value;
// Disable HTTPS redirection for containerized environments
//builder.Services.Configure<Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionOptions>(options =>
//{
//    options.HttpsPort = null;
//});
//// Conditionally disable HTTPS redirection in Docker
//if (builder.Environment.IsDevelopment() || Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
//{
//    builder.Services.Configure<HttpsRedirectionOptions>(options =>
//    {
//        options.HttpsPort = null; // Disable HTTPS redirection in containers
//    });
//}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageProducer, MessageProducer>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
app.MapControllers();

app.Run();

