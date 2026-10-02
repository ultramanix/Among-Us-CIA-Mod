using HarmonyLib;

namespace CIA.Mod.Systems.Stats;

[HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
public static class CiaInfoPanelPatch
{
    private static void Postfix()
    {
        CiaInfoPanelUi.Update();
    }
}
