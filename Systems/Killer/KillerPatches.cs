using HarmonyLib;
using MiraAPI.Events;
using MiraAPI.Events.Mira;
using MiraAPI.GameOptions;
using MiraAPI.Networking;
using MiraAPI.Roles;
using UnityEngine;
using CIA.Mod.Options.Roles;
using CIA.Mod.Roles;

namespace CIA.Mod.Systems.Killer;

public static class KillerPatches
{
    public static void Initialize()
    {
        MiraEventManager.RegisterEventHandler<BeforeMurderEvent>(OnBeforeMurder);
    }

    private static void OnBeforeMurder(BeforeMurderEvent @event)
    {
        var source = @event.Source;
        var target = @event.Target;

        if (source == null || target == null || CiaRoleDetector.GetRole(source) != CiaRole.Killer)
        {
            return;
        }

        if (!source.AmOwner)
        {
            return;
        }

        if (!IsSameRoom(source, target))
        {
            @event.Cancel();
            return;
        }

        if (target.Data.IsDead || target.Data.Disconnected)
        {
            @event.Cancel();
            return;
        }

        @event.Cancel();

        if (target.Data.Role.Role == RoleTypes.Impostor || target.Data.Role is ICustomRole customRole && customRole.Team == ModdedRoleTeams.Impostor)
        {
            source.RpcCustomMurder(
                target,
                MeetingCheck.OutsideMeeting,
                resetKillTimer: false,
                createDeadBody: false,
                teleportMurderer: false,
                showKillAnim: true,
                playKillSound: true);

            source.SetKillTimer(OptionGroupSingleton<KillerRoleSettings>.Instance.KillCooldown);
            return;
        }

        if (KillerHistory.TryGetPosition(target.PlayerId, 5f, out var rollbackPosition))
        {
            target.NetTransform.RpcSnapTo(rollbackPosition);
        }

        source.Die(DeathReason.Kill, true);
        source.SetKillTimer(OptionGroupSingleton<KillerRoleSettings>.Instance.KillCooldown);
    }

    private static bool IsSameRoom(PlayerControl source, PlayerControl target)
    {
        if (ShipStatus.Instance == null)
        {
            return false;
        }

        var sourceRoom = MiraAPI.Utilities.Helpers.GetRoom(source.transform.position);
        var targetRoom = MiraAPI.Utilities.Helpers.GetRoom(target.transform.position);

        return sourceRoom != null && targetRoom != null && sourceRoom == targetRoom;
    }
}

[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
public static class KillerHistoryPatch
{
    private static void Postfix(PlayerControl __instance)
    {
        if (AmongUsClient.Instance == null || ShipStatus.Instance == null)
        {
            return;
        }

        KillerHistory.Record(__instance);
    }
}
