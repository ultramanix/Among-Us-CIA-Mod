using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;

namespace CIA.Mod.Options.Roles;

public sealed class KillerRoleSettings : AbstractRoleOptionGroup<global::CIA.Mod.Roles.KillerRole>
{
    public override string GroupName => "CIA.Mod.Role.Killer";

    [ModdedNumberOption("CIA.Mod.Role.Killer.Settings.KillCooldown", 20, 10, 30, 1, MiraNumberSuffixes.Seconds)]
    public float KillCooldown { get; set; } = 20;
}
