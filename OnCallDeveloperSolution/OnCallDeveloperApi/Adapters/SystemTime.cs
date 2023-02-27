namespace OnCallDeveloperApi.Adapters;

public interface ISystemTime
{
    DateTimeOffset GetCurrent();
}

public class SystemTime : ISystemTime
{
    public DateTimeOffset GetCurrent()
    {
        return DateTimeOffset.Now;
    }
}
