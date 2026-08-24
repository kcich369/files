namespace OperationalReporting.Persistence.Entities;

public sealed class DailyEventTypesSummary
{
    private const int MaxEventTypeLength = 256;

    private DailyEventTypesSummary()
    {
    }

    private DailyEventTypesSummary(
        DateOnly summaryDate,
        string eventType,
        bool isIntegrationEvent,
        int totalAttemptCount,
        int initialAttemptCount,
        int retryAttemptCount,
        int succeededAttemptCount,
        int failedAttemptCount,
        decimal? averageDurationMs,
        int? maxDurationMs,
        DateTime calculatedAt)
    {
        ValidateEventType(eventType);
        ValidateAttemptCounts(
            totalAttemptCount,
            initialAttemptCount,
            retryAttemptCount,
            succeededAttemptCount,
            failedAttemptCount);
        ValidateDurations(succeededAttemptCount, averageDurationMs, maxDurationMs);

        SummaryDate = summaryDate;
        EventType = eventType;
        IsIntegrationEvent = isIntegrationEvent;
        TotalAttemptCount = totalAttemptCount;
        InitialAttemptCount = initialAttemptCount;
        RetryAttemptCount = retryAttemptCount;
        SucceededAttemptCount = succeededAttemptCount;
        FailedAttemptCount = failedAttemptCount;
        AverageDurationMs = averageDurationMs;
        MaxDurationMs = maxDurationMs;
        CalculatedAt = calculatedAt;
    }

    public long Id { get; private set; }

    public DateOnly SummaryDate { get; private set; }

    public string EventType { get; private set; } = null!;

    public bool IsIntegrationEvent { get; private set; }

    public int TotalAttemptCount { get; private set; }

    public int InitialAttemptCount { get; private set; }

    public int RetryAttemptCount { get; private set; }

    public int SucceededAttemptCount { get; private set; }

    public int FailedAttemptCount { get; private set; }

    public decimal? AverageDurationMs { get; private set; }

    public int? MaxDurationMs { get; private set; }

    public DateTime CalculatedAt { get; private set; }

    public static DailyEventTypesSummary Create(
        DateOnly summaryDate,
        string eventType,
        bool isIntegrationEvent,
        int totalAttemptCount,
        int initialAttemptCount,
        int retryAttemptCount,
        int succeededAttemptCount,
        int failedAttemptCount,
        decimal? averageDurationMs,
        int? maxDurationMs,
        DateTime calculatedAt)
    {
        return new DailyEventTypesSummary(
            summaryDate,
            eventType,
            isIntegrationEvent,
            totalAttemptCount,
            initialAttemptCount,
            retryAttemptCount,
            succeededAttemptCount,
            failedAttemptCount,
            averageDurationMs,
            maxDurationMs,
            calculatedAt);
    }

    private static void ValidateEventType(string eventType)
    {
        if (string.IsNullOrWhiteSpace(eventType))
        {
            throw new ArgumentException("EventType is required.", nameof(eventType));
        }

        if (eventType.Length > MaxEventTypeLength)
        {
            throw new ArgumentException(
                $"EventType cannot exceed {MaxEventTypeLength} characters.",
                nameof(eventType));
        }
    }

    private static void ValidateAttemptCounts(
        int totalAttemptCount,
        int initialAttemptCount,
        int retryAttemptCount,
        int succeededAttemptCount,
        int failedAttemptCount)
    {
        EnsureNonNegative(totalAttemptCount, nameof(totalAttemptCount));
        EnsureNonNegative(initialAttemptCount, nameof(initialAttemptCount));
        EnsureNonNegative(retryAttemptCount, nameof(retryAttemptCount));
        EnsureNonNegative(succeededAttemptCount, nameof(succeededAttemptCount));
        EnsureNonNegative(failedAttemptCount, nameof(failedAttemptCount));

        if (totalAttemptCount == 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(totalAttemptCount),
                totalAttemptCount,
                "An event-type summary must contain at least one attempt.");
        }

        if ((long)initialAttemptCount + retryAttemptCount != totalAttemptCount)
        {
            throw new ArgumentException(
                "InitialAttemptCount and RetryAttemptCount must sum to TotalAttemptCount.");
        }

        if ((long)succeededAttemptCount + failedAttemptCount != totalAttemptCount)
        {
            throw new ArgumentException(
                "SucceededAttemptCount and FailedAttemptCount must sum to TotalAttemptCount.");
        }
    }

    private static void ValidateDurations(
        int succeededAttemptCount,
        decimal? averageDurationMs,
        int? maxDurationMs)
    {
        if (succeededAttemptCount == 0)
        {
            if (averageDurationMs is not null || maxDurationMs is not null)
            {
                throw new ArgumentException(
                    "Duration statistics must be null when there are no successful attempts.");
            }

            return;
        }

        if (averageDurationMs is null || maxDurationMs is null)
        {
            throw new ArgumentException(
                "Duration statistics are required when successful attempts exist.");
        }

        if (averageDurationMs < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(averageDurationMs),
                averageDurationMs,
                "Average duration cannot be negative.");
        }

        if (maxDurationMs < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(maxDurationMs),
                maxDurationMs,
                "Maximum duration cannot be negative.");
        }

        if (averageDurationMs > maxDurationMs)
        {
            throw new ArgumentException("AverageDurationMs cannot exceed MaxDurationMs.");
        }
    }

    private static void EnsureNonNegative(int value, string parameterName)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, value, "Count cannot be negative.");
        }
    }
}
