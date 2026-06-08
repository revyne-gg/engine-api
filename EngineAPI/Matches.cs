namespace Revyne.Engine.Api;

/// <summary>
/// A fixture the engine wants created. Pure description — no ids, tenancy or
/// timestamps. The service is responsible for turning each spec into a
/// persisted match (assigning ids, tenant, created-at, etc.).
/// </summary>
public sealed class MatchSpec
{
    public string? HomeTeamId { get; init; }
    public string? AwayTeamId { get; init; }

    /// <summary>1-based round number this fixture belongs to.</summary>
    public int Round { get; init; } = 1;
}

/// <summary>A match that has been played, fed back into the engine for progression/outcome.</summary>
public sealed class FinishedMatch
{
    public string? HomeTeamId { get; init; }
    public string? AwayTeamId { get; init; }
    public int? ScoreHome { get; init; }
    public int? ScoreAway { get; init; }

    /// <summary>
    /// The already-resolved winner, if the service has persisted one. Progression
    /// (next-round generation) relies on this rather than re-deriving from scores.
    /// </summary>
    public string? WinnerTeamId { get; init; }

    public int Round { get; init; } = 1;
}

/// <summary>Resolved winner/loser for a finished match.</summary>
public sealed class MatchOutcome
{
    public string? WinnerTeamId { get; init; }
    public string? LoserTeamId { get; init; }

    /// <summary>True when the match ended level and the format permits a draw.</summary>
    public bool IsDraw { get; init; }
}
