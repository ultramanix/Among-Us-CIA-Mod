using System.Linq;
using MiraAPI.Utilities;
using TMPro;
using UnityEngine;

namespace CIA.Mod.Systems.Censorer;

public static class CensorerPanelUi
{
    private static GameObject? _root;
    private static TextMeshPro? _title;
    private static TextMeshPro? _inside;
    private static int _roomId = -1;

    public static bool IsOpen => _root != null && _root.activeSelf;

    public static void Open(int roomId)
    {
        if (PlayerControl.LocalPlayer == null || !CensorerState.TryGetSensorForRoom(roomId, out _))
            return;

        if (_root == null)
            Create();

        _roomId = roomId;
        _root?.SetActive(true);
        Refresh();
    }

    public static void Update()
    {
        if (!IsOpen)
            return;

        if (Input.GetKeyDown(KeyCode.X))
        {
            Close();
            return;
        }

        Refresh();
    }

    public static void Close()
    {
        _root?.SetActive(false);
        _roomId = -1;
    }

    private static void Create()
    {
        var camera = Camera.main;
        if (camera == null)
            return;

        _root = new GameObject("CIA_CensorerSensorPanel");
        _root.transform.SetParent(camera.transform, false);
        _root.transform.localPosition = new Vector3(0f, 0f, -50f);
        _root.layer = LayerMask.NameToLayer("UI");

        _title = Helpers.CreateTextLabel(
            "Title",
            _root.transform,
            AspectPosition.EdgeAlignments.TopCenter,
            new Vector3(0f, 0.8f, 0f),
            2.6f,
            TextAlignmentOptions.Center);
        _title.rectTransform.sizeDelta = new Vector2(7f, 0.8f);

        _inside = Helpers.CreateTextLabel(
            "Inside",
            _root.transform,
            AspectPosition.EdgeAlignments.Center,
            new Vector3(0f, 0f, 0f),
            2f,
            TextAlignmentOptions.Center);
        _inside.rectTransform.sizeDelta = new Vector2(8f, 5f);
    }

    private static void Refresh()
    {
        if (_roomId < 0 || _title == null || _inside == null)
            return;

        if (!CensorerState.TryGetSensorForRoom(_roomId, out _))
        {
            Close();
            return;
        }

        _title.text = "CENSOR SENSOR";

        var names = Helpers.GetAlivePlayers()
            .Where(player =>
            {
                var room = Helpers.GetRoom(player.transform.position);
                return room != null && room.RoomId == _roomId;
            })
            .Select(player => player.Data.PlayerName)
            .ToArray();

        _inside.text = names.Length == 0
            ? "INSIDE:\nNobody\n\nX = CLOSE"
            : "INSIDE:\n" + string.Join("\n", names) + "\n\nX = CLOSE";
    }
}
