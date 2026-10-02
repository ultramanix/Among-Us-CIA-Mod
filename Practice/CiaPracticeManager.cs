using AmongUs.GameOptions;
using MiraAPI.Roles;

namespace CIA.Mod.Practice;

public static class CiaPracticeManager
{
    public static bool Assign(PlayerControl target, CiaPracticeTarget role)
    {
        if (target == null)
            return false;

        switch (role)
        {
            case CiaPracticeTarget.Crewmate:
                RoleManager.Instance.SetRole(target, RoleTypes.Crewmate);
                return true;

            case CiaPracticeTarget.Impostor:
                RoleManager.Instance.SetRole(target, RoleTypes.Impostor);
                return true;

            case CiaPracticeTarget.Killer:
                return SetCustom(target, typeof(Roles.KillerRole));

            case CiaPracticeTarget.Alerter:
                return SetCustom(target, typeof(Roles.AlerterRole));

            case CiaPracticeTarget.Censorer:
                return SetCustom(target, typeof(Roles.CensorerRole));

            default:
                return false;
        }
    }

    private static bool SetCustom(PlayerControl target, System.Type roleType)
    {
        var role = CustomRoleManager.CustomRoleBehaviours
            .FirstOrDefault(x => x.GetType() == roleType);

        if (role == null)
            return false;

        RoleManager.Instance.SetRole(target, role.Role);
        return true;
    }
}
