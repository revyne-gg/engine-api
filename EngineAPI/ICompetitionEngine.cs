namespace Revyne.Engine.Api;

/// <summary>
/// The single contract the competitions microservice depends on. A deployment
/// supplies exactly one implementation (the default open core, an in-house lib,
/// or inline code). The engine is a pure function of its inputs: given config
/// and state it returns fixtures to create — it never touches persistence.
/// </summary>
public interface ICompetitionEngine
{
    /// <summary>Generate the opening set of fixtures for a fresh competition.</summary>
    Result<IReadOnlyList<MatchSpec>, CompetitionError> GenerateInitialMatches(
        EngineCompetitionConfig config,
        IReadOnlyList<string> teamIds);

    /// <summary>
    /// Given everything played so far, produce the next set of fixtures.
    /// An empty list means the competition has no further matches (complete).
    /// </summary>
    Result<IReadOnlyList<MatchSpec>, CompetitionError> GenerateNextMatches(
        EngineCompetitionConfig config,
        IReadOnlyList<FinishedMatch> playedMatches);

    /// <summary>Resolve winner/loser/draw for a single finished match.</summary>
    Result<MatchOutcome, CompetitionError> ResolveOutcome(
        EngineCompetitionConfig config,
        FinishedMatch match);
}
