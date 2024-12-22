var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.GtMotive_Renting_API>("gtmotive-renting-api");

builder.Build().Run();
