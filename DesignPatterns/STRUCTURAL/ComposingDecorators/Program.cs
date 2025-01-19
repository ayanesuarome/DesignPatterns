using ComposingDecorators;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLogging();
builder.Services.AddMemoryCache();

builder.Services.AddSingleton<IAsyncPolicy>(serviceProvider =>
{
    // Configure a retry policy that retries 3 times with exponential backoff
    return Policy.Handle<HttpRequestException>()
                 .WaitAndRetryAsync(3, retryAttempt => 
                 TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
});

builder.Services.AddDecoratorWithScrutor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/product/{id:int}", async (
    int id,
    IProductService productService) =>
{
    Product product = await productService.GetProduct(id);

    return Results.Ok(product);
});

app.Run();
