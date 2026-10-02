using MiraAPI.GameModes;
using MiraAPI.Roles;
using UnityEngine;

namespace CIA.Mod.Roles;

public sealed class AlerterRole : CrewmateRole, ICustomRole
{
    public string IdPart => "Alerter";
    public string IdPrefix => "CIA.Mod.Role";

    public Color RoleColor => Color.black;
    public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;

    public string RoleMedDescription => "ALERTER\n\nRol eğitimi: https://www.youtube.com/@chakabania";

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