using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using CIA.Mod.Options.Roles;
using CIA.Mod.Roles;
using UnityEngine;

namespace CIA.Mod.Systems.Censorer;

public sealed class CensorerSensorButton : CustomActionButton
{
    public override string Name => "CENSOR";
    public override float Cooldown => 1f;
    public override LoadableAsset<Sprite> Sprite => MiraAssets.ChatOpenSprite;

    public override bool Enabled(RoleBehaviour? role) => role is CensorerRole;

    protected override void OnClick()
    {
        var local = PlayerControl.LocalPlayer;
        if (local == null || !CensorerPatches.CanPlaceSensor())
            return;

        if (CensorerState.TryGetSensorForRoom(
                MiraAPI.Utilities.Helpers.GetRoom(local.transform.position)?.RoomId ?? -1,
                out var sensor))
        {
            CensorerPanelUi.Open(sensor.RoomId);
            return;
        }

        if (CensorerState.TryPlace(
                local.PlayerId,
                (int)OptionGroupSingleton<CensorerRoleSettings>.Instance.MaxSensors))
        {
            var room = MiraAPI.Utilities.Helpers.GetRoom(local.transform.position);
            if (room != null)
                CensorerPanelUi.Open(room.RoomId);
        }
    }
}
