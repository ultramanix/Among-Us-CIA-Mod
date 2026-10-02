using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;
using MiraAPI.Roles;

namespace CIA.Mod.Events;

public static class CiaIntroEvents
{
    public static void Initialize()
    {
        MiraEventManager.RegisterEventHandler<IntroRoleRevealEvent>(OnRoleReveal);
        MiraEventManager.RegisterEventHandler<IntroEndEvent>(OnIntroEnd);
    }

    private static void OnRoleReveal(IntroRoleRevealEvent @event)
    {
        var localPlayer = PlayerControl.LocalPlayer;
        if (localPlayer == null || localPlayer.Data?.Role == null)
        {
            return;
        }

        if (localPlayer.Data.Role is ICustomRole customRole)
        {
            CiaIntroState.CurrentRoleName = customRole.RoleName;
            CiaIntroState.IsCustomRole = true;
            return;
        }

        CiaIntroState.CurrentRoleName = localPlayer.Data.Role.NiceName;
        CiaIntroState.IsCustomRole = false;
    }

    private static void OnIntroEnd(IntroEndEvent @event)
    {
        CiaIntroState.IsIntroActive = false;
    }
}
