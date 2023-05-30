using System;

namespace Microsoft.Extensions.Logging
{
    public static class LoggerExtensions
    {
        public static void LogInterpolatedCritical(this ILogger logger, FormattableString formattableString,
            Exception? exception = default, EventId eventId = default)
        {
            
            logger.LogCritical(eventId, exception, formattableString.Format, formattableString.GetArguments());
        }

        public static void LogInterpolatedDebug(this ILogger logger, FormattableString formattableString,
            Exception? exception = default, EventId eventId = default)
        {
            logger.LogDebug(eventId, exception, formattableString.Format, formattableString.GetArguments());
        }

        public static void LogInterpolatedError(this ILogger logger, FormattableString formattableString,
            Exception? exception = default, EventId eventId = default)
        {
            logger.LogError(eventId, exception, formattableString.Format, formattableString.GetArguments());
        }

        public static void LogInterpolatedInformation(this ILogger logger, FormattableString formattableString,
            Exception? exception = default, EventId eventId = default)
        {
            logger.LogInformation(eventId, exception, formattableString.Format, formattableString.GetArguments());
        }

        public static void LogInterpolatedTrace(this ILogger logger, FormattableString formattableString,
            Exception? exception = default, EventId eventId = default)
        {
            logger.LogTrace(eventId, exception, formattableString.Format, formattableString.GetArguments());
        }

        public static void LogInterpolatedWarning(this ILogger logger, FormattableString formattableString,
            Exception? exception = default, EventId eventId = default)
        {
            logger.LogWarning(eventId, exception, formattableString.Format, formattableString.GetArguments());
        }
    }
}
