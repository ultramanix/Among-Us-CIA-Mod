using System.Collections.Generic;
using MiraAPI.Utilities;
using UnityEngine;

namespace CIA.Mod.Systems.Censorer;

public readonly record struct CensorSensor(byte OwnerId, int RoomId, Vector3 Position);

public static class CensorerState
{
    private static readonly List<CensorSensor> Sensors = [];

    public static IReadOnlyList<CensorSensor> ActiveSensors => Sensors;

    public static bool TryPlace(byte ownerId, int maxSensors)
    {
        if (Sensors.Count >= maxSensors || PlayerControl.LocalPlayer == null)
            return false;

        var room = Helpers.GetRoom(PlayerControl.LocalPlayer.transform.position);
        if (room == null)
            return false;

        if (Sensors.Exists(x => x.RoomId == room.RoomId))
            return false;

        Sensors.Add(new CensorSensor(ownerId, room.RoomId, PlayerControl.LocalPlayer.transform.position));
        return true;
    }

    public static void Clear()
    {
        Sensors.Clear();
    }

    public static bool TryGetSensorForRoom(int roomId, out CensorSensor sensor)
    {
        foreach (var item in Sensors)
        {
            if (item.RoomId == roomId)
            {
                sensor = item;
                return true;
            }
        }

        sensor = default;
        return false;
    }
}
