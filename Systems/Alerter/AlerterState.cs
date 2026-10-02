using UnityEngine;

namespace CIA.Mod.Systems.Alerter;

public static class AlerterState
{
    public static PlayerControl? PinnedPlayer { get; private set; }
    public static float AlertUntil { get; private set; }

    public static bool HasPin => PinnedPlayer != null;

    public static void Pin(PlayerControl target, float duration)
    {
        PinnedPlayer = target;
        AlertUntil = Time.time + duration;
    }

    public static void Clear()
    {
        PinnedPlayer = null;
        AlertUntil = 0f;
    }

    public static bool IsAlertActive => Time.time < AlertUntil;
}
