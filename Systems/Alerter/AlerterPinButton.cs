using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using CIA.Mod.Options.Roles;
using CIA.Mod.Roles;
using UnityEngine;

namespace CIA.Mod.Systems.Alerter;

public sealed class AlerterPinButton : CustomActionButton<PlayerControl>
{
    public override string Name => "CIA PIN";
    public override float Cooldown => OptionGroupSingleton<AlerterRoleSettings>.Instance.PinCooldown;
    public override float EffectDuration => OptionGroupSingleton<AlerterRoleSettings>.Instance.PinDuration;
    public override LoadableAsset<Sprite> Sprite => MiraAssets.ChatOpenSprite;

    protected override void OnClick()
    {
        if (Target == null)
        {
            return;
        }

        AlerterState.Pin(Target, EffectDuration);
    }

    public override PlayerControl? GetTarget()
    {
        return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Color.black));
    }

    public override bool IsTargetValid(PlayerControl? target)
    {
        return target != null &&
               target != PlayerControl.LocalPlayer &&
               target.Data != null &&
               !target.Data.IsDead &&
               !target.Data.Disconnected;
    }

    public override bool Enabled(RoleBehaviour? role)
    {
        return role is AlerterRole;
    }

    public override void OnEffectEnd()
    {
        AlerterState.Clear();
        ResetTarget();
    }
}
