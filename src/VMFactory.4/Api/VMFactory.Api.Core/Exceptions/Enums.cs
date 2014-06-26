
namespace VMFactory.Api.Core.Exceptions
{
    /// <summary>
    /// Severity level of Exception
    /// </summary>
    public enum SeverityLevel { Fatal, Critical, Information }

    /// <summary>
    /// Log level of Exception
    /// </summary>
    public enum LogLevel { Debug, Event }

    /// <summary>
    /// Operation types
    /// </summary>
    public enum Operation { Insert, Update, NotAplicable }

}
