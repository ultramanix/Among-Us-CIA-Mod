using HarmonyLib;

namespace CIA.Mod.Events;

[HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
public static class CiaRolePanelPatch
{
    private static void Postfix()
    {
        CiaRolePanelUi.Update();
    }
}
