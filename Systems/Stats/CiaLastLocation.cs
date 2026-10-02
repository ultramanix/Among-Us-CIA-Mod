using System.Collections.Generic;
using MiraAPI.Utilities;

namespace CIA.Mod.Systems.Stats;

public static class CiaLastLocation
{
    private static readonly Dictionary<byte, string> Locations = [];

    public static void Update(PlayerControl player)
    {
        if (player == null || player.Data == null || player.Data.IsDead)
            return;

        var room = Helpers.GetRoom(player.transform.position);
        if (room != null)
            Locations[player.PlayerId] = room.RoomId.ToString();
    }

    public static string Get(byte playerId)
    {
        return Locations.TryGetValue(playerId, out var location)
            ? location
            : "Unknown";
    }

    public static void Reset()
    {
        Locations.Clear();
    }
}
