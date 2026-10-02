using System.Collections.Generic;
using UnityEngine;

namespace CIA.Mod.Systems.Censorer;

public readonly record struct CensorSensor(byte OwnerId, int RoomId, Vector3 Position);

public static class CensorerState
{
    private static readonly List<CensorSensor> Sensors = [];

    public static IReadOnlyList<CensorSensor> ActiveSensors => Sensors;

    public static bool CanAdd(int maxSensors)
    {
        return Sensors.Count < maxSensors;
    }

    public static bool HasRoomSensor(int roomId)
    {
        return Sensors.Exists(x => x.RoomId == roomId);
    }

    public static bool AddSensor(byte ownerId, int roomId, Vector3 position, int maxSensors)
    {
        if (!CanAdd(maxSensors) || HasRoomSensor(roomId))
            return false;

        Sensors.Add(new CensorSensor(ownerId, roomId, position));
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
