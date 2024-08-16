using Hangfire;
using WebApiWithHangfire;
using static System.Console;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfire(config => config.UseInMemoryStorage());
builder.Services.AddHangfireServer(config => config.SchedulePollingInterval = TimeSpan.FromSeconds(1));

var app = builder.Build();

app.MapGet("/enqueue-backgroundjob", () =>
{
    var info = $"Immediate Backgroundjob was sent to Hangfire at {DateTime.Now:T}.";
    WriteLine($"\n{info}");
    BackgroundJob.Enqueue<BackgroundJobs>(x => x.Job("Immediate"));
    return Results.Ok(info);
});

app.MapGet("/schedule-backgroundjob", () =>
{
    var info = $"Scheduled Backgroundjob was sent to Hangfire at {DateTime.Now:T}.";
    WriteLine($"\n{info}");
    BackgroundJob.Schedule<BackgroundJobs>(x => x.Job("Scheduled"), TimeSpan.FromSeconds(5));
    return Results.Ok(info);
});

app.Run();
