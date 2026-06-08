namespace Revyne.Engine.Api;

/// <summary>Errors the engine can surface. Service maps these to its own API errors.</summary>
public enum CompetitionError
{
    InvalidArguments = 1,
    NotFound = 2,
    InternalError = 3,
    /// <summary>The supplied config/format is not handled by this engine implementation.</summary>
    UnsupportedFormat = 4
}

/// <summary>The kind of competition a config describes.</summary>
public enum CompetitionType
{
    Tournament,
    League
}

/// <summary>Supported tournament formats.</summary>
public enum TournamentFormat
{
    SingleElimination,
    DoubleElimination,
    Swiss,
    RoundRobin
}

/// <summary>How participants are ordered before fixtures are generated.</summary>
public enum SeedingType
{
    Standard,
    Random
}

/// <summary>Whether league fixtures are single or double round-robin.</summary>
public enum LeagueLegs
{
    OneLeg,
    TwoLegs
}
