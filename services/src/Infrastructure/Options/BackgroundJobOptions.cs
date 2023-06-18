namespace Infrastructure.Options;

public class BackgroundJobOptions
{
    public JobOptions SyncAllEntitiesDaily { get; set; }

    public class JobOptions
    {
        public string Cron { get; set; }
        public string TimeZone { get; set; }
    }
}