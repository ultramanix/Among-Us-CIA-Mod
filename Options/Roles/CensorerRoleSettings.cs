using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;

namespace CIA.Mod.Options.Roles;

public sealed class CensorerRoleSettings : AbstractRoleOptionGroup<global::CIA.Mod.Roles.CensorerRole>
{
    public override string GroupName => "CIA.Mod.Role.Censorer";

    [ModdedNumberOption("CIA.Mod.Role.Censorer.Settings.MaxSensors", 1, 1, 3, 1)]
    public float MaxSensors { get; set; } = 1;
}
