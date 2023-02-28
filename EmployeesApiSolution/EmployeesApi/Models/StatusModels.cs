namespace EmployeesApi.Models;

public record GetStatusResponse
{
    public string Message { get; set; } = string.Empty;

    public StatusLevel StatusLevel { get; set; }

    public GetStatusContactInfo? HelpContact { get; set; }
}

public record GetStatusContactInfo(string Name, string Phone, string Email);
public enum StatusLevel {  OperatingNormally, Degraded, AboutDead, OnFire};