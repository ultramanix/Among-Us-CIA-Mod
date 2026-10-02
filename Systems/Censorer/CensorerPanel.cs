using System.Text;
using MiraAPI.Utilities;

namespace CIA.Mod.Systems.Censorer;

public static class CensorerPanel
{
    public static string BuildText(int roomId)
    {
        if (!CensorerState.TryGetSensorForRoom(roomId, out _))
            return string.Empty;

        var builder = new StringBuilder("ELECTRICAL SENSOR\nINSIDE:");

        foreach (var player in Helpers.GetAlivePlayers())
        {
            var playerRoom = Helpers.GetRoom(player.transform.position);
            if (playerRoom != null && playerRoom.RoomId == roomId)
                builder.Append("\n").Append(player.Data.PlayerName);
        }

        return builder.ToString();
    }
}
