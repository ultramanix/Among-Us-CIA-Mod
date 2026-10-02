using MiraAPI.Roles;

namespace CIA.Mod.Roles;

public static class CiaRoleDetector
{
    public static CiaRole GetRole(PlayerControl player)
    {
        if (player == null || player.Data == null)
        {
            return CiaRole.None;
        }

        return player.Data.Role switch
        {
            KillerRole => CiaRole.Killer,
            AlerterRole => CiaRole.Alerter,
            CensorerRole => CiaRole.Censorer,
            _ => CiaRole.None
        };
    }

    public static bool IsCia(PlayerControl player) => GetRole(player) != CiaRole.None;
}
