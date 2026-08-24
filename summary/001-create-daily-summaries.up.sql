SET XACT_ABORT ON;

IF SCHEMA_ID(N'Scheme') IS NULL
    EXEC(N'CREATE SCHEMA [Scheme]');

IF OBJECT_ID(N'[Scheme].[DailyOperationsSummary]', N'U') IS NOT NULL
    THROW 51000, '[Scheme].[DailyOperationsSummary] already exists.', 1;

IF OBJECT_ID(N'[Scheme].[DailyEventTypesSummary]', N'U') IS NOT NULL
    THROW 51001, '[Scheme].[DailyEventTypesSummary] already exists.', 1;

BEGIN TRANSACTION;

CREATE TABLE [Scheme].[DailyOperationsSummary]
(
    [Id]                       bigint IDENTITY(1, 1) NOT NULL,
    [SummaryDate]              date NOT NULL,

    [TotalAttemptCount]        int NOT NULL,
    [InitialAttemptCount]      int NOT NULL,
    [RetryAttemptCount]        int NOT NULL,
    [SucceededAttemptCount]    int NOT NULL,
    [FailedAttemptCount]       int NOT NULL,
    [IntegrationAttemptCount]  int NOT NULL,
    [InternalAttemptCount]     int NOT NULL,

    [ProfileProcessingCount]   int NOT NULL,
    [ProfileCount]             int NOT NULL,
    [BusinessErrorsCount]      int NOT NULL,
    [EventsSentCount]          int NOT NULL,

    [CalculatedAt]             datetime2(7) NOT NULL,

    CONSTRAINT [PK_DailyOperationsSummary]
        PRIMARY KEY CLUSTERED ([Id]),

    CONSTRAINT [CK_DailyOperationsSummary_NonNegativeCounts]
        CHECK
        (
            [TotalAttemptCount] >= 0
            AND [InitialAttemptCount] >= 0
            AND [RetryAttemptCount] >= 0
            AND [SucceededAttemptCount] >= 0
            AND [FailedAttemptCount] >= 0
            AND [IntegrationAttemptCount] >= 0
            AND [InternalAttemptCount] >= 0
            AND [ProfileProcessingCount] >= 0
            AND [ProfileCount] >= 0
            AND [BusinessErrorsCount] >= 0
            AND [EventsSentCount] >= 0
        ),

    CONSTRAINT [CK_DailyOperationsSummary_AttemptSplit]
        CHECK ([InitialAttemptCount] + [RetryAttemptCount] = [TotalAttemptCount]),

    CONSTRAINT [CK_DailyOperationsSummary_ResultSplit]
        CHECK ([SucceededAttemptCount] + [FailedAttemptCount] = [TotalAttemptCount]),

    CONSTRAINT [CK_DailyOperationsSummary_EventKindSplit]
        CHECK ([IntegrationAttemptCount] + [InternalAttemptCount] = [TotalAttemptCount])
);

CREATE UNIQUE INDEX [UX_DailyOperationsSummary_SummaryDate]
    ON [Scheme].[DailyOperationsSummary] ([SummaryDate]);

CREATE TABLE [Scheme].[DailyEventTypesSummary]
(
    [Id]                       bigint IDENTITY(1, 1) NOT NULL,
    [SummaryDate]              date NOT NULL,
    [EventType]                nvarchar(256) NOT NULL,
    [IsIntegrationEvent]       bit NOT NULL,

    [TotalAttemptCount]        int NOT NULL,
    [InitialAttemptCount]      int NOT NULL,
    [RetryAttemptCount]        int NOT NULL,
    [SucceededAttemptCount]    int NOT NULL,
    [FailedAttemptCount]       int NOT NULL,

    [AverageDurationMs]        decimal(18, 2) NULL,
    [MaxDurationMs]            int NULL,
    [CalculatedAt]             datetime2(7) NOT NULL,

    CONSTRAINT [PK_DailyEventTypesSummary]
        PRIMARY KEY CLUSTERED ([Id]),

    CONSTRAINT [CK_DailyEventTypesSummary_NonNegativeCounts]
        CHECK
        (
            [TotalAttemptCount] > 0
            AND [InitialAttemptCount] >= 0
            AND [RetryAttemptCount] >= 0
            AND [SucceededAttemptCount] >= 0
            AND [FailedAttemptCount] >= 0
        ),

    CONSTRAINT [CK_DailyEventTypesSummary_AttemptSplit]
        CHECK ([InitialAttemptCount] + [RetryAttemptCount] = [TotalAttemptCount]),

    CONSTRAINT [CK_DailyEventTypesSummary_ResultSplit]
        CHECK ([SucceededAttemptCount] + [FailedAttemptCount] = [TotalAttemptCount]),

    CONSTRAINT [CK_DailyEventTypesSummary_Durations]
        CHECK
        (
            (
                [SucceededAttemptCount] = 0
                AND [AverageDurationMs] IS NULL
                AND [MaxDurationMs] IS NULL
            )
            OR
            (
                [SucceededAttemptCount] > 0
                AND [AverageDurationMs] IS NOT NULL
                AND [MaxDurationMs] IS NOT NULL
                AND [AverageDurationMs] >= 0
                AND [MaxDurationMs] >= 0
                AND [AverageDurationMs] <= [MaxDurationMs]
            )
        )
);

CREATE UNIQUE INDEX [UX_DailyEventTypesSummary_Grain]
    ON [Scheme].[DailyEventTypesSummary]
       ([SummaryDate], [EventType], [IsIntegrationEvent]);

CREATE INDEX [IX_DailyEventTypesSummary_EventTypeDate]
    ON [Scheme].[DailyEventTypesSummary] ([EventType], [SummaryDate])
    INCLUDE
       ([IsIntegrationEvent], [TotalAttemptCount], [InitialAttemptCount],
        [RetryAttemptCount], [SucceededAttemptCount], [FailedAttemptCount],
        [AverageDurationMs], [MaxDurationMs]);

COMMIT TRANSACTION;
