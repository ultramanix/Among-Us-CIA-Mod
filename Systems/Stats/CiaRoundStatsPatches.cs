using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;

namespace CIA.Mod.Systems.Stats;

public static class CiaRoundStatsPatches
{
    public static void Initialize()
    {
        MiraEventManager.RegisterEventHandler<RoundStartEvent>(OnRoundStart);
        MiraEventManager.RegisterEventHandler<AfterMurderEvent>(OnAfterMurder);
    }

    private static void OnRoundStart(RoundStartEvent _)
    {
        CiaRoundStats.Reset();
    }

    private static void OnAfterMurder(AfterMurderEvent @event)
    {
        if (@event.Source != null)
            CiaRoundStats.RecordKill(@event.Source.PlayerId);

        if (@event.Target != null)
            CiaRoundStats.RecordDeath(@event.Target.PlayerId);
    }
}
