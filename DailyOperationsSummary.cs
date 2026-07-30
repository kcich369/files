namespace OperationalReporting.Persistence.Entities;

public sealed class DailyOperationsSummary
{
    private DailyOperationsSummary()
    {
    }

    private DailyOperationsSummary(
        DateOnly summaryDate,
        int totalAttemptCount,
        int initialAttemptCount,
        int retryAttemptCount,
        int succeededAttemptCount,
        int failedAttemptCount,
        int integrationAttemptCount,
        int internalAttemptCount,
        int profileProcessingCount,
        int profileCount,
        int businessErrorsCount,
        int eventsSentCount,
        DateTime calculatedAt)
    {
        ValidateAttemptCounts(
            totalAttemptCount,
            initialAttemptCount,
            retryAttemptCount,
            succeededAttemptCount,
            failedAttemptCount,
            integrationAttemptCount,
            internalAttemptCount);

        EnsureNonNegative(profileProcessingCount, nameof(profileProcessingCount));
        EnsureNonNegative(profileCount, nameof(profileCount));
        EnsureNonNegative(businessErrorsCount, nameof(businessErrorsCount));
        EnsureNonNegative(eventsSentCount, nameof(eventsSentCount));

        SummaryDate = summaryDate;
        TotalAttemptCount = totalAttemptCount;
        InitialAttemptCount = initialAttemptCount;
        RetryAttemptCount = retryAttemptCount;
        SucceededAttemptCount = succeededAttemptCount;
        FailedAttemptCount = failedAttemptCount;
        IntegrationAttemptCount = integrationAttemptCount;
        InternalAttemptCount = internalAttemptCount;
        ProfileProcessingCount = profileProcessingCount;
        ProfileCount = profileCount;
        BusinessErrorsCount = businessErrorsCount;
        EventsSentCount = eventsSentCount;
        CalculatedAt = calculatedAt;
    }

    public long Id { get; private set; }

    public DateOnly SummaryDate { get; private set; }

    public int TotalAttemptCount { get; private set; }

    public int InitialAttemptCount { get; private set; }

    public int RetryAttemptCount { get; private set; }

    public int SucceededAttemptCount { get; private set; }

    public int FailedAttemptCount { get; private set; }

    public int IntegrationAttemptCount { get; private set; }

    public int InternalAttemptCount { get; private set; }

    public int ProfileProcessingCount { get; private set; }

    public int ProfileCount { get; private set; }

    public int BusinessErrorsCount { get; private set; }

    public int EventsSentCount { get; private set; }

    public DateTime CalculatedAt { get; private set; }

    public static DailyOperationsSummary Create(
        DateOnly summaryDate,
        int totalAttemptCount,
        int initialAttemptCount,
        int retryAttemptCount,
        int succeededAttemptCount,
        int failedAttemptCount,
        int integrationAttemptCount,
        int internalAttemptCount,
        int profileProcessingCount,
        int profileCount,
        int businessErrorsCount,
        int eventsSentCount,
        DateTime calculatedAt)
    {
        return new DailyOperationsSummary(
            summaryDate,
            totalAttemptCount,
            initialAttemptCount,
            retryAttemptCount,
            succeededAttemptCount,
            failedAttemptCount,
            integrationAttemptCount,
            internalAttemptCount,
            profileProcessingCount,
            profileCount,
            businessErrorsCount,
            eventsSentCount,
            calculatedAt);
    }

    private static void ValidateAttemptCounts(
        int totalAttemptCount,
        int initialAttemptCount,
        int retryAttemptCount,
        int succeededAttemptCount,
        int failedAttemptCount,
        int integrationAttemptCount,
        int internalAttemptCount)
    {
        EnsureNonNegative(totalAttemptCount, nameof(totalAttemptCount));
        EnsureNonNegative(initialAttemptCount, nameof(initialAttemptCount));
        EnsureNonNegative(retryAttemptCount, nameof(retryAttemptCount));
        EnsureNonNegative(succeededAttemptCount, nameof(succeededAttemptCount));
        EnsureNonNegative(failedAttemptCount, nameof(failedAttemptCount));
        EnsureNonNegative(integrationAttemptCount, nameof(integrationAttemptCount));
        EnsureNonNegative(internalAttemptCount, nameof(internalAttemptCount));

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

        if ((long)integrationAttemptCount + internalAttemptCount != totalAttemptCount)
        {
            throw new ArgumentException(
                "IntegrationAttemptCount and InternalAttemptCount must sum to TotalAttemptCount.");
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
