using HarmonyLib;
using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;
using MiraAPI.GameOptions;
using CIA.Mod.Options.Roles;
using CIA.Mod.Roles;

namespace CIA.Mod.Systems.Censorer;

public static class CensorerPatches
{
    public static void Initialize()
    {
        MiraEventManager.RegisterEventHandler<RoundStartEvent>(OnRoundStart);
    }

    private static void OnRoundStart(RoundStartEvent _)
    {
        CensorerState.Clear();
        CensorerPanelUi.Close();
    }

    public static bool CanPlaceSensor()
    {
        var role = PlayerControl.LocalPlayer;
        return role != null &&
               CiaRoleDetector.GetRole(role) == CiaRole.Censorer &&
               CensorerState.ActiveSensors.Count <
               (int)OptionGroupSingleton<CensorerRoleSettings>.Instance.MaxSensors;
    }
}

[HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
public static class CensorerHudPatch
{
    private static void Postfix()
    {
        CensorerPanelUi.Update();
    }
}
