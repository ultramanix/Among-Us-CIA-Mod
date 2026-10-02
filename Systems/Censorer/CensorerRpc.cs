using Reactor.Networking;
using Reactor.Networking.Attributes;
using Reactor.Networking.Rpc;
using UnityEngine;

namespace CIA.Mod.Systems.Censorer;

public enum CiaCustomRpcCalls : uint
{
    PlaceCensorSensor = 200
}

public static class CensorerRpc
{
    [MethodRpc((uint)CiaCustomRpcCalls.PlaceCensorSensor, LocalHandling = RpcLocalHandling.Before)]
    public static void RpcPlaceSensor(PlayerControl sender, int roomId, float x, float y, float z)
    {
        if (sender == null || sender.Data == null || sender.Data.IsDead || sender.Data.Disconnected)
            return;

        if (Roles.CiaRoleDetector.GetRole(sender) != Roles.CiaRole.Censorer)
            return;

        var maxSensors = (int)MiraAPI.GameOptions.OptionGroupSingleton<Options.Roles.CensorerRoleSettings>.Instance.MaxSensors;
        CensorerState.AddSensor(sender.PlayerId, roomId, new Vector3(x, y, z), maxSensors);
    }
}
