using DbmsGrpc.Services;
using Grpc.Core.Interceptors;
using Grpc.Core;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<LoggingInterceptor>();
});
builder.Services.AddSingleton<DbmsProcessorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<DbmsProcessorService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

public class LoggingInterceptor : Interceptor
{
    private readonly ILogger<LoggingInterceptor> _logger;

    public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
    {
        _logger = logger;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        _logger.LogInformation($"Method: {context.Method}");
        _logger.LogInformation($"Request: {request}");

        var response = await base.UnaryServerHandler(request, context, continuation);

        _logger.LogInformation($"Response: {response}");

        return response;
    }
}