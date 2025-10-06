var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithEnvironment("POSTGRES_USER", "postgres")
    .WithEnvironment("POSTGRES_PASSWORD", "postgres")
    .WithEnvironment("POSTGRES_DB", "smart_сart")
    .WithEnvironment("POSTGRES_HOST_AUTH_METHOD", "trust")
    .WithDataVolume(); 

var db = postgres.AddDatabase("DatabaseContext", "smart_сart");

var api = builder.AddProject<Projects.SmartCartBackend_API>("smart-cart-backend-api")
    .WithReference(db);

builder.Build().Run();