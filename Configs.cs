namespace Revyne.Engine.Api;

/// <summary>
/// Base for the configuration an engine needs to generate fixtures.
/// Intentionally free of any persistence/tenancy concerns — those stay in the
/// service. The engine receives only what it needs to compute matches.
/// </summary>
public abstract class EngineCompetitionConfig
{
    public abstract CompetitionType Type { get; }

    /// <summary>Best-of for each generated match (defaults to single game).</summary>
    public int BestOf { get; set; } = 1;
}

/// <summary>Config for generating tournament fixtures.</summary>
public sealed class TournamentEngineConfig : EngineCompetitionConfig
{
    public override CompetitionType Type => CompetitionType.Tournament;

    public TournamentFormat Format { get; set; }
    public SeedingType SeedingType { get; set; } = SeedingType.Standard;
    public bool BracketReset { get; set; }
}

/// <summary>Config for generating league fixtures.</summary>
public sealed class LeagueEngineConfig : EngineCompetitionConfig
{
    public override CompetitionType Type => CompetitionType.League;

    public LeagueLegs Legs { get; set; } = LeagueLegs.OneLeg;
}
