using MiraAPI.GameModes;
using MiraAPI.Roles;
using UnityEngine;

namespace CIA.Mod.Roles;

public sealed class KillerRole : CrewmateRole, ICustomRole
{
    public string IdPart => "Killer";
    public string IdPrefix => "CIA.Mod.Role";
    public string RoleName => "KILLER";
    public string RoleDescription => "CIA KILLER";
    public string RoleMedDescription => "KILLER";
    public string RoleLongDescription => "KILLER";

    public Color RoleColor => Color.black;
    public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;

    public CustomRoleConfiguration Configuration => new(this)
    {
        MaxRoleCount = 1,
        DefaultRoleCount = 1,
        DefaultChance = 100,
        CanModifyChance = false,
        CanGetKilled = true,
        UseVanillaKillButton = false,
        CanUseVent = false,
        CanUseSabotage = false,
        TasksCountForProgress = false
    };
}
