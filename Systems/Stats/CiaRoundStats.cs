using System.Collections.Generic;

namespace CIA.Mod.Systems.Stats;

public static class CiaRoundStats
{
    private static readonly Dictionary<byte, int> Kills = [];
    private static readonly Dictionary<byte, int> Deaths = [];

    public static void Reset()
    {
        Kills.Clear();
        Deaths.Clear();
    }

    public static void RecordKill(byte playerId)
    {
        Kills[playerId] = Kills.GetValueOrDefault(playerId) + 1;
    }

    public static void RecordDeath(byte playerId)
    {
        Deaths[playerId] = Deaths.GetValueOrDefault(playerId) + 1;
    }

    public static int GetKills(byte playerId) => Kills.GetValueOrDefault(playerId);
    public static int GetDeaths(byte playerId) => Deaths.GetValueOrDefault(playerId);
}
