using MiraAPI.Hud;
using MiraAPI.Utilities;

namespace CIA.Mod.Systems.Censorer;

public static class CensorerPanelUi
{
    private static CustomPlayerMenu? _menu;
    private static int _roomId = -1;

    public static void Open(int roomId)
    {
        if (PlayerControl.LocalPlayer == null || !CensorerState.TryGetSensorForRoom(roomId, out _))
            return;

        _roomId = roomId;
        _menu ??= CustomPlayerMenu.Create();

        _menu.Begin(
            player => IsInsideRoom(player, _roomId),
            _ => Close());
    }

    public static void Close()
    {
        if (_menu != null)
            _menu.Close();
        _roomId = -1;
    }

    private static bool IsInsideRoom(PlayerControl player, int roomId)
    {
        var room = Helpers.GetRoom(player.transform.position);
        return room != null && room.RoomId == roomId && !player.Data.IsDead && !player.Data.Disconnected;
    }
}
