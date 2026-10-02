using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;

namespace CIA.Mod.Options.Roles;

public sealed class AlerterRoleSettings : AbstractRoleOptionGroup<global::CIA.Mod.Roles.AlerterRole>
{
    public override string GroupName => "CIA.Mod.Role.Alerter";

    [ModdedNumberOption("CIA.Mod.Role.Alerter.Settings.PinCooldown", 30, 10, 90, 1, MiraNumberSuffixes.Seconds)]
    public float PinCooldown { get; set; } = 30;

    [ModdedNumberOption("CIA.Mod.Role.Alerter.Settings.PinDuration", 20, 10, 30, 1, MiraNumberSuffixes.Seconds)]
    public float PinDuration { get; set; } = 20;

    [ModdedNumberOption("CIA.Mod.Role.Alerter.Settings.AlertDuration", 7, 5, 10, 1, MiraNumberSuffixes.Seconds)]
    public float AlertDuration { get; set; } = 7;
}
