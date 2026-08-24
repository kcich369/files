SET XACT_ABORT ON;

BEGIN TRANSACTION;

IF OBJECT_ID(N'[Scheme].[DailyEventTypesSummary]', N'U') IS NOT NULL
    DROP TABLE [Scheme].[DailyEventTypesSummary];

IF OBJECT_ID(N'[Scheme].[DailyOperationsSummary]', N'U') IS NOT NULL
    DROP TABLE [Scheme].[DailyOperationsSummary];

COMMIT TRANSACTION;
