using AmongUs.GameOptions;
using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;
using MiraAPI.GameModes;
using MiraAPI.Roles;
using CIA.Mod.Options.Roles;
using CIA.Mod.Roles;

namespace CIA.Mod.Systems.Alerter;

public static class AlerterPatches
{
    public static void Initialize()
    {
        MiraEventManager.RegisterEventHandler<AfterMurderEvent>(OnAfterMurder);
        MiraEventManager.RegisterEventHandler<RoundStartEvent>(OnRoundStart);
    }

    private static void OnRoundStart(RoundStartEvent _)
    {
        AlerterState.Clear();
    }

    private static void OnAfterMurder(AfterMurderEvent @event)
    {
        var localPlayer = PlayerControl.LocalPlayer;
        if (localPlayer == null || CiaRoleDetector.GetRole(localPlayer) != CiaRole.Alerter)
        {
            return;
        }

        var pinned = AlerterState.PinnedPlayer;
        if (pinned == null || @event.Source != pinned)
        {
            return;
        }

        if (!IsImpostor(@event.Source))
        {
            return;
        }

        AlerterState.SetAlert(OptionGroupSingleton<AlerterRoleSettings>.Instance.AlertDuration);

        if (@event.Source.KillSfx != null)
        {
            SoundManager.Instance.PlaySound(@event.Source.KillSfx, false, 1f);
        }
    }

    private static bool IsImpostor(PlayerControl player)
    {
        return player.Data.Role.TeamType == RoleTeamTypes.Impostor ||
               player.Data.Role is ICustomRole customRole && customRole.Team == ModdedRoleTeams.Impostor;
    }
}
