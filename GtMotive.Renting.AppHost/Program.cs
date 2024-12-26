var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("Database")
    .WithDataVolume()
    .WithPgAdmin();

var redis = builder.AddRedis("Cache");

builder.AddProject<Projects.GtMotive_Renting_API>("gtmotive-renting-api")
    .WithReference(postgres)
    .WithReference(redis);

builder.Build().Run();
