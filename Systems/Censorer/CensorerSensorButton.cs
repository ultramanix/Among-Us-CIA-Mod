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

        var room = MiraAPI.Utilities.Helpers.GetRoom(local.transform.position);
        if (room == null)
            return;

        if (CensorerState.TryGetSensorForRoom(room.RoomId, out var sensor))
        {
            CensorerPanelUi.Open(sensor.RoomId);
            return;
        }

        if (!CensorerState.CanAdd(
                (int)OptionGroupSingleton<CensorerRoleSettings>.Instance.MaxSensors))
            return;

        CensorerRpc.RpcPlaceSensor(
            local,
            room.RoomId,
            local.transform.position.x,
            local.transform.position.y,
            local.transform.position.z);

        CensorerPanelUi.Open(room.RoomId);
    }
}
