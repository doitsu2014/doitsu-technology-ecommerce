namespace Infrastructure.Otel.Configurations;

public class JaegerOptions
{
    public string AgentHost { get; set; } = string.Empty;
    public int AgentPort { get; set; }
    public string InstanceName { get; set; } = string.Empty;
}