namespace WebApiWithHangfire;

public class BackgroundJobs
{
    public async Task Job(string jobType)
    {
        Console.WriteLine($"{jobType} Backgroundjob was started by Hangfire at {DateTime.Now:T}.");

        await Task.Delay(5000);
        
        Console.WriteLine($"{jobType} Backgroundjob was finished by Hangfire at {DateTime.Now:T}.");
    }
}
