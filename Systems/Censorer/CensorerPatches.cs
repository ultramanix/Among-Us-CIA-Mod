using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;
using MiraAPI.GameOptions;
using MiraAPI.Roles;
using CIA.Mod.Options.Roles;
using CIA.Mod.Roles;
using System.Text;

namespace CIA.Mod.Systems.Censorer;

public static class CensorerPatches
{
    public static void Initialize()
    {
        MiraEventManager.RegisterEventHandler<RoundStartEvent>(OnRoundStart);
    }

    private static void OnRoundStart(RoundStartEvent _)
    {
        CensorerState.Clear();
    }

    public static string BuildRoomList(int roomId)
    {
        var builder = new StringBuilder();

        if (!CensorerState.TryGetSensorForRoom(roomId, out _))
            return string.Empty;

        builder.AppendLine("CENSOR SENSOR");
        builder.AppendLine("INSIDE:");

        var room = ShipStatus.Instance.AllRooms.FirstOrDefault(x => x.RoomId == roomId);
        if (room == null)
            return builder.ToString();

        foreach (var player in MiraAPI.Utilities.Helpers.GetAlivePlayers())
        {
            var playerRoom = MiraAPI.Utilities.Helpers.GetRoom(player.transform.position);
            if (playerRoom != null && playerRoom.RoomId == roomId)
                builder.AppendLine(player.Data.PlayerName);
        }

        return builder.ToString().TrimEnd();
    }

    public static bool CanPlaceSensor()
    {
        var role = PlayerControl.LocalPlayer;
        return role != null &&
               CiaRoleDetector.GetRole(role) == CiaRole.Censorer &&
               CensorerState.ActiveSensors.Count <
               (int)OptionGroupSingleton<CensorerRoleSettings>.Instance.MaxSensors;
    }
}
