namespace Revyne.Engine.Api;

/// <summary>
/// Strategy contract for a single tournament format. Implementations live in the
/// engine library, not the microservice — the service only ever sees
/// <see cref="ICompetitionEngine"/>. A composite engine selects the right
/// strategy by <see cref="Format"/>.
/// </summary>
public interface ITournamentEngine
{
    TournamentFormat Format { get; }

    Result<IReadOnlyList<MatchSpec>, CompetitionError> GenerateInitialMatches(
        TournamentEngineConfig config,
        IReadOnlyList<string> teamIds);

    Result<IReadOnlyList<MatchSpec>, CompetitionError> GenerateNextMatches(
        TournamentEngineConfig config,
        IReadOnlyList<FinishedMatch> playedMatches);

    Result<MatchOutcome, CompetitionError> ResolveOutcome(
        TournamentEngineConfig config,
        FinishedMatch match);
}
