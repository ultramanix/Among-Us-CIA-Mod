using System.Collections.Generic;
using UnityEngine;

namespace CIA.Mod.Systems.Killer;

public static class KillerHistory
{
    private const float SampleInterval = 0.1f;
    private const float HistoryLength = 5f;

    private static readonly Dictionary<byte, Queue<PositionSample>> Samples = [];

    public static void Record(PlayerControl player)
    {
        if (player == null || player.Data == null || player.Data.IsDead)
        {
            return;
        }

        if (!Samples.TryGetValue(player.PlayerId, out var queue))
        {
            queue = new Queue<PositionSample>();
            Samples[player.PlayerId] = queue;
        }

        var now = Time.time;
        if (queue.Count > 0 && now - queue.Peek().Time < SampleInterval)
        {
            return;
        }

        queue.Enqueue(new PositionSample(now, player.transform.position));

        while (queue.Count > 0 && now - queue.Peek().Time > HistoryLength)
        {
            queue.Dequeue();
        }
    }

    public static bool TryGetPosition(byte playerId, float secondsAgo, out Vector3 position)
    {
        position = default;

        if (!Samples.TryGetValue(playerId, out var queue) || queue.Count == 0)
        {
            return false;
        }

        var targetTime = Time.time - secondsAgo;
        PositionSample? best = null;

        foreach (var sample in queue)
        {
            if (sample.Time <= targetTime)
            {
                best = sample;
            }
            else
            {
                break;
            }
        }

        if (best.HasValue)
        {
            position = best.Value.Position;
            return true;
        }

        position = queue.Peek().Position;
        return true;
    }

    private readonly record struct PositionSample(float Time, Vector3 Position);
}
